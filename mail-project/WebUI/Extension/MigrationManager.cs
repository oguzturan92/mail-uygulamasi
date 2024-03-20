using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Extension
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var projeContext = scope.ServiceProvider.GetRequiredService<ProjeContext>())
                {
                    try
                    {
                        projeContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                        throw;
                    }
                }
            }
        
            return host;
        }
    }
}