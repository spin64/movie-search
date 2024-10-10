using Microsoft.AspNetCore.Mvc;
using MovieSearchLogs.Models;


namespace MovieSearchLogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogContext logContext;

        public LogsController(LogContext logContext)
        {
            this.logContext = logContext;
        }

        [HttpGet]
        [Route("GetLogs")]
        public IActionResult GetLogs()
        {
            return Ok(logContext.Logs.ToList());
        }

        [HttpPost]
        [Route("AddLog")]
        public async Task<IActionResult> AddLog(Log log)
        {
            logContext.Logs.Add(log); 
            await logContext.SaveChangesAsync();
            return Ok("log added");
        }
    }
}
