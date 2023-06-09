using Mythodex.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Mythodex.Model
{
    public class Column : INotifyPropertyChanged
    {
        public string ProjectName;
        public ProjectDesk ParentProject;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private ObservableCollection<Task> taskCollection;
        public ObservableCollection<Task> TaskCollection
        {
            get { return taskCollection; }
            set
            {
                taskCollection = value;
                OnPropertyChanged(nameof(TaskCollection));
            }
        }
        public Column()
        {
            TaskCollection = new ObservableCollection<Task>();
            Name = "Колонка";
        }
        private ICommand newTaskCommand;
        public ICommand NewTaskCommand
        {
            get
            {
                return newTaskCommand ?? new RelayCommand(param =>
                {
                    TaskCollection.Add(TaskGenerator.Next());
                });
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? new RelayCommand(param =>
                {
                    Task task = (Task)param;

                    TaskCollection.Remove(task);
                });
            }
        }
        private ICommand changePriorityCommand;
        public ICommand ChangePriorityCommand
        {
            get
            {
                return changePriorityCommand ?? new RelayCommand(param =>
                {
                    var task = (Task)param;
                    if (task.Priority == 3)
                        task.Priority = 1;
                    else
                        task.Priority++;
                });
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
