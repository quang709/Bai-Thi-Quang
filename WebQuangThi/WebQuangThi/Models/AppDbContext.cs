using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuangThi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }

      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, CategoryName = "Games" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, CategoryName = "Playstation" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, CategoryName = "Reviews" });

            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 1,
                Title = "The best online game is out now!",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida....",
                
                ImageUrl = "https://i.imgur.com/F3p0fO3.jpg",
                CategoryId = 1
            });
            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 2,
                Title = "Top 5 best games in november",
                Content = "Ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum labore suspendisse ultrices gravida....",
               
                ImageUrl = "https://i.imgur.com/XSg6Yud.jpeg",
                CategoryId = 2
            });



            modelBuilder.Entity<Posts>().HasData(new Posts
            {
                Id = 3,
                Title = "The best online game is out now!",
                Content = "Sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse ultrices gravida ncididunt ut labore ....",

                ImageUrl = "https://i.imgur.com/lmVvaM5.jpeg",
                CategoryId = 3
            });

            /*      modelBuilder.Entity<ProductTag>().HasKey(protag => new { protag.ProductId, protag.TagId });
                  //seeder data tag

                  modelBuilder.Entity<Tag>().HasData(new Tag
                  {
                      Id = 1,
                      Name = "Rẻ",


                  });
                  modelBuilder.Entity<Tag>().HasData(new Tag
                  {
                      Id = 2,
                      Name = "Ngon",



                  });
                  modelBuilder.Entity<Tag>().HasData(new Tag
                  {
                      Id = 3,
                      Name = "Bổ khỏe",
      */



        }
    }
}
