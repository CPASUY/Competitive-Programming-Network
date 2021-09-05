using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rcp.Data;
using Rcp.Models;
using System;
using System.Linq;

namespace Rcp
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RcpContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RcpContext>>()))
            {
                // Look for any movies.
                if (context.Competitor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Competitor.AddRange(
                    new Competitor
                    {
                        Username = "Seyerman",
                        FirstName = "Juan Manuel",
                        LastName = "Reyes",
                        Password = "1234",
                        ConfirmPwd= "1234",
                        Birthdate= DateTime.Parse("1995-4-01"),
                    },

                    new Competitor
                    {
                        Username = "Favellaneda",
                        FirstName = "Fabio",
                        LastName = "Avellaneda",
                        Password = "123",
                        ConfirmPwd = "123",
                        Birthdate = DateTime.Parse("1987-9-06"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
