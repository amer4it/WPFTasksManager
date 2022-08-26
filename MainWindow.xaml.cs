using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TasksManager.Model;
using TasksManager.ModelView;

namespace TasksManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            ProjectViewModel VM = (ProjectViewModel)this.DataContext;

            if (TaskTxt.Text.Trim().Length != 0 && ProjectsLst.SelectedItem != null)
            {
                VM.Tasks.Add(new Model.Task(TaskTxt.Text, (Guid)ProjectsLst.SelectedValue));
                MessageBox.Show("A new task has been added.");
            }
            else if (TaskTxt.Text.Trim().Length == 0)
                MessageBox.Show("Task Textbox is empty.");            
            else 
                MessageBox.Show("Project Listitem is not selected.");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            ProjectViewModel VM = (ProjectViewModel) this.DataContext;

            if (TaskIdTxt.Text.Trim() != "")
            {
                Task selectedTask = VM.Tasks.Where(t => t.TaskId.ToString() == TaskIdTxt.Text.Trim()).First();
                selectedTask.TaskName = TaskNameTxt.Text;
                if (TaskStatusLst.SelectedIndex == 0)
                {
                    selectedTask.TaskStatus = Status.New;
                    selectedTask.TaskPercentage = 0;
                }
                else if (TaskStatusLst.SelectedIndex == 1)
                {
                    selectedTask.TaskStatus = Status.InProgress;
                    selectedTask.TaskPercentage = 50;
                }
                else
                {
                    selectedTask.TaskStatus = Status.Finished;
                    selectedTask.TaskPercentage = 100;
                }

                ProjectNameTxt.Text = VM.Projects.Where(p => p.ProjectId == selectedTask.ProjectId).First().ProjectName;

                ProjectprogressTxt.Text = (VM.Tasks.Where(t => t.ProjectId == selectedTask.ProjectId).Sum(t => t.TaskPercentage) / VM.Tasks.Where(t => t.ProjectId == selectedTask.ProjectId).Count()).ToString() + "%";
            }
            else
            {
                MessageBox.Show("Please select a task from the tasks list first.");
            }
        }

        private void TasksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjectViewModel VM = (ProjectViewModel)this.DataContext;
            Task selectedTask = VM.Tasks.Where(t => t.TaskId.ToString() == TaskIdTxt.Text.Trim()).First();

            ProjectNameTxt.Text = VM.Projects.Where(p => p.ProjectId == selectedTask.ProjectId).First().ProjectName;
            ProjectprogressTxt.Text = (VM.Tasks.Where(t => t.ProjectId == selectedTask.ProjectId).Sum(t => t.TaskPercentage) / VM.Tasks.Where(t => t.ProjectId == selectedTask.ProjectId).Count()).ToString() + "%";

        }

        private void AddProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            ProjectViewModel VM = (ProjectViewModel)this.DataContext;

            if (ProjectTxt.Text.Trim().Length != 0)
            {
                VM.Projects.Add(new Model.Project(ProjectTxt.Text));
                MessageBox.Show("A new project has been added.");
            }
            else
                MessageBox.Show("Project Textbox is empty.");
        }
    }
}
