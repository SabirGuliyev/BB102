using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.Models
{
    public class Employee:BaseEntity
    {

        [Required(ErrorMessage ="Ad bosh olmamalidir")]
        public string Name { get; set; }
        public string Surname { get; set; }

        public int PositionId { get; set; }
        public Position? Position { get; set; }
    }
}
