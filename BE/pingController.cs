using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
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