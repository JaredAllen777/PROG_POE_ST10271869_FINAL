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

namespace RecipeManagerPOE
{
    public partial class ManageRecipeWindow : Window
    {
        private Recipe recipe;

        public ManageRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;

            // Set the recipe details
            RecipeNameTextBox.Text = recipe.Name;
            foreach (var ingredient in recipe.GetIngredients())
            {
                IngredientsListBox.Items.Add(ingredient.Name);
            }
            foreach (var step in recipe.GetSteps())
            {
                StepsListBox.Items.Add(step);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
