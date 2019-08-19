using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightSchedule.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightSchedule.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharterSchedulesController : ControllerBase
    {
        private readonly ICharterScheduleService _service;
        public CharterSchedulesController(ICharterScheduleService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(CreateCharterScheduleDto dto)
        {
            var createdId = _service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = createdId }, createdId);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok(_service.GetById(id));
        }
    }
}