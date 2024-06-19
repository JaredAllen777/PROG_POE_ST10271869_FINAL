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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeManagerPOE
{
    public partial class MainWindow : Window
    {
        public List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow();
            if (addRecipeWindow.ShowDialog() == true)
            {
                recipes.Add(addRecipeWindow.NewRecipe);
                UpdateRecipeList();
            }
        }

        private void DisplayRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void ManageRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                var manageRecipeWindow = new ManageRecipeWindow(selectedRecipe);
                manageRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to manage.");
            }
        }

        private void UpdateRecipeList()
        {
            RecipesListBox.ItemsSource = null;
            RecipesListBox.ItemsSource = recipes;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}