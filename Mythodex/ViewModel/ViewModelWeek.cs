using Mythodex.Model;
using LoremNET;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Collections.Specialized;

namespace Mythodex.ViewModel
{
    internal class ViewModelWeek : INotifyPropertyChanged
    {
        private DateTime _firstDayWeekDate;
        public DateTime FirstDayWeekDate
        {
            get { return _firstDayWeekDate; }
            set
            {
                _firstDayWeekDate = value;
                OnPropertyChanged(nameof(FirstDayWeekDate));
            }
        }
        private DateTime _lastDayWeekDate;
        public DateTime LastDayWeekDate
        {
            get { return _lastDayWeekDate; }
            set
            {
                _lastDayWeekDate = value;
                OnPropertyChanged(nameof(LastDayWeekDate));
            }
        }

        private ObservableCollection<Task> mondayItems;
        public ObservableCollection<Task> MondayItems
        {
            get { return mondayItems; }
            set
            {
                if (mondayItems != value)
                {
                    mondayItems = value;
                    OnPropertyChanged(nameof(MondayItems));
                }
            }
        }
        private ObservableCollection<Task> tuesdayItems;
        public ObservableCollection<Task> TuesdayItems
        {
            get { return tuesdayItems; }
            set
            {
                if (tuesdayItems != value)
                {
                    tuesdayItems = value;
                    OnPropertyChanged(nameof(TuesdayItems));
                }
            }
        }
        private ObservableCollection<Task> wednesdayItems;
        public ObservableCollection<Task> WednesdayItems
        {
            get { return wednesdayItems; }
            set
            {
                if (wednesdayItems != value)
                {
                    wednesdayItems = value;
                    OnPropertyChanged(nameof(WednesdayItems));
                }
            }
        }
        private ObservableCollection<Task> thursdayItems;
        public ObservableCollection<Task> ThursdayItems
        {
            get { return thursdayItems; }
            set
            {
                if (thursdayItems != value)
                {
                    thursdayItems = value;
                    OnPropertyChanged(nameof(ThursdayItems));
                }
            }
        }
        private ObservableCollection<Task> fridayItems;
        public ObservableCollection<Task> FridayItems
        {
            get { return fridayItems; }
            set
            {
                if (fridayItems != value)
                {
                    fridayItems = value;
                    OnPropertyChanged(nameof(FridayItems));
                }
            }
        }
        private ObservableCollection<Task> saturdayItems;
        public ObservableCollection<Task> SaturdayItems
        {
            get { return saturdayItems; }
            set
            {
                if (saturdayItems != value)
                {
                    saturdayItems = value;
                    OnPropertyChanged(nameof(SaturdayItems));
                }
            }
        }
        private ObservableCollection<Task> sundayItems;
        public ObservableCollection<Task> SundayItems
        {
            get { return sundayItems; }
            set
            {
                if (sundayItems != value)
                {
                    sundayItems = value;
                    OnPropertyChanged(nameof(SundayItems));
                }
            }
        }

        public ViewModelWeek()
        {
            DateTime today = DateTime.Today;
            
            FirstDayWeekDate = DateConverter.GetWeekDate(today, 1);
            LastDayWeekDate = DateConverter.GetWeekDate(today, 7);

            MondayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 1));
            TuesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 2));
            WednesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 3));
            ThursdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 4));
            FridayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 5));
            SaturdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 6));
            SundayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(today, 7));

            MondayItems.CollectionChanged += MondayCollectionChanged;
            TuesdayItems.CollectionChanged += TuesdayCollectionChanged;
            WednesdayItems.CollectionChanged += WednesdayCollectionChanged;
            ThursdayItems.CollectionChanged += ThursdayCollectionChanged;
            FridayItems.CollectionChanged += FridayCollectionChanged;
            SaturdayItems.CollectionChanged += SaturdayCollectionChanged;
            SundayItems.CollectionChanged += SundayCollectionChanged;
        }
        #region CollectionChangedEvent
        private void MondayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 1));
        }
        private void TuesdayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 2));
        }
        private void WednesdayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 3));
        }

        private void ThursdayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 4));
        }

        private void FridayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 5));
        }

        private void SaturdayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 6));
        }

        private void SundayCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            TaskDataManager.SaveTaskCollection((ObservableCollection<Task>)sender, DateConverter.GetWeekDate(FirstDayWeekDate, 7));
        }
        #endregion

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
            TaskDataManager.SaveTaskCollection(MondayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 1));
            TaskDataManager.SaveTaskCollection(TuesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 2));
            TaskDataManager.SaveTaskCollection(WednesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 3));
            TaskDataManager.SaveTaskCollection(ThursdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 4));
            TaskDataManager.SaveTaskCollection(FridayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 5));
            TaskDataManager.SaveTaskCollection(SaturdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 6));
            TaskDataManager.SaveTaskCollection(SundayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 7));

            if ((string)sender == "1")
            {
                FirstDayWeekDate = FirstDayWeekDate.AddDays(7);
                LastDayWeekDate = LastDayWeekDate.AddDays(7);
            }
            else
            {
                FirstDayWeekDate = FirstDayWeekDate.AddDays(-7);
                LastDayWeekDate = LastDayWeekDate.AddDays(-7);
            }

            MondayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 1));
            TuesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 2));
            WednesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 3));
            ThursdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 4));
            FridayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 5));
            SaturdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 6));
            SundayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 7));
        }
        private void NewTask_Click(object sender, EventArgs e)
        {
            ObservableCollection<Task> collection = new ObservableCollection<Task>();
            int dateTime = 0;
            switch ((string)sender)
            {
                case "MondayItems":
                    collection = MondayItems;
                    dateTime = 1;
                    break;
                case "TuesdayItems":
                    collection = TuesdayItems;
                    dateTime = 2;
                    break;
                case "WednesdayItems":
                    collection = WednesdayItems;
                    dateTime = 3;
                    break;
                case "ThursdayItems":
                    collection = ThursdayItems;
                    dateTime = 4;
                    break;
                case "FridayItems":
                    collection = FridayItems;
                    dateTime = 5;
                    break;
                case "SaturdayItems":
                    collection = SaturdayItems;
                    dateTime = 6;
                    break;
                case "SundayItems":
                    collection = SundayItems;
                    dateTime = 7;
                    break;
            }
            collection.Add(TaskLipsumGenerator.Next());
            TaskDataManager.SaveTaskCollection(collection, DateConverter.GetWeekDate(FirstDayWeekDate, dateTime));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
