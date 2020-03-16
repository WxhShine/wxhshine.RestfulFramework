using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wxhshine.Domian.Entities;

namespace wxhshine.Interface.RestAPI.Controllers
{
    [ApiController]
    [Route("api/uploadFile")]
    public class UpLoadFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AspCoreRestApiDbContext _dbContext;

        public UpLoadFileController(IWebHostEnvironment hostEnvironment, AspCoreRestApiDbContext dbContext)
        {
            _hostEnvironment = hostEnvironment;
            _dbContext = dbContext;
        }

        [HttpPost("streamUpload")]
        public async Task<IActionResult> StreamUploadAsync()
        {
            Console.WriteLine("StreamUpload上传了!");

            //获取Form提交的文件
            var files = Request.Form.Files;
            long size = files.Sum(f => f.Length);


            string webRootPath = _hostEnvironment.WebRootPath; //物理路径
            string showFilePath = "";
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    long fileSize = formFile.Length;
                    //获得文件大小，以字节为单位
                    var file = new FileUpload
                    {
                        Id = Guid.NewGuid(),
                        FileName = formFile.FileName
                    };

                    var filePath = webRootPath + "/upload";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    filePath = webRootPath + "/upload/" + file.FileName;
                    file.FilePath = filePath;
                    showFilePath = "upload/" + file.FileName;

                    _dbContext.FileUploads.Add(file);
                    await _dbContext.SaveChangesAsync();
                    Directory.CreateDirectory(filePath);
                    //把上传的图片复制到指定的文件中
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new
            {
                count = files.Count,
                savepath = showFilePath
            });
        }

        [HttpPost("base64Upload")]
        public async Task<IActionResult> Base64UploadAsync(string fileBase64, string fileName)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(fileBase64);

            string webRootPath = _hostEnvironment.WebRootPath;
            var file = new FileUpload
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
            };

            var filePath = webRootPath + "/upload";
            var showFilePath = "upload/" + file.FileName;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            filePath = webRootPath + "/upload/" + fileName;

            file.FilePath = filePath;
            _dbContext.FileUploads.Add(file);
            await _dbContext.SaveChangesAsync();
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("base64上传失败" + ex);
            }
            return Ok(new { savepath = showFilePath });
        }

        [HttpGet]
        public IActionResult GetAllFiles()
        {
            return Ok(_dbContext.FileUploads);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFiles(Guid id)
        {

            _dbContext.Remove(_dbContext.FileUploads.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult SeekUpload()
        {
            //获取Form提交的文件
            var files = Request.Form.Files[0];
            long lStartPos = 0;
            int startPosition = 0;
            int endPosition = 0;
            var contentRange = HttpContext.Request.Headers["Content-Range"].ToString();
            //bytes 10000-19999/1157632
            if (!string.IsNullOrEmpty(contentRange))
            {
                contentRange = contentRange.Replace("bytes", "").Trim();
                contentRange = contentRange.Substring(0, contentRange.IndexOf("/"));
                string[] ranges = contentRange.Split('-');
                startPosition = int.Parse(ranges[0]);
                endPosition = int.Parse(ranges[1]);
            }
            string webRootPath = _hostEnvironment.WebRootPath;
            //物理路径
            string fileName = files.FileName;
            string saveFilePath = webRootPath + "/upload/" + fileName;
            FileStream fs;
            if (System.IO.File.Exists(saveFilePath))
            {
                fs = System.IO.File.OpenWrite(saveFilePath);
                lStartPos = fs.Length;

            }
            else
            {
                fs = new System.IO.FileStream(saveFilePath, System.IO.FileMode.Create);
                lStartPos = 0;
            }
            if (lStartPos > endPosition)
            {
                fs.Close();
                return Ok();
            }
            else if (lStartPos < startPosition)
            {
                lStartPos = startPosition;
            }
            else if (lStartPos > startPosition && lStartPos < endPosition)
            {
                lStartPos = startPosition;
            }
            fs.Seek(lStartPos, System.IO.SeekOrigin.Current);
            fs.Close();
            return Ok();

        }

    }
}
