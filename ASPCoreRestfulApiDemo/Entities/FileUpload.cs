using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Entities
{
    public class FileUpload 
    {
        [Key]
        [MaxLength(36),MinLength(36)]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string FileName { get; set; }
        [MaxLength(1000)]
        public string FilePath { get; set; }
    }
}
