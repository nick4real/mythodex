using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace Mythodex.ViewModel
{
    internal class ViewModelMonth : INotifyPropertyChanged
    {
        public ObservableCollection<DragItem> DragItems { get; set; }
        public ObservableCollection<DragItem> DragItems2 { get; set; }
        public ObservableCollection<DragItem> DragItems3 { get; set; }
        public ObservableCollection<DragItem> DragItems4 { get; set; }
        public ViewModelMonth()
        {
            DragItems = new ObservableCollection<DragItem>
            {
                new DragItem { ItemName = "Alpha", ItemDescription = "Typical Desc", ItemValue = 13},
                new DragItem { ItemName = "Beta", ItemDescription = "Basic Desc", ItemValue = 15},
                new DragItem { ItemName = "Delta", ItemDescription = "Common Desc", ItemValue = 19}
            };
            DragItems2 = new ObservableCollection<DragItem>
            {
                new DragItem { ItemName = "Beta", ItemDescription = "Basic Desc", ItemValue = 15},
                new DragItem { ItemName = "Alpha", ItemDescription = "Typical Desc", ItemValue = 13},
                new DragItem { ItemName = "Delta", ItemDescription = "Common Desc", ItemValue = 19}
            };
            DragItems3 = new ObservableCollection<DragItem>
            {
                new DragItem { ItemName = "Alpha", ItemDescription = "Typical Desc", ItemValue = 13},
                new DragItem { ItemName = "Delta", ItemDescription = "Common Desc", ItemValue = 19},
                new DragItem { ItemName = "Beta", ItemDescription = "Basic Desc", ItemValue = 15}
            };
            DragItems4 = new ObservableCollection<DragItem>
            {
                new DragItem { ItemName = "Delta", ItemDescription = "Common Desc", ItemValue = 19},
                new DragItem { ItemName = "Alpha", ItemDescription = "Typical Desc", ItemValue = 13},
                new DragItem { ItemName = "Beta", ItemDescription = "Basic Desc", ItemValue = 15}
            };
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
            DragItems.Add(new DragItem { ItemName = "Delta", ItemDescription = "Common Desc", ItemValue = 19 });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
