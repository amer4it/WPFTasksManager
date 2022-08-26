using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;
using TasksManager.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace TasksManager.ModelView
{
    class ProjectViewModel
    {
        public enum Status
        {
            New, InProgress, Finished
        }

        private ObservableCollection<Project> _ProjectsList;
        private ObservableCollection<Task> _TaskList;

        public ProjectViewModel()
        {
            _ProjectsList = new ObservableCollection<Project>();
            _TaskList = new ObservableCollection<Task>();

        }

        public ObservableCollection<Project> Projects
        {
            get { return _ProjectsList; }
            set { _ProjectsList = value;
                NotifyPropertyChanged("Projects");
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get { return _TaskList; }
            set { _TaskList = value;
                NotifyPropertyChanged("Tasks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }        
    }
}
