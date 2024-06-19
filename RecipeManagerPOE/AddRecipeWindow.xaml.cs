using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeManagerPOE
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients;
        private List<string> steps;

        public AddRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow();
            if (addIngredientWindow.ShowDialog() == true)
            {
                ingredients.Add(addIngredientWindow.NewIngredient);
                IngredientsListBox.Items.Add(addIngredientWindow.NewIngredient.Name);
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new AddStepWindow();
            if (addStepWindow.ShowDialog() == true)
            {
                steps.Add(addStepWindow.NewStep);
                StepsListBox.Items.Add(addStepWindow.NewStep);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (string.IsNullOrEmpty(recipeName))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            NewRecipe = new Recipe(recipeName);
            foreach (var ingredient in ingredients)
            {
                NewRecipe.AddIngredient(ingredient);
            }
            foreach (var step in steps)
            {
                NewRecipe.AddStep(step);
            }
            DialogResult = true;
            Close();
        }
    }
}
