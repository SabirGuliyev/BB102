using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.ViewModels
{
    public class UpdateSlideVM
    {
        [Required(ErrorMessage = "Bashliq mutleq olmalidir")]
        public string Title { get; set; }

        public string SubTitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        public string Image { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
