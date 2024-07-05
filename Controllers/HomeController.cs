using crud_demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace crud_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbcontext _context = new AppDbcontext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        

        public IActionResult Index()
        {
            var list = _context.Countries.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            ViewBag.Message = "Data inserted successfully";
            return RedirectToAction("index");

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data=_context.Countries.Where(x=>x.id==id).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            var data = _context.Countries.Where(x => x.id == country.id).FirstOrDefault();
            if (data != null)
            {
                data.name = country.name;
                data.isdcode = country.isdcode;
                data.isocode = country.isocode;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        public IActionResult Details(int id)
        {
            var data=_context.Countries.Where(x=> x.id==id).FirstOrDefault();   
            return View(data);

        }

        public ActionResult Delete(int id)
        {
            var data=_context.Countries.Where(x=>x.id == id).FirstOrDefault();
            _context.Countries.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Item Deleted Successfully";

            return RedirectToAction("index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
