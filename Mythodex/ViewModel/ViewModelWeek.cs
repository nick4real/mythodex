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
    internal class ViewModelWeek : INotifyPropertyChanged
    {
        public ObservableCollection<DragItem> MondayItems { get; set; }
        public ObservableCollection<DragItem> TuesdayItems { get; set; }
        public ObservableCollection<DragItem> WednesdayItems { get; set; }
        public ObservableCollection<DragItem> ThursdayItems { get; set; }
        public ObservableCollection<DragItem> FridayItems { get; set; }
        public ObservableCollection<DragItem> SaturdayItems { get; set; }
        public ObservableCollection<DragItem> SundayItems { get; set; }
        public ViewModelWeek()
        {
            MondayItems = DragItemGenerator.Next(3);
            TuesdayItems = DragItemGenerator.Next(3);
            WednesdayItems = DragItemGenerator.Next(3);
            ThursdayItems = DragItemGenerator.Next(3);
            FridayItems = DragItemGenerator.Next(3);
            SaturdayItems = DragItemGenerator.Next(3);
            SundayItems = DragItemGenerator.Next(3);
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

        private void NewTask_Click(object sender, EventArgs e)
        {
            ObservableCollection<DragItem> temp = new ObservableCollection<DragItem>();
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
            temp.Add(new DragItem { ItemName = Lorem.Sentence(8), ItemDescription = Lorem.Sentence(20), ItemValue = 19 });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
