using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mythodex.Model
{
    internal class ProjectDesk : INotifyPropertyChanged
    {
        private ObservableCollection<Column> columnCollection;
        public ObservableCollection<Column> ColumnCollection
        {
            get { return columnCollection; }
            set
            {
                columnCollection = value;
                OnPropertyChanged(nameof(ColumnCollection));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    internal class Column : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
