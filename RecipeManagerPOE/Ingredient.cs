using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerPOE
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        public double OriginalQuantity { get; set; }  // Store original quantity

        public void EnterDetails()
        {
            // This method will be replaced by a UI in WPF
        }

        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;  // Reset to original quantity
        }
    }
}