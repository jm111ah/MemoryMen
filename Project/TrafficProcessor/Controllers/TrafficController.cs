using Microsoft.AspNetCore.Mvc;
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
        var result =  _service.GetTraffic();
        return Json(result);
    }

    [Route("GetAsync")]
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] RequestTrafficDto requestDto)
    {
        var result = await _service.GetTrafficAsync();
        return Json(result);
    }
}