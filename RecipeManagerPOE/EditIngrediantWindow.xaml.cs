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

//_________________________________________________________________START OF FILE________________________________________________________________________________\\

namespace RecipeManagerPOE
{
    public partial class EditIngredientWindow : Window
    {
        public Ingredient UpdatedIngredient { get; private set; }
        private Ingredient originalIngredient;

//______________________________________________________________________________________________________________________________________________________________\\

        public EditIngredientWindow(Ingredient ingredient)
        {
            InitializeComponent();
            originalIngredient = ingredient;

            // Populate UI with existing ingredient data
            IngredientNameTextBox.Text = originalIngredient.Name;
        }

//______________________________________________________________________________________________________________________________________________________________\\

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update original ingredient with new data
            originalIngredient.Name = IngredientNameTextBox.Text;
            // Update other properties similarly

            UpdatedIngredient = originalIngredient;
            DialogResult = true;
            Close();
        }

//______________________________________________________________________________________________________________________________________________________________\\

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

//_________________________________________________________________END OF FILE_________________________________________________________________________________\\
