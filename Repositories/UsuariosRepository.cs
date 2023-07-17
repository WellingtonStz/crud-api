using Crud_API.Models.Entities.Clientes;
using Crud_API.Models;

namespace API_EF6.Repositories
{
    public interface IUsuariosRepository
    {
        public bool Create(PostUsuarios usuario);
        
    }
    public class UsuariosRepository : IUsuariosRepository
    {

        public bool Create(PostUsuarios usuario)
        {
            try
            {

                var usuario_db = new Usuarios()
                {
                    Nome = usuario.Nome,
                    Data_Nascimento = usuario.Data_Nascimento,
                    Email = usuario.Email
                };

                return true;

            }
            catch
            {
                return false;
            }

        }
    }
    
}