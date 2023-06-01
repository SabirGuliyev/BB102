using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]       
        public string Password { get; set; }

        public bool IsRemember { get; set; }
    }
}
