using Microsoft.AspNetCore.Mvc;

namespace APIServiceB.Controllers
{
   
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return $"I'm ServiceB -- {Request.Host.Port}";
        }
    }
}
