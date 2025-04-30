using Microsoft.AspNetCore.Mvc;

namespace SQLD.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class SQLDController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {

            return Ok();
        }
    }
}
