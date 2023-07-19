using API_EF6.Repositories;
using Crud_API.DTO;
using Crud_API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // Implementação do método de ação para obter informações de um usuário específico via HTTP GET, com base no parâmetro "id".

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Tenta ler as informações do usuário usando o repositório "_usuariosRepository.Read(id)"
                var users = _usuariosRepository.Read(id);

                // Se o usuário for encontrado, retorna uma resposta Ok com os dados do usuário.
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta BadRequest com um objeto ResponseErroDTO contendo a mensagem de erro.
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }

        }

        // Implementação do método de ação para obter todas as informações de usuários via HTTP GET.

        [HttpGet]

        public IActionResult GetAllUser()
        {
            try
            {
                // Tenta recuperar todos os usuários usando o repositório "_usuariosRepository.GetallUsers()"
                var GetAllUser = _usuariosRepository.GetallUsers();

                // Se a operação for bem-sucedida, retorna uma resposta Ok contendo a lista de todos os usuários.
                return Ok(GetAllUser);

            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta BadRequest com um objeto ResponseErroDTO contendo a mensagem de erro.
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
        }

        // Implementação do método de ação para criar um novo usuário via HTTP POST.

        [HttpPost]
        public IActionResult CreateUsers(Usuarios users)
        {

            try
            {
                var erros = new List<string>();

                // Validação do nome do usuário.
                if (string.IsNullOrEmpty(users.Nome) || string.IsNullOrWhiteSpace(users.Nome) || users.Nome.Length <= 2)
                {
                    erros.Add("Nome Inválido");
                }
                
                
                Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");

                // Validação do formato do e-mail usando uma expressão regular.
                if (string.IsNullOrEmpty(users.Email) || string.IsNullOrWhiteSpace(users.Email) || !regex.Match(users.Email).Success)
                {   
                    erros.Add("Email Inválido");
                }

                // Verifica se o e-mail do usuário já está cadastrado no sistema.
                if (_usuariosRepository.ExistUsersEmail(users.Email))
                {
                    erros.Add("Email já cadastrado");
                }
                // Se houver erros de validação, retorna uma resposta BadRequest com a lista de erros.
                if (erros.Count > 0)
                {
                    return BadRequest(new ResponseErroDTO()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = erros
                    });
                }

                // Se não houver erros, prossegue com a criação do usuário usando o repositório.
                var create = _usuariosRepository.Create(users);
                return Ok(create);

            }
            catch (Exception ex)
            {
                // Em caso de exceção não tratada, retorna uma resposta de erro interno com uma mensagem descritiva.
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao salvar usuário, Tente Novamente! {ex.Message}"
                });
            }
        }

        // Implementação do método de ação para atualizar informações de um usuário via HTTP PUT.

        [HttpPut]
        public IActionResult Put(Usuarios users)
        {

            try
            {
                var erros = new List<string>();

                // Validação do nome do usuário
                if (string.IsNullOrEmpty(users.Nome) || string.IsNullOrWhiteSpace(users.Nome) || users.Nome.Length <= 2)
                {
                    erros.Add("Nome Inválido");
                }

                // Validação do formato do e-mail usando uma expressão regular
                Regex regex = new Regex(@"^([\w\.\-\+\d]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (string.IsNullOrEmpty(users.Email) || string.IsNullOrWhiteSpace(users.Email) || !regex.Match(users.Email).Success)
                {
                    erros.Add("Email Inválido");
                }

                // Se houver erros de validação, retorna uma resposta BadRequest com a lista de erros.
                if (erros.Count > 0)
                {
                    return BadRequest(new ResponseErroDTO()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Error = erros
                    });
                }

                // Tenta atualizar os dados do usuário usando o repositório "_usuariosRepository.Update(users)".
                var update = _usuariosRepository.Update(users);

                // Se a atualização for bem-sucedida, retorna uma resposta Ok com uma mensagem indicando a conclusão.
                if (update == true)
                {
                    return Ok("Usuário editado!");
                }

                // Se o usuário não for encontrado ou ocorrer um problema durante a atualização, retorna uma resposta BadRequest com um objeto ResponseErroDTO vazio.
                return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });
            }
            catch (Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta de erro interno com uma mensagem descritiva.
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErroDTO()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    MsgError = $"Ocorreu erro ao editar usuário, Tente Novamente! {ex.Message}"
                });
            }

        }

        // Implementação do método de ação para deletar um usuário via HTTP DELETE, com base no parâmetro "id".

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Tenta deletar o usuário usando o repositório "_usuariosRepository.Delete(id)".
                if (_usuariosRepository.Delete(id))
                return Ok("Usuário Deletado!");

                // Se o usuário não for encontrado para deleção, retorna uma resposta BadRequest com um objeto ResponseErroDTO vazio.
                return BadRequest(new ResponseErroDTO() { Status = StatusCodes.Status400BadRequest, });

            }
            catch(Exception ex)
            {
                // Em caso de exceção durante o processamento, retorna uma resposta BadRequest com um objeto ResponseErroDTO contendo a mensagem de erro.
                return BadRequest(new ResponseErroDTO()
                {
                    Status = StatusCodes.Status400BadRequest,
                    MsgError = ex.Message
                });
            }
            

        }
    }
}
