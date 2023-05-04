using Microsoft.AspNetCore.Mvc;
using MultiShop.Models;
using MultiShop.ViewModels;

namespace MultiShop.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            List<Slide> slides=new List<Slide>();
            slides.Add(new Slide
            {
                Id = 1,
                Title="Bashliq 1",
                Article="Qara gunler",
                Image= "carousel-1.jpg",
                Order=3
            });
            slides.Add(new Slide
            {
                Id = 2,
                Title = "Bashliq 2",
                Article = "Qara gunler hele qabaqdadir",
                Image = "carousel-2.jpg",
                Order = 2
            });
            slides.Add(new Slide
            {
                Id = 3,
                Title = "Bashliq 3",
                Article = "Salam gencler ddsgds dsfdsfsd sdfsdf",
                Image = "hasbik.jpg",
                Order = 2
            });
            slides.Add(new Slide
            {
                Id = 4,
                Title = "Bashliq 4",
                Article = "Salam gencler ddsgds dsfdsfsd sdfsdf",
                Image = "carousel-3.jpg",
                Order = 4
            });
            slides.Add(new Slide
            {
                Id = 5,
                Title = "Bashliq 5",
                Article = "Salam gencler ddsgds dsfdsfsd sdfsdf",
                Image = "carousel-3.jpg",
                Order = 1
            });


            List<Product> products=new List<Product>();
            products.Add(new Product
            {
                Id = 1,
                Name = "Nike",
                Price = 120.5m,
                Image = "Nike-Swoosh-News-Gear.webp"

            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Puma",
                Price = 78.5m,
                Image = "Delphin-Sneakers.jpg"

            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Adidas",
                Price = 225.00m,
                Image = "012623-GW6838-Adidas-Ozelia-Chalky-Brown-1200X1200-04-min.jpg"

            });



            HomeVM homeVM = new HomeVM
            {
                Slides = slides.OrderBy(s => s.Order).Take(3).ToList(),
                Products = products
            };

            return View(homeVM);
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
