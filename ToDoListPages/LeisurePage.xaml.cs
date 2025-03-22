using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for LeisurePage.xaml
    /// </summary>
    public partial class LeisurePage : Page
    {
        public List<string> leisureTasks { get; set; }
        public LeisurePage()
        {
            InitializeComponent();
            leisureTasks = new List<string>();

            LoadTasks();
            

        }

        public void AddLeisureTask(string task)
        {
            leisureTasks.Add(task); // Add the task to the list
            UpdateListBox(); // Manually update the ListBox
        }

        private void LoadTasks()
        {
            if (File.Exists("LeisureTasks.txt"))
            {
                using (StreamReader reader = new StreamReader("LeisureTasks.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        leisureTasks.Add(line); // Add each task to the list
                    }
                }
            }
            UpdateListBox(); // Update the ListBox after loading tasks

        }

        private void UpdateListBox()
        {
            LeisureListBox.Items.Clear(); // Clear the ListBox
            foreach (string task in leisureTasks)
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
                checkBox.Checked += CheckBox_Checked; // Attach the event handler
                LeisureListBox.Items.Add(checkBox); // Add the CheckBox to the ListBox


            }

        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                string task = checkBox.Content.ToString();

                // Show confirmation message
                MessageBoxResult result = MessageBox.Show("Is your task complete?", "Task Completion", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    leisureTasks.Remove(task); // Remove from the list
                    UpdateListBox(); // Refresh the ListBox
                    MoveToCompletedPage(task); // Move the task to Completed Page
                    MessageBox.Show("Task Completed", "Task Completion", MessageBoxButton.OK,MessageBoxImage.Information);
                }
                else
                {
                    checkBox.IsChecked = false; // Uncheck the checkbox if "No" is selected
                }
            }
        }
        private void MoveToCompletedPage(string task)
        {
            // Save to CompletedTasks.txt (optional)
            CompletedPage completedPage = new CompletedPage();
            completedPage.AddCompletedTask(task);
            

            // Remove task from LeisureTasks.txt
            if (File.Exists("LeisureTasks.txt"))
            {
                List<string> tasks = File.ReadAllLines("LeisureTasks.txt").ToList();
                tasks.Remove(task);  // Remove the completed task
                File.WriteAllLines("LeisureTasks.txt", tasks); // Overwrite the file with remaining tasks
            }

            // Refresh the ListBox in LeisurePage
            leisureTasks.Remove(task);
            UpdateListBox();


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
            if (LeisureListBox.SelectedItem != null)
            {
                EditBtn.Visibility = Visibility.Visible;
                PrioritizeBtn.Visibility = Visibility.Visible;
                DeleteBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
