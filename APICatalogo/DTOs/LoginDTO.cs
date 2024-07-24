using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Password { get; set; }
    }
}
