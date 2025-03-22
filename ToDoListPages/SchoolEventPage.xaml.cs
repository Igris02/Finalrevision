﻿using System;
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

                checkBox.Checked += CheckBox_Checked; // Attach the event handler
                SchoolEventListBox.Items.Add(checkBox); // Add the CheckBox to the ListBox


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
                    schoolEventTasks.Remove(task); // Remove from the list
                    UpdateListBox(); // Refresh the ListBox
                    MoveToCompletedPage(task); // Move the task to Completed Page
                    MessageBox.Show("Task Completed", "Task Completion", MessageBoxButton.OK, MessageBoxImage.Information);
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
            if (File.Exists("SchoolEventTasks.txt"))
            {
                List<string> tasks = File.ReadAllLines("SchoolEventTasks.txt").ToList();
                tasks.Remove(task);  // Remove the completed task
                File.WriteAllLines("SchoolEventTasks.txt", tasks); // Overwrite the file with remaining tasks
            }

            // Refresh the ListBox in LeisurePage
            schoolEventTasks.Remove(task);
            UpdateListBox();


        }



        private string selectedTask; // Store the selected task for editing

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SchoolEventListBox.SelectedItem is CheckBox selectedCheckBox)
            {
                selectedTask = selectedCheckBox.Content.ToString(); // Store the selected task
                EditTextBox.Text = selectedTask; // Populate the TextBox
                EditTextBox.Visibility = Visibility.Visible;
                SaveEditBtn.Visibility = Visibility.Visible;
                background.Visibility = Visibility.Visible;

                // Hide other buttons
                EditBtn.Visibility = Visibility.Hidden;
                PrioritizeBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
                DetailsBtn.Visibility = Visibility.Hidden;
            }
        }
        private void SaveEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EditTextBox.Text) && schoolEventTasks.Contains(selectedTask))
            {
                int index = schoolEventTasks.IndexOf(selectedTask);
                schoolEventTasks[index] = EditTextBox.Text; // Update the task

                UpdateListBox(); // Refresh ListBox

                // Save changes to file
                File.WriteAllLines("SchoolEventTasks.txt", schoolEventTasks);

                // Hide edit controls
                EditTextBox.Visibility = Visibility.Hidden;
                SaveEditBtn.Visibility = Visibility.Hidden;
                background.Visibility = Visibility.Hidden;
            }
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

        private void SchoolEventListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
