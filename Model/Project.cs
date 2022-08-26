using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace TasksManager.Model
{
    class Project : INotifyPropertyChanged
    {
        private Guid projectId;
        private string projectName;
        private int projectPercentage;

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
        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }
        public int ProjectPercentage
        {
            get
            {
                return projectPercentage;
            }
            private set
            {
                projectPercentage = value;
            }
        }

        public Project(string name)
        {
            projectId = Guid.NewGuid();
            projectName = name;
            projectPercentage = 0;
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
