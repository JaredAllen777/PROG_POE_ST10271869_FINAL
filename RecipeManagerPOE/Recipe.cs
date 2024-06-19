using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerPOE
{
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        // Constructor that accepts a recipe name
        public Recipe(string name)
        {
            Name = name;
        }

        // Default constructor
        public Recipe()
        {
        }

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public List<Ingredient> GetIngredients()
        {
            return ingredients;
        }

        public List<string> GetSteps()
        {
            return steps;
        }

        public void EnterDetails()
        {
            // This method will be replaced by a UI in WPF
        }

        public void DisplayRecipe()
        {
            // This method will be replaced by a UI in WPF
        }

        public void ManageRecipe()
        {
            // This method will be replaced by a UI in WPF
        }

        public void ScaleRecipe(double factor)
        {
            if (factor <= 0)
            {
                // Display error in the UI
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantity()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

        public void CalculateTotalCalories()
        {
            int totalCalories = ingredients.Sum(i => i.Calories);
            // Display the total calories in the UI
            if (totalCalories > 300)
            {
                // Trigger a warning in the UI
            }
        }
    }
}