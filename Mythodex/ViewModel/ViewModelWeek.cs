﻿using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Mythodex.ViewModel
{
    internal class ViewModelWeek : INotifyPropertyChanged
    {
        private DispatcherTimer timer;

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

        #region ObservableCollection<Task> WeekItems
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
        #endregion
        
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
        
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? new RelayCommand(param =>
                {
                    SaveAllItems();
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
                    SaveAllItems();
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
                    Task task = (Task)param;
                    if (MondayItems.Contains(task))
                    {
                        MondayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(MondayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 1));
                    }
                    else if (TuesdayItems.Contains(task))
                    {
                        TuesdayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(TuesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 2));
                    }
                    else if (WednesdayItems.Contains(task))
                    {
                        WednesdayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(WednesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 3));
                    }
                    else if (ThursdayItems.Contains(task))
                    {
                        ThursdayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(ThursdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 4));
                    }
                    else if (FridayItems.Contains(task))
                    {
                        FridayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(FridayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 5));
                    }
                    else if (SaturdayItems.Contains(task))
                    {
                        SaturdayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(SaturdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 6));
                    }
                    else if (SundayItems.Contains(task))
                    {
                        SundayItems.Remove(task);
                        TaskDataManager.SaveTaskCollection(SundayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 7));
                    }
                    SaveAllItems();
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
            SaveAllItems();

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

            LoadAllItems();
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
            collection.Add(TaskGenerator.Next());
            TaskDataManager.SaveTaskCollection(collection, DateConverter.GetWeekDate(FirstDayWeekDate, dateTime));
        }
        private void SaveAllItems()
        {
            TaskDataManager.SaveTaskCollection(MondayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 1));
            TaskDataManager.SaveTaskCollection(TuesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 2));
            TaskDataManager.SaveTaskCollection(WednesdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 3));
            TaskDataManager.SaveTaskCollection(ThursdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 4));
            TaskDataManager.SaveTaskCollection(FridayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 5));
            TaskDataManager.SaveTaskCollection(SaturdayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 6));
            TaskDataManager.SaveTaskCollection(SundayItems, DateConverter.GetWeekDate(FirstDayWeekDate, 7));
        }
        private void LoadAllItems()
        {
            MondayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 1));
            TuesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 2));
            WednesdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 3));
            ThursdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 4));
            FridayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 5));
            SaturdayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 6));
            SundayItems = TaskDataManager.LoadTaskCollection(DateConverter.GetWeekDate(FirstDayWeekDate, 7));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
