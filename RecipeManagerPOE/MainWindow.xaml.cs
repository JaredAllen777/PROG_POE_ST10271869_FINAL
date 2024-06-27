using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

//_______________________________________START OF FILE___________________________________________________\\

namespace RecipeManagerPOE
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

//_________________________________________________________________________________________________________\\

        private void LoadRecipesFromFile()
        {
            string filePath = "recipes.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);
                UpdateRecipeList();
            }
        }

//___________________________________________________________________________________________________________\\

        private void SaveRecipesToFile()
        {
            string filePath = "recipes.json";
            string json = JsonConvert.SerializeObject(recipes, Newtonsoft.Json.Formatting.Indented); 
            File.WriteAllText(filePath, json);
        }
//__________________________________________________________________________________________________________\\

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                recipes.Add(addRecipeWindow.NewRecipe);
                UpdateRecipeList();
            }
        }

//____________________________________________________________________________________________________________\\

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                DisplayRecipeDetails(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Please select a recipe to display.");
            }
        }

//______________________________________________________________________________________________________________\\

        private void ManageRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                var manageRecipeWindow = new ManageRecipeWindow(selectedRecipe);
                manageRecipeWindow.ShowDialog();
                if (manageRecipeWindow.IsDeleted)
                {
                    recipes.Remove(selectedRecipe);
                }
                UpdateRecipeList();
            }
            else
            {
                MessageBox.Show("Please select a recipe to manage.");
            }
        }

//________________________________________________________________________________________________________________\\

        private void UpdateRecipeList()
        {
            RecipesListBox.ItemsSource = null;
            RecipesListBox.ItemsSource = recipes;
        }

//__________________________________________________________________________________________________________________\\

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //____________________________________________________________________________________________________________________\\

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = SearchIngredientTextBox.Text.ToLower();
            string selectedFoodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!int.TryParse(MaxCaloriesTextBox.Text, out int maxCalories))
            {
                maxCalories = int.MaxValue; // No calorie limit if the input is invalid
            }

            var filteredRecipes = recipes.Where(recipe =>
                (string.IsNullOrEmpty(ingredientName) || recipe.GetIngredients().Any(ingredient => ingredient.Name.ToLower().Contains(ingredientName))) &&
                (selectedFoodGroup == "All Food Groups" || string.IsNullOrEmpty(selectedFoodGroup) || recipe.FoodGroup == selectedFoodGroup) &&
                recipe.GetTotalCalories() <= maxCalories).ToList();

            RecipesListBox.ItemsSource = null;
            RecipesListBox.ItemsSource = filteredRecipes;
        }
        //______________________________________________________________________________________________________\\

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            RecipesListBox.ItemsSource = null;
            RecipesListBox.ItemsSource = recipes;
        }


//_______________________________________________________________________________________________________\\

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Enter Ingredient Name" || textBox.Text == "Enter Max Calories")
            {
                textBox.Text = "";
            }
        }

//________________________________________________________________________________________________________\\

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "SearchIngredientTextBox")
                {
                    textBox.Text = "Enter Ingredient Name";
                }
                else if (textBox.Name == "MaxCaloriesTextBox")
                {
                    textBox.Text = "Enter Max Calories";
                }
            }
        }

//____________________________________________________________________________________________________________\\

        private void DisplayRecipeDetails(Recipe recipe)
        {
            RecipeNameLabel.Content = recipe.Name;

            // Display ingredients
            IngredientsListBox.ItemsSource = recipe.GetIngredients().Select(i => i.Name).ToList();

            // Display steps
            StepsListBox.ItemsSource = recipe.GetSteps();
        }

//_______________________________________________________________________________________________________________\\

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                DisplayRecipeDetails(selectedRecipe);
            }
        }
    }
}

//_________________________________________________________END OF FILE_________________________________________________________________\\