using Mythodex.Model;
using LoremNET;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace Mythodex.ViewModel
{
    internal class ViewModelToday : INotifyPropertyChanged
    {
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
        public ObservableCollection<Task> DragItems { get; set; }

        public ViewModelToday()
        {
            DragItems = TaskLipsumGenerator.Next(10);

            SelectedDate = DateTime.Now;
        }
        public ViewModelToday(DateTime dateTime)
        {
            DragItems = TaskLipsumGenerator.Next(10);

            SelectedDate = dateTime;
        }

        private ICommand newTaskCommand;
        public ICommand NewTaskCommand
        {
            get
            {
                if (newTaskCommand == null)
                {
                    newTaskCommand = new RelayCommand(
                        param => NewTask_Click(param, EventArgs.Empty),
                        param => true
                    );
                }
                return newTaskCommand;
            }
        }
        private ICommand dateSwitchCommand;
        public ICommand DateSwitchCommand
        {
            get
            {
                if (dateSwitchCommand == null)
                {
                    dateSwitchCommand = new RelayCommand(
                        param => DateSwitch_Click(param, EventArgs.Empty),
                        param => true
                    );
                }
                return dateSwitchCommand;
            }
        }
        private void DateSwitch_Click(object sender, EventArgs e)
        {
            if ((string)sender == "1")
                SelectedDate = SelectedDate.AddDays(1);
            else SelectedDate = SelectedDate.AddDays(-1);
        }
        private void NewTask_Click(object sender, EventArgs e)
        {
            DragItems.Add(TaskLipsumGenerator.Next());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
