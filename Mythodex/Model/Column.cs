using Mythodex.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mythodex.Model
{
    public class Column : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
