using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mythodex.Model
{
    internal class Task : INotifyPropertyChanged
    {
        private string itemName;
        private int id;
        private string title;
        private string description;
        private Priority priority;
        private string date;
        private bool isCompleted;

        public string ItemName 
        {   
            get { return itemName; } 
            set
            {
                itemName = value;
                OnPropertyChanged("ItemName");
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        enum Priority
        {
            High,
            Standart,
            Low
        }
    }
}
