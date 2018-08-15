using System.Collections.Generic;
using Api_User.Models;
using Api_User.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUsuario")]
        public ActionResult<string> Get(int id)
        {
            var user = userRepository.Find(id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            userRepository.Add(user);

            return CreatedAtRoute("GetUsuario", new { id = user.Id }, user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
                return BadRequest();

            var userFind = userRepository.Find(id);

            if (userFind == null)
                return NotFound();

            userFind.Name = user.Name;
            userFind.Email = user.Email;
            userFind.Password = user.Password;

            userRepository.Update(userFind);

            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = userRepository.Find(id);

            if (usuario == null)
                return NotFound();

            userRepository.Remove(id);

            return new NoContentResult();
        }
    }
}
