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
    public partial class AddIngredientWindow : Window
    {
        public Ingredient NewIngredient { get; private set; }

        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = IngredientNameTextBox.Text;
                string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem)?.Content.ToString();
                int calories = int.Parse(CaloriesTextBox.Text);
                double quantity = double.Parse(QuantityTextBox.Text);
                string unit = UnitTextBox.Text;

                NewIngredient = new Ingredient(name, foodGroup, calories, quantity, unit);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text;
            string foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem)?.Content.ToString();
            int calories = int.Parse(CaloriesTextBox.Text);
            double quantity = double.Parse(QuantityTextBox.Text);
            string unit = UnitTextBox.Text;

            NewIngredient = new Ingredient(name, foodGroup, calories, quantity, unit);

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}

