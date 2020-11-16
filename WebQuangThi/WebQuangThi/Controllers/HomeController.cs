using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebQuangThi.Models;
using WebQuangThi.ViewModels;

namespace WebQuangThi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger , AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM()
            {
                /*Products = _appDbContext.Products.Where(prod => EF.Functions.Like(prod.Name, "%a%")).Include(p => p.Category).ToList(),*/
                Posts = _appDbContext.Posts.Include(p => p.Category).ToList(),
                Categories = _appDbContext.Categories
            };


            return View(homeIndexVM);
        }
     /*   public IActionResult Privacy()
        {
            return View();
        }
*/
        public IActionResult Games()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
