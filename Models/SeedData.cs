using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcWebTruyen.Data;
using System;
using System.Linq;

namespace MvcWebTruyen.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcWebTruyenContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcWebTruyenContext>>()))
        {
            // Look for any movies.
            if (context.Truyen.Any())
            {
                return;   // DB has been seeded
            }
            context.Truyen.AddRange(
                new Truyen
                {
                    Title = "Hunter x Hunter",
                    ReleaseDate = DateTime.Parse("2004-3-3"),
                    Genre = "Romantic Comedy",
                    Rating = "R",
                    Price = 7.99M
                },
                new Truyen
                {
                    Title = "Doreamon ",
                    ReleaseDate = DateTime.Parse("1990-3-13"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 8.99M
                },
                new Truyen
                {
                    Title = "BlueLock",
                    ReleaseDate = DateTime.Parse("2023-3-20"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.99M
                },
                new Truyen
                {
                    Title = "Kimastu no yaiba",
                    ReleaseDate = DateTime.Parse("2021-4-15"),
                    Genre = "Western",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();

            // Try to save changes and handle any potential exceptions
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    
}
