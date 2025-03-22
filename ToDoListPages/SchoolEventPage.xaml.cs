using System;
using System.Collections.Generic;
using System.IO;
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

namespace Finalrevision.ToDoListPages
{
    /// <summary>
    /// Interaction logic for SchoolEventPage.xaml
    /// </summary>
    public partial class SchoolEventPage : Page
    {
        public List<string> schoolEventTasks { get; set; }
        public SchoolEventPage()
        {
            InitializeComponent();
            schoolEventTasks = new List<string>();

            LoadTasks();

        }

        public void AddSchoolEventTask(string task)
        {
            schoolEventTasks.Add(task); // Add the task to the list
            UpdateListBox(); // Manually update the ListBox
        }

        private void LoadTasks()
        {
            if (File.Exists("SchoolEventTasks.txt"))
            {
                using (StreamReader reader = new StreamReader("SchoolEventTasks.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        schoolEventTasks.Add(line); // Add each task to the list
                    }
                }
            }
            UpdateListBox(); // Update the ListBox after loading tasks

        }

        private void UpdateListBox()
        {
            SchoolEventListBox.Items.Clear(); // Clear the ListBox
            foreach (string task in schoolEventTasks)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = task, // Set the task text as the CheckBox content
                    IsChecked = false, // Default to unchecked
                    FontSize = 20, // Match the ListBox font size
                    VerticalAlignment = VerticalAlignment.Center, // Center the CheckBox vertically
                    VerticalContentAlignment = VerticalAlignment.Center, // Center the content vertically
                    Height = 30 // Adjust height to match the ListBox item height
                };

                SchoolEventListBox.Items.Add(checkBox); // Add the CheckBox to the ListBox


            }

        }



        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditBtn.Visibility = Visibility.Hidden;
            PrioritizeBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
        }

        private void PrioritizeBtn_Click(object sender, RoutedEventArgs e)
        {
            EditBtn.Visibility = Visibility.Hidden;
            PrioritizeBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            EditBtn.Visibility = Visibility.Hidden;
            PrioritizeBtn.Visibility = Visibility.Hidden;
            DeleteBtn.Visibility = Visibility.Hidden;
        }

        private void LeisureListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SchoolEventListBox.SelectedItem != null)
            {
                EditBtn.Visibility = Visibility.Visible;
                PrioritizeBtn.Visibility = Visibility.Visible;
                DeleteBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
