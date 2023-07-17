using System.ComponentModel.DataAnnotations;

namespace Crud_API.Models.Entities.Clientes
{
    public class PostUsuarios
    {
        
        public string Nome { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public string Email { get; set; }



    }
}
