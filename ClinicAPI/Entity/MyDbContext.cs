using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;Database=themanh1999;Uid=root;Pwd=12071999");
        }
        public DbSet<UserPeople> UserPeoples { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<Service> Services { get; set;}
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
<<<<<<< HEAD
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<MedicinePrescription> PreMedicine { get; set; }
=======
>>>>>>> 38e20eabbc43b4bb1c7983053b97dcf501223b5b
    }
}
