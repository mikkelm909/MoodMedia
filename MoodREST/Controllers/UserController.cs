using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;
using MoodREST.Managers;
using Microsoft.AspNetCore.Http;
using MoodREST.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoodREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static IUserManager userManager = new UserManager();
        [EnableCors]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userManager.GetAll();
        }
        [EnableCors]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(userManager.Get(id));
            }
            catch(KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [EnableCors]
        [HttpGet("GetBySpotifyId/{spotifyId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBySpotifyId(string spotifyId)
        {
            try
            {
                return Ok(userManager.GetBySpotifyId(spotifyId));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [EnableCors]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(userManager.Post(user));
        }
        [EnableCors]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                return Ok(userManager.Update(id, user));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
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
                return Ok(userManager.Remove(id));
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }

        [HttpPut("MoodPlaylists/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateMoodPlaylists(string id, [FromBody] IEnumerable<Playlist> moodPlaylists)
        {
            try
            {
                userManager.ImportMoodPlaylists(id, moodPlaylists);
                return Ok();
            }
            catch (KeyNotFoundException knfe)
            {
                return NotFound(knfe.Message);
            }
        }
    }
}
