using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MoodREST.Interfaces;
using MoodREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private static readonly ISensorManager _mgr = new SensorManager();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_mgr.Get());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mgr.Get(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] SensorData data)
        {
            return Ok(_mgr.Create(data));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SensorData data)
        {
            try
            {
                return Ok(_mgr.Update(id, data));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_mgr.Delete(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpGet("GetLatest")]
        public IActionResult GetLatest()
        {
            return Ok(_mgr.GetLatest());
        }

        [HttpGet("GetByDates")]
        public IActionResult GetByDates([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return Ok(_mgr.GetByDates(from, to));
        }
    }
}
