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

namespace Mythodex.ViewModel
{
    internal class ViewModelWeek : INotifyPropertyChanged
    {
        public string saveFolder = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mythodex"), "Dates");
        
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
        public ObservableCollection<Task> MondayItems { get; set; }
        public ObservableCollection<Task> TuesdayItems { get; set; }
        public ObservableCollection<Task> WednesdayItems { get; set; }
        public ObservableCollection<Task> ThursdayItems { get; set; }
        public ObservableCollection<Task> FridayItems { get; set; }
        public ObservableCollection<Task> SaturdayItems { get; set; }
        public ObservableCollection<Task> SundayItems { get; set; }
        public ViewModelWeek()
        {
            FirstDayWeekDate = DateConverter.GetWeekDate(1);
            LastDayWeekDate = DateConverter.GetWeekDate(7);

            //MondayItems = TaskLipsumGenerator.Next(3);
            //TaskDataManager.SaveTaskCollection(MondayItems, FirstDayWeekDate);

            MondayItems = TaskDataManager.LoadTaskCollection(FirstDayWeekDate);

            TuesdayItems = TaskLipsumGenerator.Next(3);
            WednesdayItems = TaskLipsumGenerator.Next(3);
            ThursdayItems = TaskLipsumGenerator.Next(3);
            FridayItems = TaskLipsumGenerator.Next(3);
            SaturdayItems = TaskLipsumGenerator.Next(3);
            SundayItems = TaskLipsumGenerator.Next(3);

            
            var temp = LastDayWeekDate.ToString();

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
            {
                FirstDayWeekDate = FirstDayWeekDate.AddDays(7);
                LastDayWeekDate = LastDayWeekDate.AddDays(7);
            }
            else
            {
                FirstDayWeekDate = FirstDayWeekDate.AddDays(-7);
                LastDayWeekDate = LastDayWeekDate.AddDays(-7);
            }
        }

        private void NewTask_Click(object sender, EventArgs e)
        {
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            switch ((string)sender)
            {
                case "MondayItems":
                    temp = MondayItems;
                    break;
                case "TuesdayItems":
                    temp = TuesdayItems;
                    break;
                case "WednesdayItems":
                    temp = WednesdayItems;
                    break;
                case "ThursdayItems":
                    temp = ThursdayItems;
                    break;
                case "FridayItems":
                    temp = FridayItems;
                    break;
                case "SaturdayItems":
                    temp = SaturdayItems;
                    break;
                case "SundayItems":
                    temp = SundayItems;
                    break;
            }
            temp.Add(TaskLipsumGenerator.Next());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
