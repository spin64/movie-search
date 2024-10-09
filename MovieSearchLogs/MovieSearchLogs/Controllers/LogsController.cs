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
        public List<Log> GetLogs()
        {
            return logContext.Logs.ToList();
        }

        [HttpPost]
        [Route("AddLog")]
        public string AddLog(Log log)
        {
            logContext.Logs.Add(log); 
            logContext.SaveChanges();
            return "log added";
        }
    }
}
