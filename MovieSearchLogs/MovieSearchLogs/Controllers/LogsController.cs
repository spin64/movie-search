using Microsoft.AspNetCore.Mvc;
using MovieSearchLogs.Models;

namespace MovieSearchLogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        readonly LogContext _logContext;

        public LogsController(LogContext logContext)
        {
            this._logContext = logContext;
        }

        [HttpGet]
        [Route("GetLogs")]
        public IActionResult GetLogs()
        {
            return Ok(_logContext.Logs.ToList());
        }

        [HttpPost]
        [Route("AddLog")]
        public async Task<IActionResult> AddLog(Log log)
        {
            _logContext.Logs.Add(log);
            await _logContext.SaveChangesAsync();
            return Ok("log added");
        }
    }
}
