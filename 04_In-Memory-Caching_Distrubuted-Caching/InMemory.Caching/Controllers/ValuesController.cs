using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Caching.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache memoryCache; // DI for IMemoryCache

        public ValuesController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        
        [HttpGet("{name}")]
        public IActionResult SetName([FromRoute] string name)
        {
            memoryCache.Set("name", name); // Set the value in cache
            return Ok();
        }

        [HttpGet]
        public IActionResult GetName()
        {
            bool IsExists = memoryCache.TryGetValue("name", out string value); // Try to get the value from cache

            if (!IsExists)
                return NotFound();
            return Ok(value); // Get the value from cache
        }

        [HttpGet]
        public IActionResult SetDate()
        {
            memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                 AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                 SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDate()
        {
            return Ok(memoryCache.Get<DateTime>("date"));

        }

    }
}
