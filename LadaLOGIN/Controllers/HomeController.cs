using Microsoft.AspNetCore.Mvc;
using LadaLOGIN.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using LadaLOGIN.Controllers;

namespace LadaLOGIN.Controllers
{
    public class HomeController : Controller
    {

        private readonly SpisoksRepository spisoksRepository;

        public HomeController(SpisoksRepository spisoksRepository)
        {
            this.spisoksRepository = spisoksRepository;
        }

        public IActionResult Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var foundPets = spisoksRepository.SearchSpisok(search);
                return View(foundPets);
            }

            var spisok = spisoksRepository.GetAllSpisok();
            return View(spisok);
        }

        public IActionResult Details(int Id)
        {
            var spisok = spisoksRepository.GetSingleSpisok(Id);
            return View(spisok);
        }
        [HttpGet]
        public IActionResult New(int id)
        {
            ViewBag.IsEditMode = "false";
            var spisok = new Spisok();
            return View(spisok);
        }
        [HttpPost]
        public IActionResult New(Spisok spisok, string IsEditMode, IFormFile file)
        {
            if (IsEditMode.Equals("false"))

            {
                spisoksRepository.CreateSpisok(spisok);
                UploadFile(file, spisok.Id);
            }
            else
            {
                spisoksRepository.EditSpisok(spisok);
                UploadFile(file, spisok.Id);
            }
            return RedirectToAction("Index");
            //return RedirectToAction(nameof(Index));
        }

        public void UploadFile(IFormFile file, int Id)
        {
            try
            {
                var fileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var spisok = spisoksRepository.GetSingleSpisok(Id);
                spisok.Img1 = fileName;
                spisoksRepository.EditSpisok(spisok);
            }
            catch (Exception)
            {
                Response.Redirect("Index");
                //return Content("gde kartina");
                //Response.WriteAsync("HET KARTINKI !!!");
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.IsEditMode = "true";
            var spisok = spisoksRepository.GetSingleSpisok(Id);
            return View("New", spisok);
        }
        public IActionResult Delete(int Id)
        {
            var spisok = spisoksRepository.GetSingleSpisok(Id);
            spisoksRepository.DeleteSpisok(spisok);

            return RedirectToAction(nameof(Index));
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using LadaLOGIN.Models;

//namespace LadaLOGIN.Controllers
//{
//    public class HomeController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
