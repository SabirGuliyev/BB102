using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProniaBB102Web.Models
{
    public class Slide : BaseEntity
    {
       
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

    }
}
