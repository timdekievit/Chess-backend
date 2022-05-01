using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Bob", UserName = "bob", Email = "bob@test.com"},
                    new AppUser{DisplayName = "Tom", UserName = "tom", Email = "tom@test.com"},
                    new AppUser{DisplayName = "Jane", UserName = "jane", Email = "jane@test.com"}
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }


            if (context.Matches.Any()) return;

            var matches = new List<Match>
            {
                new Match
                {
                    White = "Tim",
                    Black = "Jeroen",
                    Event = "?",
                    Site = "?",
                    Date = "????.??.??",
                    Round = "?",
                    Result = "1-0",
                    Pgn = new string[] {"1. e3 d6", "2. Bc4 Bd7", "3. Qf3 a6", "4. Qxf7# 1-0"}
                },
            };

            await context.Matches.AddRangeAsync(matches);
            await context.SaveChangesAsync();

        }
    }
}