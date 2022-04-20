using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MoodREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoodREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private static readonly StatisticsManager _mgr = new();

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
        public IActionResult Post([FromBody] StatisticsData data)
        {
            return Ok(_mgr.Create(data));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatisticsData data)
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

        [HttpGet("GetByDates")]
        public IActionResult GetByDates([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            return Ok(_mgr.GetByDates(from, to));
        }
    }
}
