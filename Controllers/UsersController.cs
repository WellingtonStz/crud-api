using Crud_API.Models.Entities.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace Crud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {

            return Ok();

        }

        [HttpPost]
        public IActionResult Post(PostUsuarios cliente)
        {

            return Ok();

        }

        [HttpPut]
        public IActionResult Put()
        {

            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete()
        {

            return Ok();

        }
    }
}
