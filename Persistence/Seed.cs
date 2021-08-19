using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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