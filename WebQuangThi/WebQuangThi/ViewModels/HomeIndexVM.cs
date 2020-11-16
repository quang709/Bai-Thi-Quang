using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebQuangThi.Models;

namespace WebQuangThi.ViewModels
{
    public class HomeIndexVM
    {
        public List<Posts> Posts { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
