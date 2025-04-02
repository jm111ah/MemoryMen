using LGM.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LGM.Controllers
{
    public class HomeController : ControllerBase
    {
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

        [HttpPost]
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
