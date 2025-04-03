using LGM.Dto;
using LGM.Service;
using Microsoft.AspNetCore.Mvc;

namespace LGM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly JWT _jwt;

        public HomeController(JWT jwt)
        {
            _jwt = jwt;
        }

        [HttpGet]
        [Route("JWT")]
        public async Task<IActionResult> GetToken([FromBody] HomeDto homeDto)
        {
            try
            {
                var token = await _jwt.GenerateToken(homeDto.Name);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] HomeDto homeDto)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }
    }
}
