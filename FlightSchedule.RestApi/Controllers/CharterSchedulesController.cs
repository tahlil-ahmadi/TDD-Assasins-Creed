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
        public void Post()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public List<string> Get()
        {
            return null;
        }
    }
}