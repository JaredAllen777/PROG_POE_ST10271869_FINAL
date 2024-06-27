using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

//____________________________________________START OF FILE________________________________________________\\

namespace RecipeManagerPOE
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients;
        private List<string> steps;

//________________________________________________________________________________________________________\\

        public AddRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

//___________________________________________________________________________________________________________\\

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow();
            if (addIngredientWindow.ShowDialog() == true)
            {
                ingredients.Add(addIngredientWindow.NewIngredient);
                IngredientsListBox.ItemsSource = null; // Clear the ItemsSource to refresh
                IngredientsListBox.ItemsSource = ingredients.Select(i => i.Name); // Display only the Name property
            }
        }

//_______________________________________________________________________________________________________________\\

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            var addStepWindow = new AddStepWindow();
            if (addStepWindow.ShowDialog() == true)
            {
                steps.Add(addStepWindow.NewStep);
                StepsListBox.Items.Add(addStepWindow.NewStep);
            }
        }

//___________________________________________________________________________________________________________________\\

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

//______________________________________________________END OF FILE_____________________________________________________\\