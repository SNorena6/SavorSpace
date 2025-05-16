using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SavorSpace.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SavorSpace.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Recipes.Any())
            {
                return; // DB has been seeded
            }

            // Seed recipes - all 30
            var recipes = new List<Recipe>
            {
                new Recipe { Name = "Apple Pie", Title = "Classic Apple Pie", Ingredients = "Apples, Sugar, Flour, Butter", Instructions = "Prepare crust, fill with apples, bake.", ImageUrl = "/images/recipes/applepie.jpg", CreatedAt = DateTime.Now.AddDays(-30) },
                new Recipe { Name = "Avocado Toast", Title = "Simple Avocado Toast", Ingredients = "Bread, Avocado, Salt, Pepper", Instructions = "Toast bread, mash avocado, spread, season.", ImageUrl = "/images/recipes/avocadotoast.jpg", CreatedAt = DateTime.Now.AddDays(-29) },
                new Recipe { Name = "BLT Sandwich", Title = "Bacon Lettuce Tomato Sandwich", Ingredients = "Bacon, Lettuce, Tomato, Bread, Mayo", Instructions = "Cook bacon, assemble sandwich.", ImageUrl = "/images/recipes/blt.jpg", CreatedAt = DateTime.Now.AddDays(-28) },
                new Recipe { Name = "Baked Salmon", Title = "Oven Baked Salmon", Ingredients = "Salmon, Lemon, Herbs, Olive Oil", Instructions = "Season salmon, bake until done.", ImageUrl = "/images/recipes/bakedsalmon.jpg", CreatedAt = DateTime.Now.AddDays(-27) },
                new Recipe { Name = "Banana Bread", Title = "Moist Banana Bread", Ingredients = "Bananas, Flour, Sugar, Eggs", Instructions = "Mix ingredients, bake in loaf pan.", ImageUrl = "/images/recipes/bananabread.jpg", CreatedAt = DateTime.Now.AddDays(-26) },
                new Recipe { Name = "Beef Tacos", Title = "Spicy Beef Tacos", Ingredients = "Ground Beef, Taco Shells, Spices", Instructions = "Cook beef with spices, serve in shells.", ImageUrl = "/images/recipes/beeftacos.jpg", CreatedAt = DateTime.Now.AddDays(-25) },
                new Recipe { Name = "Caesar Salad", Title = "Classic Caesar Salad", Ingredients = "Romaine, Caesar Dressing, Croutons", Instructions = "Toss ingredients together.", ImageUrl = "/images/recipes/caesarsalad.jpg", CreatedAt = DateTime.Now.AddDays(-24) },
                new Recipe { Name = "Caprese Salad", Title = "Fresh Tomato & Mozzarella Salad", Ingredients = "Tomatoes, Mozzarella, Basil, Olive Oil", Instructions = "Layer ingredients, drizzle oil.", ImageUrl = "/images/recipes/capresesalad.jpg", CreatedAt = DateTime.Now.AddDays(-23) },
                new Recipe { Name = "Chicken Alfredo", Title = "Creamy Chicken Alfredo Pasta", Ingredients = "Chicken, Fettuccine, Alfredo Sauce", Instructions = "Cook pasta, sauté chicken, mix with sauce.", ImageUrl = "/images/recipes/chickenalfredo.jpg", CreatedAt = DateTime.Now.AddDays(-22) },
                new Recipe { Name = "Chicken Soup", Title = "Warm Chicken Soup", Ingredients = "Chicken, Vegetables, Broth", Instructions = "Simmer ingredients until tender.", ImageUrl = "/images/recipes/chickensoup.jpg", CreatedAt = DateTime.Now.AddDays(-21) },
                new Recipe { Name = "Chocolate Cake", Title = "Rich Chocolate Cake", Ingredients = "Flour, Cocoa, Eggs, Sugar", Instructions = "Mix, bake, frost.", ImageUrl = "/images/recipes/chocolatecake.jpg", CreatedAt = DateTime.Now.AddDays(-20) },
                new Recipe { Name = "Cobb Salad", Title = "Hearty Cobb Salad", Ingredients = "Lettuce, Chicken, Bacon, Eggs, Avocado", Instructions = "Combine all ingredients.", ImageUrl = "/images/recipes/cobbsalad.jpg", CreatedAt = DateTime.Now.AddDays(-19) },
                new Recipe { Name = "Eggplant Parmesan", Title = "Baked Eggplant Parmesan", Ingredients = "Eggplant, Tomato Sauce, Cheese", Instructions = "Bread and bake eggplant, layer with sauce and cheese.", ImageUrl = "/images/recipes/eggplantparmesan.jpg", CreatedAt = DateTime.Now.AddDays(-18) },
                new Recipe { Name = "French Toast", Title = "Sweet French Toast", Ingredients = "Bread, Eggs, Milk, Cinnamon", Instructions = "Dip bread in egg mix, fry.", ImageUrl = "/images/recipes/frenchtoast.jpg", CreatedAt = DateTime.Now.AddDays(-17) },
                new Recipe { Name = "Grilled Cheese", Title = "Classic Grilled Cheese Sandwich", Ingredients = "Bread, Cheese, Butter", Instructions = "Butter bread, grill with cheese.", ImageUrl = "/images/recipes/grilledcheese.jpg", CreatedAt = DateTime.Now.AddDays(-16) },
                new Recipe { Name = "Grilled Chicken", Title = "Juicy Grilled Chicken Breast", Ingredients = "Chicken Breast, Spices, Olive Oil", Instructions = "Season chicken, grill until done.", ImageUrl = "/images/recipes/grilledchicken.jpg", CreatedAt = DateTime.Now.AddDays(-15) },
                new Recipe { Name = "Lasagna", Title = "Layered Italian Lasagna", Ingredients = "Pasta Sheets, Meat Sauce, Cheese", Instructions = "Layer and bake.", ImageUrl = "/images/recipes/lasagna.jpg", CreatedAt = DateTime.Now.AddDays(-14) },
                new Recipe { Name = "Mac and Cheese", Title = "Creamy Mac and Cheese", Ingredients = "Macaroni, Cheese, Milk", Instructions = "Cook macaroni, mix with cheese sauce.", ImageUrl = "/images/recipes/macandcheese.jpg", CreatedAt = DateTime.Now.AddDays(-13) },
                new Recipe { Name = "Meatloaf", Title = "Homestyle Meatloaf", Ingredients = "Ground Beef, Breadcrumbs, Eggs, Ketchup", Instructions = "Mix ingredients, bake.", ImageUrl = "/images/recipes/meatloaf.jpg", CreatedAt = DateTime.Now.AddDays(-12) },
                new Recipe { Name = "Omelette", Title = "Fluffy Omelette", Ingredients = "Eggs, Cheese, Vegetables", Instructions = "Beat eggs, cook with fillings.", ImageUrl = "/images/recipes/omelette.jpg", CreatedAt = DateTime.Now.AddDays(-11) },
                new Recipe { Name = "Pancakes", Title = "Fluffy Pancakes", Ingredients = "Flour, Eggs, Milk, Baking Powder", Instructions = "Mix batter, cook on griddle.", ImageUrl = "/images/recipes/pancakes.jpg", CreatedAt = DateTime.Now.AddDays(-10) },
                new Recipe { Name = "Pasta Primavera", Title = "Vegetable Pasta Primavera", Ingredients = "Pasta, Mixed Vegetables, Olive Oil", Instructions = "Cook pasta and veggies, toss.", ImageUrl = "/images/recipes/pastaprimavera.jpg", CreatedAt = DateTime.Now.AddDays(-9) },
                new Recipe { Name = "Pizza Margherita", Title = "Classic Margherita Pizza", Ingredients = "Pizza Dough, Tomato Sauce, Mozzarella, Basil", Instructions = "Assemble and bake pizza.", ImageUrl = "/images/recipes/pizzamargherita.jpg", CreatedAt = DateTime.Now.AddDays(-8) },
                new Recipe { Name = "Pulled Pork", Title = "Slow Cooked Pulled Pork", Ingredients = "Pork Shoulder, BBQ Sauce", Instructions = "Slow cook pork, shred.", ImageUrl = "/images/recipes/pulledpork.jpg", CreatedAt = DateTime.Now.AddDays(-7) },
                new Recipe { Name = "Quiche Lorraine", Title = "Classic Quiche Lorraine", Ingredients = "Pie Crust, Eggs, Bacon, Cheese", Instructions = "Fill crust and bake.", ImageUrl = "/images/recipes/quichelorraine.jpg", CreatedAt = DateTime.Now.AddDays(-6) },
                new Recipe { Name = "Ramen Noodles", Title = "Savory Ramen Noodles", Ingredients = "Noodles, Broth, Pork, Egg", Instructions = "Cook noodles in broth, add toppings.", ImageUrl = "/images/recipes/ramennoodles.jpg", CreatedAt = DateTime.Now.AddDays(-5) },
                new Recipe { Name = "Roast Chicken", Title = "Perfect Roast Chicken", Ingredients = "Whole Chicken, Herbs, Butter", Instructions = "Season chicken, roast until done.", ImageUrl = "/images/recipes/roastchicken.jpg", CreatedAt = DateTime.Now.AddDays(-4) },
                new Recipe { Name = "Shrimp Scampi", Title = "Garlic Butter Shrimp Scampi", Ingredients = "Shrimp, Garlic, Butter, Pasta", Instructions = "Cook shrimp, toss with pasta.", ImageUrl = "/images/recipes/shrimpscampi.jpg", CreatedAt = DateTime.Now.AddDays(-3) },
                new Recipe { Name = "Spaghetti Bolognese", Title = "Classic Italian Spaghetti", Ingredients = "Spaghetti, Ground Beef, Tomato Sauce, Onion, Garlic", Instructions = "Cook spaghetti. Brown beef with onion and garlic. Add tomato sauce. Mix with pasta.", ImageUrl = "/images/recipes/spaghetti.jpg", CreatedAt = DateTime.Now.AddDays(-2) },
                new Recipe { Name = "Stuffed Peppers", Title = "Bell Peppers Stuffed with Rice and Beef", Ingredients = "Bell Peppers, Ground Beef, Rice, Tomato Sauce", Instructions = "Stuff peppers and bake.", ImageUrl = "/images/recipes/stuffedpeppers.jpg", CreatedAt = DateTime.Now.AddDays(-1) }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges(); // Save to get RecipeIds assigned

            // Retrieve all recipes with generated IDs
            var allRecipes = context.Recipes.ToList();

            // Comments content for each recipe (one comment per recipe)
            var commentContents = new[]
            {
                "Loved this recipe! So delicious and easy to make.",
                "My family really enjoyed this dish.",
                "Perfect for a quick dinner.",
                "Followed the instructions exactly and it was great!",
                "I added a little extra spice and it was perfect.",
                "Will definitely make this again.",
                "Great flavor and very satisfying.",
                "Easy to customize with other ingredients.",
                "Cooked this for a friend and they loved it.",
                "So simple and tasty!",
                "The best recipe I’ve tried so far.",
                "Healthy and delicious.",
                "I made this for a party and everyone asked for the recipe.",
                "Comfort food at its best!",
                "A new favorite in our house.",
                "Instructions were very clear and helpful.",
                "Perfect balance of flavors.",
                "Quick prep and great results.",
                "Kids loved it too!",
                "The photo doesn’t do it justice — tastes amazing.",
                "Will be adding this to my weekly menu.",
                "Wonderful recipe for beginners.",
                "Great with a side salad.",
                "Took this to a potluck and it disappeared fast.",
                "So good I made it twice in one week!",
                "Easy to adjust for dietary preferences.",
                "Loved the freshness of the ingredients.",
                "Perfect for meal prep.",
                "Highly recommend to anyone.",
                "Delicious and filling."
                };

            // Seed comments linked to each recipe
            var comments = new List<Comment>();

            for (int i = 0; i < allRecipes.Count; i++)
            {
                comments.Add(new Comment
                {
                    RecipeId = allRecipes[i].RecipeId,
                    CommentText = commentContents[i]
                });
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();
        }
    }
}
