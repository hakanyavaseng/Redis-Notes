using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Distributed.Caching.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache distributedCache;
        public ValuesController(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        [HttpGet]
        public async Task<IActionResult> Set(string name, string surname)
        {
            await distributedCache.SetStringAsync("name", name, options: new()
            {
                 AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                 SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            await distributedCache.SetAsync("surname", Encoding.UTF8.GetBytes(surname), options: new()
            {
                 AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                 SlidingExpiration = TimeSpan.FromSeconds(5)
            }); 
            
            return Ok($"{name} {surname} values are cached in Redis.");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string name = await distributedCache.GetStringAsync("name");
            var surnameBinary = await distributedCache.GetAsync("surname");

            string surname = Encoding.UTF8.GetString(surnameBinary);
          
            return Ok(new
            {
                name,
                surname
            });
        }
    }
}
