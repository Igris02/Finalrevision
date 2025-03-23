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

namespace Finalrevision
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void SubmitFeedback_Click_1(object sender, RoutedEventArgs e)
        {
            string feedback = FeedbackTextBox.Text;

            if (string.IsNullOrWhiteSpace(feedback))
            {
                MessageBox.Show("Please enter your feedback.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save or process the feedback (e.g., store in a file, database, or send to an API)
            MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();


            FeedbackTextBox.Clear();
        }
    }
}
