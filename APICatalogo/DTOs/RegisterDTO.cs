using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Password { get; set; } 
    }
}
