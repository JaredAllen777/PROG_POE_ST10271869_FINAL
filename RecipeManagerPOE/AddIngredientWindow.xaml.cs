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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = IngredientNameTextBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter an ingredient name.");
                return;
            }

            if (!double.TryParse(QuantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            string unit = UnitTextBox.Text;
            if (string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("Please enter a unit.");
                return;
            }

            if (!int.TryParse(CaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Please enter a valid calorie amount.");
                return;
            }

            string foodGroup = FoodGroupTextBox.Text;
            if (string.IsNullOrEmpty(foodGroup))
            {
                MessageBox.Show("Please enter a food group.");
                return;
            }

            NewIngredient = new Ingredient
            {
                Name = name,
                Quantity = quantity,
                Unit = unit,
                Calories = calories,
                FoodGroup = foodGroup
            };
            DialogResult = true;
            Close();
        }
    }
}
