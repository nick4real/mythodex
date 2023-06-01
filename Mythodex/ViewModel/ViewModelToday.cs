using Mythodex.Model;
using LoremNET;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.Specialized;

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
        private ObservableCollection<Task> dayItems;
        public ObservableCollection<Task> DayItems
        {
            get { return dayItems; }
            set
            {
                if (dayItems != value)
                {
                    dayItems = value;
                    OnPropertyChanged(nameof(DayItems));
                }
            }
        }

        public ViewModelToday()
        {
            SelectedDate = DateTime.Today;

            DayItems = TaskDataManager.LoadTaskCollection(SelectedDate);

            DayItems.CollectionChanged += DayCollectionChanged;

            
        }
        public ViewModelToday(DateTime dateTime)
        {
            SelectedDate = dateTime;

            DayItems = TaskDataManager.LoadTaskCollection(SelectedDate);

            DayItems.CollectionChanged += DayCollectionChanged;
        }
        private void DayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, SelectedDate);
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? new RelayCommand(param =>
                {
                    TaskDataManager.SaveTaskCollection(DayItems, SelectedDate);
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
                    TaskDataManager.SaveTaskCollection(DayItems, SelectedDate);
                });
            }
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
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? new RelayCommand(param =>
                {
                    DayItems.Remove((Task)param);
                });
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
            TaskDataManager.SaveTaskCollection(DayItems, SelectedDate);

            if ((string)sender == "1")
                SelectedDate = SelectedDate.AddDays(1);
            else SelectedDate = SelectedDate.AddDays(-1);

            DayItems = TaskDataManager.LoadTaskCollection(SelectedDate);
        }
        private void NewTask_Click(object sender, EventArgs e)
        {
            DayItems.Add(TaskGenerator.Next());
            TaskDataManager.SaveTaskCollection(DayItems, SelectedDate);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
