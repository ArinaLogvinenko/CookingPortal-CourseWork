namespace Infrastructure.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities;

    public static class ApplicationDbContextSeed
    {
        public static void SeedSampleData(this ApplicationDbContext context)
        {
            IList<User> sampleUser = new List<User>();
            IList<Recipe> sampleRecipes = new List<Recipe>();

            var user1 = new User()
            {
                FullName = "Ivan Ivanovich",
                Email = "Ivan@mail.com",
                Password = "example",
                Image = "\\images\\ava1.jpg",
                Status = "Cook"
            };

            var user2 = new User()
            {
                FullName = "Julie",
                Email = "Julie@mail.com",
                Password = "Julie33",
                Image = "\\images\\ava2.jpg",
                Status = "Cook",
                Followers = new List<User>() { user1 },
                Following = new List<User>() { user1 }
            };

            var user3 = new User()
            {
                FullName = "Paulo",
                Email = "Paulo@mail.com",
                Password = "Paulo33",
                Image = "\\images\\ava6.png",
                Status = "Su-shev",
                Followers = new List<User>() { user2, user1 },
                Following = new List<User>() { user2 }
            };

            var user4 = new User()
            {
                FullName = "Maximilian",
                Email = "Maximilian@mail.com",
                Password = "Maximilian33",
                Image = "\\images\\ava3.jpg",
                Status = "Cook",
                Followers = new List<User>() { user2, user1, user3 },
                Following = new List<User>() { user2, user1 }
            };

            var user5 = new User()
            {
                FullName = "Gordon Ramsay",
                Email = "Gordon@mail.com",
                Password = "Gordon314",
                Image = "\\images\\ava8.jpg",
                Status = "Сhef",
                Followers = new List<User>() { user1, user2 },
                Following = new List<User>() { user1, user2, user3, user4 }
            };

            if (!context.Users.Any())
            {
                sampleUser.Add(user1);
                sampleUser.Add(user2);
                sampleUser.Add(user3);
                sampleUser.Add(user4);
                sampleUser.Add(user5);

                context.Users.AddRange(sampleUser);

                context.SaveChanges();
            }

            if (!context.Recipes.Any())
            {
                sampleRecipes.Add(new Recipe()
                {
                    Description = "Authentic Italian pizza",
                    Image = "\\images\\food6.jpg",
                    Ingredients = "Spinach, onion, garlic, cream cheese, pine nuts, pizza dough, salt",
                    Name = "Pizza",
                    NutritionFacts = "460 kkal",
                    ServingTime = "45 min",
                    Author = context.Users.ToList()[4]
                });
                sampleRecipes.Add(new Recipe()
                {
                    Description = "Soft warming cocoa with caramel",
                    Image = "\\images\\food3.jpg",
                    Ingredients = "Milk, water, cocoa, caramel, cream, chocolate",
                    Name = "Caramel Cocoa",
                    NutritionFacts = "400 kkal",
                    ServingTime = "15 min",
                    Author = context.Users.ToList()[2]
                });
                sampleRecipes.Add(new Recipe()
                {
                    Description = "Healthy greens salad",
                    Image = "\\images\\food4.jpg",
                    Ingredients = "Cucumber, kohlrabi, celery, pea shoots, olive oil",
                    Name = "Green salad",
                    NutritionFacts = "250 kkal",
                    ServingTime = "20 min",
                    Author = context.Users.ToList()[3]
                });
                sampleRecipes.Add(new Recipe()
                {
                    Description = "Cream cheese toasts with salmon",
                    Image = "\\images\\food1.jpg",
                    Ingredients = "Toast, cream cheese, smoked salmon, sesame",
                    Name = "Toasts with salmon",
                    NutritionFacts = "260 kkal",
                    ServingTime = "10 min",
                    Author = context.Users.First()
                });
                sampleRecipes.Add(new Recipe()
                {
                    Description = "Fried egg with avocado and greens",
                    Image = "\\images\\food2.jpg",
                    Ingredients = "Egg, avocado, butter, greens, salt and pepper to taste",
                    Name = "Egg with avocado",
                    NutritionFacts = "270 kkal",
                    ServingTime = "15 min",
                    Author = context.Users.ToList()[1]
                });               

                context.Recipes.AddRange(sampleRecipes);

                context.SaveChanges();
            }
        }
    }
}
