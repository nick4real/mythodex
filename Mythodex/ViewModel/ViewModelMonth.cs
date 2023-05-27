using Mythodex.Model;
using Mythodex.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Mythodex.ViewModel
{
    public class ViewModelMonth : INotifyPropertyChanged
    {
        private DateTime _selectedDate;
        private Frame _frame;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                if (_frame != null)
                    _frame.Navigate(new Today(value));
            }
        }
        public ViewModelMonth()
        {
            
        }
        public ViewModelMonth(Frame frame)
        {
            _frame = frame;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
