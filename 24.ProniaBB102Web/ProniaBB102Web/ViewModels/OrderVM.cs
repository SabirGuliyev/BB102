using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.ViewModels
{
    public class OrderVM
    {
        [Required]
        public string Address { get; set; }
    }
}
