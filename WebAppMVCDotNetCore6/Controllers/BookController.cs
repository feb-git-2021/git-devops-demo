using BookProject.DataAccess.Repository.IRepository;
using BookProject.Models.Models;
using BookProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVCDotNetCore6.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment= webHostEnvironment;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertUpt(int? id)
        {
            //Book book= new Book();
            // Book book = new();//C# 10.00
            BookVM bookvm = new()
            {
                Book = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.Id.ToString()
                })

            };      
           
            if(id == null || id == 0)
            {             

                return View(bookvm);
               
            }
            else
            {
                //update existing Book
                bookvm.Book = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == id);
                return View(bookvm);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUpt(BookVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\books");
                var extension = Path.GetExtension(file.FileName);
                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName),FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Book.ImageUrl = @"\images\books\" + fileName + extension;

            }
                //if (obj.Book.Id == 0)
                //{
                //    _unitOfWork.Book.Add(obj.Book);
                //}
                //else
                //{
                //    _unitOfWork.Book.Update(obj.Book);
                //}
                _unitOfWork.Book.Add(obj.Book);
                _unitOfWork.Save();
                TempData["Success"] = "Book addedd successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region BookAPIEndPoints
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _unitOfWork.Book.GetAll(includeProperties:"Category");
            return Json(new { data = bookList });
        }

        #endregion

    }
}
