using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProniaBB102Web.ViewModels
{
    public class CreateSlideVM
    {
        [Required(ErrorMessage ="Yusif sene gelsin")]
        public string Title { get; set; }
       
        public string SubTitle { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }
        [Required(ErrorMessage ="Slide-de shekil olmalidir")]
        public IFormFile Photo { get; set; }
    }
}
