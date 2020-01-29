using Microsoft.AspNetCore.Mvc;

namespace Hunter.API.Controllers
{
    [Route("api/[controller]")]
    public class PingController
    {
        
        [HttpGet]
        public string Get()
        {
            return "pong";
        }
        
    }
}