using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//____________________________________________________________________START OF FILE_____________________________________________________________________________\\

namespace RecipeManagerPOE
{
    public partial class ManageRecipeWindow : Window
    {
        private Recipe recipe;
        public bool IsDeleted { get; private set; } = false;

        public ManageRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DisplayRecipeDetails();
        }

//______________________________________________________________________________________________________________________________________________________________\\

        private void DisplayRecipeDetails()
        {
            RecipeNameTextBox.Text = recipe.Name;

            IngredientsListBox.ItemsSource = null;
            IngredientsListBox.ItemsSource = recipe.GetIngredients().Select(i => i.Name).ToList();

            StepsListBox.ItemsSource = null;
            StepsListBox.ItemsSource = recipe.GetSteps();
        }

//______________________________________________________________________________________________________________________________________________________________\\

        private void EditRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var editRecipeWindow = new EditRecipeWindow(recipe);
            if (editRecipeWindow.ShowDialog() == true)
            {
                recipe = editRecipeWindow.UpdatedRecipe;
                DisplayRecipeDetails();
            }
        }

//_____________________________________________________________________________________________________________________________________________________________\\

        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                IsDeleted = true;
                Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
//_________________________________________________________________END OF FILE_________________________________________________________________________________\\