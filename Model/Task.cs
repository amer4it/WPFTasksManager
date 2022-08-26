using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace TasksManager.Model
{
    enum Status
    { 
        New,InProgress,Finished
    }

    class Task : INotifyPropertyChanged
    {
        private Guid taskId;
        private string taskName;
        private int taskPercentage;
        private Status taskStatus;
        private int taskStatusValue; 
        private Guid projectId;

        public Guid TaskId
        {
            get
            {
                return taskId;
            }
            set
            {
                taskId = value;
                OnPropertyChanged("TaskId");
            }
        }
        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        public Status TaskStatus
        {
            get
            {
                return taskStatus;
            }
            set
            {
                taskStatus = value;
                OnPropertyChanged("TaskStatus");
            }
        }

        public int TaskStatusValue
        {
            get
            {
                return taskStatusValue;
            }
            set
            {
                taskStatusValue = value;
                OnPropertyChanged("TaskStatusValue");
            }
        }

        public int TaskPercentage
        {
            get
            {
                return taskPercentage;
            }
            set
            {
                taskPercentage = value;
                OnPropertyChanged("TaskPercentage");
            }
        }

        public Guid ProjectId
        {
            get
            {
                return projectId;
            }
            set
            {
                projectId = value;
                OnPropertyChanged("ProjectId");
            }
        }

        public Task(string name,Guid id)
        {
            taskId = Guid.NewGuid();
            taskName = name;
            taskStatus = Status.New;
            taskStatusValue = 0;
            projectId = id;
            taskPercentage = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
