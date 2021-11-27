using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.models
{
   public class MyDbContext :DbContext
    {
        public MyDbContext() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;Database=manhnguyen;Uid=root;Pwd=12071999;");
        }
      
        public DbSet<StudentInformation> StudentInformation{ get; set; }
        public DbSet<ClassStudent> ClassStudent{ get;set; }
        public DbSet<Classes> Classes { get; set; }
    }
}
