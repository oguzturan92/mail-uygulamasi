using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete.Configuration;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EfCore
{
    public class ProjeContext : IdentityDbContext<ProjeUser, ProjeRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            
                    // MsSql PC
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=mail-project;Integrated Security=True;");

        }

        // ENTİTY/CONCRETE içinde oluşturulan tabloların isimlerini, buraya ekliyoruz.
        public DbSet<Mail> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // JUNCTION tablo düzenlemesi. Çoka Çok Tabloların ID'lerini ProductCategory adında tek bir tabloda birleştireceğimizi belirtiyoruz.
            // modelBuilder.Entity<ProductCategory>()
                        // .HasKey(c => new {c.CategoryId, c.ProductId});

            base.OnModelCreating(modelBuilder); // IDentityUserLogin hatasını engeller

            modelBuilder.ApplyConfiguration(new MailConfiguration());
        }
    }
}
