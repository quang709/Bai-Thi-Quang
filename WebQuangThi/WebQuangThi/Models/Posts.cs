using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuangThi.Models
{
    public class Posts
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } 

        public string ImageUrl { get; set; }
        public DateTime DateTime {get;set;}
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    
    }
}
 