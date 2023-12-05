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
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) { return NotFound(); }
            Catergory? CategoryFromDB = _db.Categories.Find(id); //This method is used only to get ID
           // Catergory? CategoryFromDB2 = _db.Categories.FirstOrDefault(u => u.Id == id); //Using this method we can get more fields like name
            if(CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Catergory obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Catergory? CategoryFromDB = _db.Categories.Find(id);
            if (CategoryFromDB == null)
            {
                return NotFound();
            }
            return View(CategoryFromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Catergory? obj=_db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
