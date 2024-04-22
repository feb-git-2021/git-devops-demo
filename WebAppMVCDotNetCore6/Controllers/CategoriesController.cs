using Microsoft.AspNetCore.Mvc;
using BookProject.DataAccess.Data;
using BookProject.Models.Models;
using BookProject.DataAccess.Repository.IRepository;

namespace WebAppMVCDotNetCore6.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
           _unitOfWork=unitOfWork;
        }

        public IActionResult Index()
        {
            var allCategories = _unitOfWork.Category.GetAll();          
            return View(allCategories);
        }
        public IActionResult Method2()
        {
            //ViewBag.Fname = TempData["Fname"];
            return View();
        }
        public IActionResult Details(int id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
           
            return View(category);
        }
        //Create Get
        public IActionResult Create()
        {
            return View();
        }
        //Create -Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category catObj)
        {
            //if(catObj.CategoryName == catObj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Custom Error", "Display order cannot match the Category name");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(catObj);
                _unitOfWork.Save();
                TempData["Success"] = "Category added successfully";

                return RedirectToAction(nameof(Index));
            }
            
                return View(catObj);
            
        }
        //Edit Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
          //  var categoryFromDb = _db.Categories.Find(id);
            var categoryFirstOrDefault = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            //var categorySingleOrDefault = _db.Categories.SingleOrDefault(c => c.Id == id);
            if(categoryFirstOrDefault == null)
            {
                return NotFound();
            }
            return View(categoryFirstOrDefault);
        }
        //Edit -Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult Edit(Category catObj)
        {
          
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(catObj);
                _unitOfWork.Save();
                TempData["Success"] = "Category updated successfully";
                //return RedirectToAction("sdsIndex");
                return RedirectToAction(nameof(Index));
            }

            return View(catObj);

        }
        //Delete - Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int ? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(c=>c.Id==id);
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }

    }
}
