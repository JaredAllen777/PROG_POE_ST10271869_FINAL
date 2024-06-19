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
    public partial class AddStepWindow : Window
    {
        public string NewStep { get; private set; }

        public AddStepWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string step = StepTextBox.Text;
            if (string.IsNullOrEmpty(step))
            {
                MessageBox.Show("Please enter a step.");
                return;
            }

            NewStep = step;
            DialogResult = true;
            Close();
        }
    }
}