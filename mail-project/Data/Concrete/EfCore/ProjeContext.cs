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

                    // MsSql HOSTİNG
                // .UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;database=blog;user=e-ticaret;password=hw45l?44H");

                    // MySqlPC
                // .UseMySql("server=localhost;port=3306;database=medikal;user=root;password=Ot962962;",
                //         new MySqlServerVersion(new Version(10, 3, 36)
                //     )
                // );

                    // MySqlHOSTING
                // .UseMySql("server=localhost;port=3306;database=sablon8soft;user=sablon8soft;password=w6j1v&8T8;",
                //         new MySqlServerVersion(new Version(10, 6, 9)
                //     )
                // );
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