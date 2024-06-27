using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//_________________________________________________START OF FILE_____________________________________________________\\

namespace RecipeManagerPOE
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } // Assuming you need a unit property

//___________________________________________________________________________________________________________________\\

        public Ingredient(string name, string foodGroup, int calories, double quantity, string unit)
        {
            Name = name;
            FoodGroup = foodGroup;
            Calories = calories;
            Quantity = quantity;
            Unit = unit;
        }

        public void ResetQuantity()
        {
            Quantity = 1.0; // Assuming default quantity is 1
        }
    }
}

//___________________________________________________END OF FILE_____________________________________________________\\