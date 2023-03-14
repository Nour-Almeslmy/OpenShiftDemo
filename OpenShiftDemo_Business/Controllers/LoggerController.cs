using Microsoft.AspNetCore.Mvc;

namespace OpenShiftDemo_Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        public string Log()
        {
            try
            {
                string? error = null;
                error.ToUpper();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Logging Endpoint Error", new object());
            }
            return $"Logging";
        }
    }
}
