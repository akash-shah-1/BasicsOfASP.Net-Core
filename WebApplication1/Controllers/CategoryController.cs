using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; //Field is used to interact with database
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Catergory> objCategoyList = _db.Categories.ToList();
            return View(objCategoyList);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catergory obj)
        {
            if(obj.Category ==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category","Display order cannot be exactly match the Category Name");
            }
            if(ModelState.IsValid) //This Model.State will go to the Model and check validation there 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

    }
}
