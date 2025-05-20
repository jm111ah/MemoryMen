using LGM.Dto;
using LGM.Enum;
using LGM.Interface;
using LGM.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LGM.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHome _home;
        private readonly IJWT _jwt;


        public HomeController(IConfiguration configuration, IHome home, IJWT jWT)
        {
            _configuration = configuration;
            _home = home;
            _jwt = jWT;
        }

        [HttpGet]
        [Route("JWT")]
        public async Task<IActionResult> GetToken([FromQuery] HomeDto homeDto)
        {
            try
            {
                #region 데이터 추출

                MemberDto memberDto = new MemberDto();
                memberDto.Name = homeDto.Name;

                //var data = await _home.SelectMember(memberDto);

                #endregion

                #region JWT 발급

                // 원본 데이터
                //memberDto.NameIdentifier = data.MemberSeq.ToString();
                //memberDto.Name = data.MemberName;
                //memberDto.Role = data.RoleId == MemberEnum.Admin ? "Admin" : "User";

                // 테스트 데이터
                memberDto.NameIdentifier = "1";
                memberDto.Name = "테스터";
                memberDto.Role = "Admin";

                var token = await _jwt.GenerateToken(memberDto);

                #endregion

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserAsync([FromQuery] HomeDto homeDto)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAsync([FromQuery] HomeDto homeDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] HomeDto homeDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromBody] HomeDto homeDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
