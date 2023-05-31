using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mythodex.Model
{
    public class ProjectDesk : INotifyPropertyChanged
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
}
