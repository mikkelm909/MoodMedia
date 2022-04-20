using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MoodREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : Controller
    {
        private static AdministratorManager _administratorManager = new AdministratorManager();
        public AdministratorController()
        {

        }
        [EnableCors]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Administrator admin)
        {
            bool authenticated = _administratorManager.ValidateAuthetication(admin.Username, admin.Password);
            if (authenticated)
            {
                return Ok(authenticated);
            }
            else { return BadRequest(authenticated); }
        }

        [EnableCors]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_administratorManager.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [EnableCors]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] Administrator admin)
        {
            try
            {
                return Ok(_administratorManager.CreateAdmin(admin));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }

        [EnableCors]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_administratorManager.Delete(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }
    }
}
