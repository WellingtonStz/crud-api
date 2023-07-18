using API_EF6.Repositories;
using Crud_API.DTO;
using Crud_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Crud_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsersController (IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var users = _usuariosRepository.Read(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }

        }

        [HttpGet]

        public IActionResult GetAllUser()
        {
            try
            {
                var GetAllUser = _usuariosRepository.GetallUsers();
                return Ok(GetAllUser);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult CreateUsers(Usuarios users)
        {

            try
            {
                var erros = new List<string>();
                if (string.IsNullOrEmpty(users.Nome) || string.IsNullOrWhiteSpace(users.Nome) || users.Nome.Length <= 2)
                {
                    erros.Add("Nome Inválido");
                }
                
                
                Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (string.IsNullOrEmpty(users.Email) || string.IsNullOrWhiteSpace(users.Email) || !regex.Match(users.Email).Success)
                {   
                    erros.Add("Email Inválido");
                }
                if(_usuariosRepository.ExistUsersEmail(users.Email))
                {
                    erros.Add("Email já cadastrado");
                }

                if(erros.Count > 0)
                {
                    return BadRequest(new ResponseErroDTO()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = erros
                    });
                }

                var create = _usuariosRepository.Create(users);
                return Ok(create);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        [HttpPut]
        public IActionResult Put(Usuarios users)
        {

            try
            {
                var erros = new List<string>();
                if (string.IsNullOrEmpty(users.Nome) || string.IsNullOrWhiteSpace(users.Nome) || users.Nome.Length <= 2)
                {
                    erros.Add("Nome Inválido");
                }


                Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (string.IsNullOrEmpty(users.Email) || string.IsNullOrWhiteSpace(users.Email) || !regex.Match(users.Email).Success)
                {
                    erros.Add("Email Inválido");
                }

                if (erros.Count > 0)
                {
                    return BadRequest(new ResponseErroDTO()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = erros
                    });
                }

                var update = _usuariosRepository.Update(users);

                if(update == true)
                {
                    return Ok("Usuário editado!");
                }
                return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao editar usuário, Tente Novamente! {ex.Message}"
                });
            }

        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(_usuariosRepository.Delete(id))
                return Ok("Usuário Deletado!");

                return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });

            }
            catch(Exception ex)
            {
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
            

        }
    }
}
