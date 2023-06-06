

using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.Models
{
    public class Category:BaseEntity
    {

        [Required(ErrorMessage ="Ad hissesi bosh ola bilmez")]
        [MaxLength(25,ErrorMessage ="Uzunluq 25den cox olmamalidir")]
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
