using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenShiftDemo_Utilities;

namespace OpenShiftDemo_Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            var value = _configuration.GetValue<string>("Key");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty Value From appsettings";
            }
            return value;
        }

        [HttpGet]
        [Route("env")]
        public string GetFromEnvValues()
        {
            var value = _configuration.GetValue<string>("envKey");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty Value From Environment";
            }
            return value;
        }

        [HttpGet]
        [Route("map")]
        public string GetFromConfMap()
        {
            var value = _configuration.GetValue<string>("confmMapKey");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty Value From ConfMap";
            }
            return value;
        }

        #region Secret

        [HttpGet]
        [Route("secret/name")]
        public string GetValueFromSecretUserName()
        {
            var value = _configuration.GetValue<string>("userName");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty name value from secret";
            }
            return value;
        }

        [HttpGet]
        [Route("secret/pass")]
        public string GetValueFromSecretPassword()
        {
            var value = _configuration.GetValue<string>("password");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty password value from secret";
            }
            return value;
        }
        #endregion

    }
}
