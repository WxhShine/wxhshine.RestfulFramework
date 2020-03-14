using ASPCoreRestfulApiDemo.Entities;
using ASPCoreRestfulApiDemo.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [ApiController]
    [Route("api/configuration/")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ConfigurationController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet("DI/{configName}")]
        public IActionResult GetConfigurationByDI(string configName)
        {
            return Ok(_config[configName]);
        }

        [HttpGet("class")]
        public IActionResult GetConfigurationByClass()
        {
            return Ok(ConfigEntity.Instance.ConfigurationShow);
        }

        [HttpGet("helper/{configName}")]
        public IActionResult GetConfigurationByHelper(string configName)
        {
            return Ok(ConfigHelper.GetConfig(configName));
        }
    }
}
