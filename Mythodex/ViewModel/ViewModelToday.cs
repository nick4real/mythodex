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
        public ObservableCollection<DragItem> DragItems { get; set; }
        public ObservableCollection<DragItem> DragItems2 { get; set; }
        public ObservableCollection<DragItem> DragItems3 { get; set; }
        public ObservableCollection<DragItem> DragItems4 { get; set; }
        public ViewModelToday()
        {
            DragItems = DragItemGenerator.Next(10);
            DragItems2 = DragItemGenerator.Next(3);
            DragItems3 = DragItemGenerator.Next(3);
            DragItems4 = DragItemGenerator.Next(3);
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
            DragItems.Add(new DragItem { ItemName = Lorem.Sentence(8), ItemDescription = Lorem.Sentence(20), ItemValue = 19 });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
