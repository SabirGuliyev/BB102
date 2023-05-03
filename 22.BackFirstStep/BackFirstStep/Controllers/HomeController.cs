using BackFirstStep.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackFirstStep.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {

            List<Student> students = new List<Student>();
            students.Add(new Student { Id=1,Name="Revan",Surname="Isgenderov"});
            students.Add(new Student { Id=2,Name="Yusif",Surname="Aliyev"});




            //1.ViewBag.Students=students;

            //2.ViewData["Students"]=students;

            TempData["Students"]=students;


            


            return RedirectToAction("About");


            //return RedirectToAction("Index","Product");
        }

        public IActionResult About()
        {
            //return View("Test");
          
            //foreach (var item in students)
            //{
            //    Console.WriteLine(item.Name);
            //}
            return View();
        }
    }
}
