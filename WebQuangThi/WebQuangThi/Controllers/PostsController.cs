    using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebQuangThi.Common;
using WebQuangThi.Models;
using WebQuangThi.ViewModels;

namespace WebQuangThi.Controllers
{
    public class PostsController : Controller

    {

        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostsController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
           
            var Postss = _appDbContext.Posts.Include(p => p.Category).ToList();
            return View(Postss);
        }

        public IActionResult Create()
        {
            PostsCreateVM PostsVM = new PostsCreateVM()
            {
                Posts = new Posts(),
                CategorySelectList = _appDbContext.Categories.Select(item => new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.Id.ToString()
                }),
               
            };
            return View(PostsVM);
        }

        [HttpPost]
        public IActionResult Create(PostsCreateVM PostsCreateVM)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            string upload = webRootPath + CommonDefault.ImagePath;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            PostsCreateVM.Posts.ImageUrl = fileName + extension;

          

            _appDbContext.Posts.Add(PostsCreateVM.Posts);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }




        public IActionResult Edit(int? id)
        {
            var Posts = _appDbContext.Posts.Find(id);
          
            
            var selectList = new List<SelectListItem>();
          
            PostsCreateVM postsVM = new PostsCreateVM()
            {
                Posts = _appDbContext.Posts.FirstOrDefault(item => item.Id == id),
                CategorySelectList = _appDbContext.Categories.Select(item => new SelectListItem
                {
                    Text = item.CategoryName,
                    Value = item.Id.ToString()
                }),
               
              
            };

            return View(postsVM);
        }

        [HttpPost]
        public IActionResult Edit(PostsCreateVM PostsCreateVM)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;

            var objProduct = _appDbContext.Posts.AsNoTracking().FirstOrDefault(po => po.Id == PostsCreateVM.Posts.Id);

            if (files.Count > 0)
            {
                string upload = webRootPath + CommonDefault.ImagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                PostsCreateVM.Posts.ImageUrl = fileName + extension;
            }
            else
            {
                PostsCreateVM.Posts.ImageUrl = objProduct.ImageUrl;
            }

            _appDbContext.Posts.Update(PostsCreateVM.Posts);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Posts = _appDbContext.Posts.Find(id);
            if (Posts == null) return NotFound();

            return View(Posts);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var Posts = _appDbContext.Posts.Find(id);
            if (Posts == null) return NotFound();

            _appDbContext.Posts.Remove(Posts);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}