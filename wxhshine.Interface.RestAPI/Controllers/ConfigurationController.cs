using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using wxhshine.Infrastructure.Common.Configuration;
using wxhshine.Infrastructure.Common.Utils;

namespace wxhshine.Interface.RestAPI.Controllers
{
    [ApiController]
    [Route("api/configuration/")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigurationController(IConfiguration configuration) => _config = configuration;

        [HttpGet("class")]
        public IActionResult GetConfigurationByClass() => Ok(ConfigEntity.Instance.ConfigurationShow);

        [HttpGet("DI/{configName}")]
        public IActionResult GetConfigurationByDI(string configName) => Ok(_config[configName]);

        [HttpGet("helper/{configName}")]
        public IActionResult GetConfigurationByHelper(string configName) => Ok(ConfigHelper.GetConfig(configName));
    }
}
