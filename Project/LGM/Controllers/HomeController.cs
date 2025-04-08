﻿using LGM.Dto;
using LGM.Enum;
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
        private IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("JWT")]
        public async Task<IActionResult> GetToken([FromQuery] HomeDto homeDto)
        {
            try
            {

                

                #region 사용자 데이터 추출

                MemberDto memberDto = new MemberDto();
                memberDto.Name = homeDto.Name;

                var data = await homeService.SelectMember(memberDto);

                #endregion

                #region JWT 발급

                memberDto.NameIdentifier = data.MemberSeq.ToString();
                memberDto.Name = data.MemberName;
                memberDto.Role = data.RoldId == MemberEnum.Admin ? "Admin" : "User";

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
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }
        [Authorize(Roles ="Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] HomeDto homeDto)
        {
            return Ok();
        }
    }
}
