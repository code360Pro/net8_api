using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigMapController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ConfigMapController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet(Name = "GetConfigMap")]
        public string Get()
        {
            var appSettings = _config.GetSection("AppSettings");
            return appSettings.GetValue<string>("TestConfigMap");

        }

    }
}
