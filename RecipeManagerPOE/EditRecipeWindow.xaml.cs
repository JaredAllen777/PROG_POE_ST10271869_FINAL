using System;
using System.Linq;
using System.Windows;

//______________________________________________START OF FILE___________________________________________\\

namespace RecipeManagerPOE

    {
        public partial class EditRecipeWindow : Window
        {
            public Recipe UpdatedRecipe { get; private set; }
            private Recipe originalRecipe;

            public EditRecipeWindow(Recipe recipe)
            {
                InitializeComponent();
                originalRecipe = recipe;
                UpdatedRecipe = new Recipe
                {
                    Name = recipe.Name,
                    FoodGroup = recipe.FoodGroup,
                    // Copy other properties if needed
                };

                RecipeNameTextBox.Text = UpdatedRecipe.Name;
                IngredientsListBox.ItemsSource = originalRecipe.GetIngredients().Select(i => i.Name).ToList();
                StepsListBox.ItemsSource = originalRecipe.GetSteps().ToList();
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                UpdatedRecipe.Name = RecipeNameTextBox.Text;
                UpdatedRecipe.ClearRecipe();
                foreach (var ingredient in IngredientsListBox.Items)
                {
                    UpdatedRecipe.AddIngredient(originalRecipe.GetIngredients().First(i => i.Name == ingredient.ToString()));
                }
                foreach (var step in StepsListBox.Items)
                {
                    UpdatedRecipe.AddStep(step.ToString());
                }
                DialogResult = true;
                Close();
            }

            private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
            {
                var addIngredientWindow = new AddIngredientWindow();
                if (addIngredientWindow.ShowDialog() == true)
                {
                    originalRecipe.AddIngredient(addIngredientWindow.NewIngredient);
                    IngredientsListBox.ItemsSource = originalRecipe.GetIngredients().Select(i => i.Name).ToList();
                }
            }

            private void EditIngredientButton_Click(object sender, RoutedEventArgs e)
            {
                if (IngredientsListBox.SelectedItem is string selectedIngredientName)
                {
                    var selectedIngredient = originalRecipe.GetIngredients().First(i => i.Name == selectedIngredientName);
                    var editIngredientWindow = new EditIngredientWindow(selectedIngredient);
                    if (editIngredientWindow.ShowDialog() == true)
                    {
                        var updatedIngredient = editIngredientWindow.UpdatedIngredient;
                        var index = originalRecipe.GetIngredients().FindIndex(i => i.Name == selectedIngredientName);
                        originalRecipe.GetIngredients()[index] = updatedIngredient;
                        IngredientsListBox.ItemsSource = originalRecipe.GetIngredients().Select(i => i.Name).ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select an ingredient to edit.");
                }
            }

            private void DeleteIngredientButton_Click(object sender, RoutedEventArgs e)
            {
                if (IngredientsListBox.SelectedItem is string selectedIngredientName)
                {
                    var selectedIngredient = originalRecipe.GetIngredients().First(i => i.Name == selectedIngredientName);
                    originalRecipe.GetIngredients().Remove(selectedIngredient);
                    IngredientsListBox.ItemsSource = originalRecipe.GetIngredients().Select(i => i.Name).ToList();
                }
                else
                {
                    MessageBox.Show("Please select an ingredient to delete.");
                }
            }

            private void AddStepButton_Click(object sender, RoutedEventArgs e)
            {
                var addStepWindow = new AddStepWindow();
                if (addStepWindow.ShowDialog() == true)
                {
                    originalRecipe.AddStep(addStepWindow.NewStep);
                    StepsListBox.ItemsSource = originalRecipe.GetSteps().ToList();
                }
            }

            private void EditStepButton_Click(object sender, RoutedEventArgs e)
            {
                if (StepsListBox.SelectedItem is string selectedStep)
                {
                    var editStepWindow = new EditStepWindow(selectedStep);
                    if (editStepWindow.ShowDialog() == true)
                    {
                        var updatedStep = editStepWindow.UpdatedStep;
                        var index = originalRecipe.GetSteps().IndexOf(selectedStep);
                        originalRecipe.GetSteps()[index] = updatedStep;
                        StepsListBox.ItemsSource = originalRecipe.GetSteps().ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a step to edit.");
                }
            }

            private void DeleteStepButton_Click(object sender, RoutedEventArgs e)
            {
                if (StepsListBox.SelectedItem is string selectedStep)
                {
                    originalRecipe.GetSteps().Remove(selectedStep);
                    StepsListBox.ItemsSource = originalRecipe.GetSteps().ToList();
                }
                else
                {
                    MessageBox.Show("Please select a step to delete.");
                }
            }
        }
    }
//______________________________________________END OF FILE___________________________________________\\