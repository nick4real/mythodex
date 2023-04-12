using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mythodex.Model
{
    internal class DragItem : INotifyPropertyChanged
    {
        private string itemName;
        private string itemDescription;
        private int itemValue;

        public string ItemName 
        {   
            get { return itemName; } 
            set
            {
                itemName = value;
                OnPropertyChanged("ItemName");
            } 
        }
        public string ItemDescription
        {
            get { return itemDescription; }
            set
            {
                itemDescription = value;
                OnPropertyChanged("ItemDescription");
            }
        }
        public int ItemValue
        {
            get { return itemValue; }
            set
            {
                itemValue = value;
                OnPropertyChanged("ItemValue");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
