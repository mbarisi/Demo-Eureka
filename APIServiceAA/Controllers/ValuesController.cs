using Microsoft.AspNetCore.Mvc;


namespace APIServiceAA.Controllers
{    
    
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return $"I'm ServiceA -- {Request.Host.Port}";
        }

        [HttpGet]
        [HttpHead]
        [Route("healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok();
        }

        [HttpGet("info")]
        public string Info()
        {
            return "ServiceA - info";
        }
    }
}
