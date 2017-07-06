namespace blog.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<blog.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "blog.Models.OdeToFoodDb";
        }

        protected override void Seed(blog.Models.OdeToFoodDb context)
        {
            context.Restuarants.AddOrUpdate(r => r.Name,
                new Restuarant { Name = "Rabin", City = "Kathmandu", Country = "Nepal"},
                new Restuarant { Name = "Maharjan", City = "London", Country = "England"},
                new Restuarant
                {
                    Name = "abx",
                    City = "dyi",
                    Country = "lkj",
                    Reviews =
                        new List<RestaurantReview>
                        {
                            new RestaurantReview { Rating = 9, Body = "This is body", ReviewerName = "AAA" }
                        }
                }
                );

            for (int i = 0; i < 1000; i++)
            {
                context.Restuarants.AddOrUpdate(r => r.Name,
                new Restuarant { Name = i.ToString(), City = "NoWhere", Country = "Nepal" });
            }
        }
    }
}
