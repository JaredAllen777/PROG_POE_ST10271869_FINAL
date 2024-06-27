using System;
using System.Collections.Generic;
using System.Linq;


//_______________________________________________START OF FILE________________________________________________________________\\

namespace RecipeManagerPOE
{
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();
        public string FoodGroup { get; set; }

//____________________________________________________________________________________________________________________________\\

        public Recipe(string name)
        {
            Name = name;
        }

//____________________________________________________________________________________________________________________________\\

        public Recipe()
        {
        }

//____________________________________________________________________________________________________________________________\\

        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

//____________________________________________________________________________________________________________________________\\

        public void AddStep(string step)
        {
            steps.Add(step);
        }

//____________________________________________________________________________________________________________________________\\

        public List<Ingredient> GetIngredients()
        {
            return ingredients;
        }

//____________________________________________________________________________________________________________________________\\

        public List<string> GetSteps()
        {
            return steps;
        }

//____________________________________________________________________________________________________________________________\\

        public int GetTotalCalories()
        {
            return ingredients.Sum(ingredient => ingredient.Calories);
        }

//____________________________________________________________________________________________________________________________\\

        public void EnterDetails()
        {
            // This method will be replaced by a UI in WPF
        }

//____________________________________________________________________________________________________________________________\\

        public void DisplayRecipe()
        {
            // This method will be replaced by a UI in WPF
        }

//____________________________________________________________________________________________________________________________\\

        public void ManageRecipe()
        {
            // This method will be replaced by a UI in WPF
        }

//____________________________________________________________________________________________________________________________\\

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

//____________________________________________________________________________________________________________________________\\

        public void ResetQuantity()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

//____________________________________________________________________________________________________________________________\\

        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

//____________________________________________________________________________________________________________________________\\

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

//___________________________________________________END OF FILE_________________________________________________________\\