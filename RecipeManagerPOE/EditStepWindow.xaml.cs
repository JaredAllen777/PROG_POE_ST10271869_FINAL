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
    public partial class EditStepWindow : Window
    {
        public string UpdatedStep { get; private set; }
        private string originalStep;

        public EditStepWindow(string step)
        {
            InitializeComponent();
            originalStep = step;

            // Populate UI with existing step data
            StepTextBox.Text = originalStep;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update original step with new data
            originalStep = StepTextBox.Text;

            UpdatedStep = originalStep;
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
//__________________________________________________________________END OF FILE____________________________________________________\\
