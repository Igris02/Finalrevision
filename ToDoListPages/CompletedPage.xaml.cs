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
    /// Interaction logic for CompletedPage.xaml
    /// </summary>
    public partial class CompletedPage : Page
    {
        public List<string> completedTasks { get; set; }
        public CompletedPage()
        {
            InitializeComponent();
            completedTasks = new List<string>();
            
           
        }

        public void LoadCompletedTasks()
        {
            CompletedListBox.Items.Clear();

            if (File.Exists("CompletedTasks.txt"))
            {
                using (StreamReader reader = new StreamReader("CompletedTasks.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        completedTasks.Add(line);
                    }
                }
            }

            foreach (string task in completedTasks)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = task, // Set the task text as the CheckBox content
                    IsChecked = true, // Default to unchecked
                    FontSize = 20, // Match the ListBox font size
                    VerticalAlignment = VerticalAlignment.Center, // Center the CheckBox vertically
                    VerticalContentAlignment = VerticalAlignment.Center, // Center the content vertically
                    Height = 30 // Adjust height to match the ListBox item height
                };
                CompletedListBox.Items.Add(checkBox);
                checkBox.IsEnabled = false;
            }
        }

        public void AddCompletedTask(string task)
        {
            completedTasks.Add(task);
            CompletedListBox.Items.Add(task);

            // Save task to file
            using (StreamWriter writer = new StreamWriter("CompletedTasks.txt", true))
            {
                writer.WriteLine(task);
            }
        }

    }
}
