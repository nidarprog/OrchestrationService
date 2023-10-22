using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine(" --> Seeding data");

                context.Platforms.AddRange(
                    new Platform() {Name = "Dot net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() {Name = "Java", Publisher = "Oracle", Cost = "Free"},
                    new Platform() {Name = "Swfit", Publisher = "Apple", Cost = "$100"}
                    
                );
                context.SaveChanges();
            }else
            {
                Console.WriteLine("--> already have data");
            }
        }
    }
}