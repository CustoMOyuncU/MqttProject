using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        IInfoService _infoService;

        public InfosController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpPost("publish")]
        public IActionResult PublishMessage()
        {
            var result = _infoService.PublishMessage();

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }
        
    }
}
