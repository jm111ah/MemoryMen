using Microsoft.AspNetCore.Mvc;
using Serilog;
using TrafficProcessor.Dto;
using TrafficProcessor.Interface;

namespace TrafficProcessor.Controllers;


public class TrafficController : Controller
{
    private readonly ITrafficService _service;
    
    public TrafficController(ITrafficService service)
    {
        _service = service;
    }
    
    [Route("Get")]
    [HttpGet]
    public IActionResult Get([FromQuery] RequestTrafficDto requestDto)
    {
        try
        {
            var result = _service.GetTraffic();
            return Json(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Get 호출 실패");
            return BadRequest(ex.Message);
        }
    }

    [Route("GetAsync")]
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] RequestTrafficDto requestDto)
    {
        try
        {
            var result = await _service.GetTrafficAsync();
            return Json(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetAsync 호출 실패");
            return BadRequest(ex.Message);
        }
    }
    
    [Route("GetCacheAsync")]
    [HttpGet]
    public async Task<IActionResult> GetCacheAsync([FromQuery] RequestTrafficDto requestDto)
    {
        try
        {
            var result = await _service.GetTrafficAsync();
            return Json(result);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetCacheAsync 호출 실패");
            return BadRequest(ex.Message);
        }
    }

}