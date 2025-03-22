using Finalrevision.ToDoListPages;
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
using System.Windows.Shapes;

namespace Finalrevision
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public LeisurePage leisure;
        public ErrandsPage errands;
        public SchoolProjectPage schoolProject;
        public Assignmentpage assignment;
        public SchoolEventPage schoolEvent;
        public WorkProjectPage workProject;
        public MeetingPage meeting;
        public HomeWindow()
        {
            InitializeComponent();
            leisure = new LeisurePage();
            errands = new ErrandsPage();
            schoolProject = new SchoolProjectPage();
            assignment = new Assignmentpage();
            schoolEvent = new SchoolEventPage();
            workProject = new WorkProjectPage();
            meeting = new MeetingPage();
        }

        private void LeisureBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = leisure;
        }

        private void ErrandBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content= errands;
        }

        private void SchoolProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = schoolProject;
        }

        private void AssigmentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = assignment;
        }

        private void SchoolEventBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = schoolEvent;
        }

        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = workProject;
        }

        private void MeetingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = meeting;
        }

        private void CompleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTasksBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;

                

            }
        }

        private void AddtoLeisureBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;

  
                using (StreamWriter writer = new StreamWriter("LeisureTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                leisure.AddLeisureTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }

        

        private void AddtoErrandBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("ErrandTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                errands.AddErrandTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }
        private void AddtoSchoolProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("SchoolProjectTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                schoolProject.AddSchoolProjectTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }
        private void AddtoAssignmentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("AssignmentTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                assignment.AddAssignmentTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }

        private void AddtoSchoolEventBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("SchoolEventTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                schoolEvent.AddSchoolEventTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }
        private void AddtoWorkProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("WorkProjectTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                workProject.AddWorkProjectTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }

        private void AddtoMeetingBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TaskTextBox.Text))
            {
                MessageBox.Show("Error");
                return;
            }
            else
            {
                AddtoLeisureBtn.Visibility = Visibility.Visible;
                AddtoErrandBtn.Visibility = Visibility.Visible;
                AddtoSchoolProjectBtn.Visibility = Visibility.Visible;
                AddtoAssignmentBtn.Visibility = Visibility.Visible;
                AddtoSchoolEventBtn.Visibility = Visibility.Visible;
                AddtoWorkProjectBtn.Visibility = Visibility.Visible;
                AddtoMeetingBtn.Visibility = Visibility.Visible;


                using (StreamWriter writer = new StreamWriter("MeetingTasks.txt", true))
                {
                    writer.WriteLine(TaskTextBox.Text);
                }

                meeting.AddMeetingTask(TaskTextBox.Text);
                TaskTextBox.Text = string.Empty;

            }
        }

        
    }
}
