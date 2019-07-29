using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightSchedule.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharterSchedulesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            var id = new Random().Next(1,1000000000);
            return CreatedAtAction(nameof(Get), new {id = id}, id);
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(long id)
        {
            return "Hello world !";
        }
    }
}