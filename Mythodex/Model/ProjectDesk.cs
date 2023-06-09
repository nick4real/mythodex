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
    public class ProjectDesk : INotifyPropertyChanged
    {
        private string projectName;
        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                OnPropertyChanged(nameof(ProjectName));
            }
        }
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
        public ProjectDesk()
        {
            ColumnCollection = new ObservableCollection<Column>();
        }

        private ICommand addColumn;
        public ICommand AddColumn
        {
            get
            {
                return addColumn ?? (addColumn = new RelayCommand(param =>
                {
                    ColumnCollection.Add(new Column());
                }
                ));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
