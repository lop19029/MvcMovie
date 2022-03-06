using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-2-12"),
                        Genre = "Documentary",
                        Price = 7.99M,
                        Rating = "PG",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/17/Meet_the_Mormons_poster.jpg"
                    },

                    new Movie
                    {
                        Title = "Free Town ",
                        ReleaseDate = DateTime.Parse("2015-3-13"),
                        Genre = "Drama",
                        Price = 8.99M,
                        Rating = "PG13",
                        ImageUrl= "https://upload.wikimedia.org/wikipedia/en/b/be/Freetown_%282015%29.jpg"
                    },

                    new Movie
                    {
                        Title = "16 Stones",
                        ReleaseDate = DateTime.Parse("2014-2-23"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Rating = "PG",
                        ImageUrl = "https://resizing.flixster.com/0j4_8gbc9Ms-eXzaB4cip_S4OHc=/206x305/v2/https://flxt.tmsimg.com/assets/p11089298_p_v8_aa.jpg"
                    },

                    new Movie
                    {
                        Title = "Once I was a Beehive",
                        ReleaseDate = DateTime.Parse("2015-4-15"),
                        Genre = "Comedy",
                        Price = 3.99M,
                        Rating = "L",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Once_I_Was_a_Beehive_%282015%29.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}