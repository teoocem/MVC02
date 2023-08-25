using DAL.Configurations;
using DAL.Configurations.Base;

using EntityLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class Context : DbContext
    {
        static string connectionString = "server=DESKTOP-FLTCE77;database=cleanDB_06;integrated security=true;trustservercertificate=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.ApplyConfiguration(new CalisanConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmanConfiguration());
            modelBuilder.ApplyConfiguration(new GorevConfiguration());
            modelBuilder.ApplyConfiguration(new CalisanConfiguration());
            modelBuilder.ApplyConfiguration(new IzinConfiguration());
            modelBuilder.ApplyConfiguration(new IzinTalepConfiguration());
            modelBuilder.ApplyConfiguration(new CalisanGorevConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleDepartmanConfiguration());
        }
        public DbSet<StandartCalisan> StandartCalisanlar { get; set; }
        public DbSet<SubeMuduru> SubeMudurleri { get; set; }
        public DbSet<DaireBaskani> DaireBaskanlari { get; set; }

        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Gorev> Gorevler { get; set; }
      
        public DbSet<Izin> Izinler { get; set; }
        public DbSet<IzinTalep> IzinTalepleri { get; set; }
        public DbSet<Login> LoginInfos { get; set; }

        public DbSet<CalisanGorevAtamasi> CalisanGorevAtamasi { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}
