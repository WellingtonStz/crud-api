using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Crud_API.Models
{
    [Table(name:"cadastro_Usuarios")]
    public class Usuarios
    {
        [Key]

        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public DateTime Data_Nascimento { get; set; }


    }
}
