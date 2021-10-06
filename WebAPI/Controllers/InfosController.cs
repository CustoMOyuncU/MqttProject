using Business.Abstract;
using Core.DataAccess.InfluxDB;
using Entities.Concrete;
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
        public IActionResult PublishMessage(object message)
        {
            var result = _infoService.PublishMessage(message);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("turnoff")]
        public IActionResult TurnOff(object command)
        {
            var result = _infoService.TurnOffLight(command);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpPost("turnon")]
        public IActionResult TurnOn(object command)
        {
            var result = _infoService.TurnOnLight(command);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }
    }
}
