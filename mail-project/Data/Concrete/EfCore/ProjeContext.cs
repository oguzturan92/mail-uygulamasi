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
        
        public DbSet<Mail> Mails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MailConfiguration());
        }
    }
}
