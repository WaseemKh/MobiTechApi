using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiTech.Data
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MobiDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<SysUsers>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                SysUsers user = new SysUsers()
                {
                    Email = "waseemsabra2@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Waseem"
                };
                userManager.CreateAsync(user, "Waseem@123");
            }
        }
    }
}
