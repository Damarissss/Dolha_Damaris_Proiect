using Dolha_Damaris_Proiect.Data.Enums;
using Dolha_Damaris_Proiect.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dolha_Damaris_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Reference to the "LibraryContext" file
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                context.Database.EnsureCreated();

                // Cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema City",
                            Address = "Str. Alexandru Vaida Voevod, nr. 55, loc. Cluj-Napoca, cod poștal 400000"
                        },
                        new Cinema()
                        {
                            Name = "Cinema Victoria",
                            Address = "Str. Bulevardul Eroilor, nr. 51, loc. Cluj-Napoca, cod poștal 400394"
                        },
                        new Cinema()
                        {
                            Name = "Cinema Florin Piersic",
                            Address = "Str. Piața Mihai Viteazu, nr. 11-13, loc. Cluj-Napoca, cod poștal 400151"
                        },
                        new Cinema()
                        {
                            Name = "Cinema Dacia",
                            Address = "Bloc A1, Str. Bucegi, nr. 11, loc. Cluj-Napoca, cod poștal 400535"
                        },
                        new Cinema()
                        {
                            Name = "Cinema Mărăști",
                            Address = "Str. Aurel Vlaicu, nr. 3, loc. Cluj-Napoca, cod poștal 400581"
                        },
                    });
                    context.SaveChanges();
                }

                // Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Anya Taylor-Joy",
                            Bio = "Anya-Josephine Marie Taylor-Joy has won several accolades, including a Golden Globe Award and a Screen Actors Guild Award, in addition to a nomination for a Primetime Emmy Award. In 2021, she was featured on Time magazine's 100 Next list."
                        },
                        new Actor()
                        {
                            FullName = "Florence Pugh",
                            Bio = "Florence Pugh is an English actress. She made her acting debut in 2014 in the drama film The Falling. Pugh gained recognition in 2016 for her leading role as a young bride in the independent drama Lady Macbeth, winning a British Independent Film Award."
                        },
                        new Actor()
                        {
                            FullName = "Timothée Chalamet",
                            Bio = "Timothée Hal Chalamet is an American actor. He has received various accolades, including nominations for an Academy Award, two Golden Globe Awards, and three BAFTA Film Awards. Chalamet began his career as a teenager in television productions, appearing in the drama series Homeland in 2012."
                        },
                        new Actor()
                        {
                            FullName = "Matt Smith",
                            Bio = "Matthew Robert Smith is an English actor. He is best known for his roles as the eleventh incarnation of the Doctor in the BBC series Doctor Who, as well as Daemon Targaryen in the HBO series House of the Dragon."
                        },
                        new Actor()
                        {
                            FullName = "Saoirse Ronan",
                            Bio = "Saoirse Una Ronan is an American-born Irish actress. Primarily known for her work in period dramas since adolescence, she has received various accolades, including a Golden Globe Award, in addition to nominations for four Academy Awards and five British Academy Film Awards."
                        }
                    });
                    context.SaveChanges();
                }

                // Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Amy Pascal",
                            Bio = "Amy Beth Pascal is an American film producer and business executive. She served as the Chairperson of the Motion Pictures Group of Sony Pictures Entertainment and Co-Chairperson of SPE, including Sony Pictures Television, from 2006 until 2015."
                        },
                        new Producer()
                        {
                            FullName = "Robert Eggers",
                            Bio = "Robert Houston Eggers is an American filmmaker and production designer. He is best known for writing and directing the historical horror films The Witch and The Lighthouse, as well as directing and co-writing the historical fiction epic film The Northman."
                        },
                        new Producer()
                        {
                            FullName = "Wes Anderson",
                            Bio = "Wesley Wales Anderson is an American filmmaker. His films are known for their eccentricity and unique visual and narrative styles. They often contain themes of grief, loss of innocence, and dysfunctional families."
                        },
                        new Producer()
                        {
                            FullName = "Evelyn O'Neill",
                            Bio = "Evelyn O'Neill is an American talent manager and film producer. She is best known for producing the critically acclaimed film Lady Bird, for which she was co-nominated for the Academy Award for Best Picture at the 90th Academy Awards."
                        },
                        new Producer()
                        {
                            FullName = "Edgar Wright",
                            Bio = "Edgar Howard Wright is an English filmmaker. He is known for his fast-paced and kinetic, satirical genre films, which feature extensive utilisation of expressive popular music, Steadicam tracking shots, dolly zooms and a signature editing style that includes transitions, whip pans and wipes."
                        }
                    });
                    context.SaveChanges();
                }

                // Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Little Women",
                            Description = "While the March sisters enter the threshold of womanhood, they go through many ups and downs in life and endeavour to make important decisions that can affect their future.",
                            Price = 38.00,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieGenre = MovieGenre.Drama,
                            ImageTitle = "Little_Women"
                        },
                        new Movie()
                        {
                            Name = "The VVitch",
                            Description = "In the New England of the 17th century, a banished Puritan family sets up a farm by the edge of a huge remote forest where no other family lives. Soon, sinister forces then start haunting them.",
                            Price = 38.50,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieGenre = MovieGenre.Horror,
                            ImageTitle = "The_VVitch"
                        },
                        new Movie()
                        {
                            Name = "Nosferatu",
                            Description = "A gothic tale of obsession between a haunted young woman in 19th century Germany and the ancient Transylvanian vampire who stalks her, bringing untold horror with him.",
                            Price = 39.50,
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 3,
                            ProducerId = 2,
                            MovieGenre = MovieGenre.Thriller,
                            ImageTitle = "Nosferatu"
                        },
                        new Movie()
                        {
                            Name = "The French Dispatch",
                            Description = "A love letter to journalists set in an outpost of an American newspaper in a fictional 20th-century French city that brings to life a collection of stories published in \"The French Dispatch.\"",
                            Price = 39.50,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieGenre = MovieGenre.Comedy,
                            ImageTitle = "The_French_Dispatch"
                        },
                        new Movie()
                        {
                            Name = "Lady Bird",
                            Description = "As senior year comes to an end, Lady Bird must strive to navigate through the ups and downs in her relationships while trying to get into a prestigious college and become popular.",
                            Price = 37.50,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieGenre = MovieGenre.Drama,
                            ImageTitle = "Lady_Bird"
                        },
                        new Movie()
                        {
                            Name = "Last Night in Soho",
                            Description = "Eloise, an aspiring fashion designer, is fascinated with the fashion of the '60s. But her life spirals out of control when she dreams of being transported back to that time period.",
                            Price = 39.50,
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 5,
                            ProducerId = 5,
                            MovieGenre = MovieGenre.Horror,
                            ImageTitle = "Last_Night_in_Soho"
                        }
                    });
                    context.SaveChanges();
                }
                
                // Actor_Movie
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 1
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 3
                        },

                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 4
                        },

                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();
                }

                // Customers
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            FullName = "Ana-Maria Popescu",
                            Address = "Str. Plopilor, nr. 24",
                            BirthDate = DateTime.Parse("1996 - 09 - 01")                        
                        },
                        new Customer()
                        {
                            FullName = "Mihai Pascalopol",
                            Address = "Str. București, nr. 45, ap. 2",
                            BirthDate = DateTime.Parse("1989 - 07 - 08")                       
                        },
                        new Customer()
                        {
                            FullName = "Anastasia Karamazov",
                            Address = "Str. Constanța, nr. 13",
                            BirthDate = DateTime.Parse("1998 - 01 - 20")
                        }
                    });
                    context.SaveChanges();
                }

                // Orders
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Order>()
                    {
                        new Order()
                        {
                            OrderDate = DateTime.Parse("2022-12-26"),
                            CustomerId = context.Customers.Single(Customer => Customer.FullName == "Ana-Maria Popescu").Id,
                            MovieId = context.Movies.Single(Movie => Movie.Name == "Little Women").Id
                        },
                        new Order()
                        {
                            OrderDate = DateTime.Parse("2022-12-27"),
                            CustomerId = context.Customers.Single(Customer => Customer.FullName == "Ana-Maria Popescu").Id,
                            MovieId = context.Movies.Single(Movie => Movie.Name == "The VVitch").Id
                        },
                        new Order()
                        {
                            OrderDate = DateTime.Parse("2022-12-28"),
                            CustomerId = context.Customers.Single(Customer => Customer.FullName == "Mihai Pascalopol").Id,
                            MovieId = context.Movies.Single(Movie => Movie.Name == "The VVitch").Id
                        },
                        new Order()
                        {
                            OrderDate = DateTime.Parse("2023-01-03"),
                            CustomerId = context.Customers.Single(Customer => Customer.FullName == "Anastasia Karamazov").Id,
                            MovieId = context.Movies.Single(Movie => Movie.Name == "Last Night in Soho").Id
                        },
                        new Order()
                        {
                            OrderDate = DateTime.Parse("2023-01-03"),
                            CustomerId = context.Customers.Single(Customer => Customer.FullName == "Anastasia Karamazov").Id,
                            MovieId = context.Movies.Single(Movie => Movie.Name == "Nosferatu").Id
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
