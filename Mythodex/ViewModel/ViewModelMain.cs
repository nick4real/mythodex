using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mythodex.Model;


namespace Mythodex.ViewModel
{
    internal class ViewModelMain : INotifyPropertyChanged
    {
        public ObservableCollection<DragItem> DragItems { get; set; }
        public ObservableCollection<DragItem> DragItems2 { get; set; }
        public ObservableCollection<DragItem> DragItems3 { get; set; }
        public ObservableCollection<DragItem> DragItems4 { get; set; }
        public ViewModelMain()
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

        private DragItem draggedItem;
        public void StartDrag(DragItem dragItem)
        {
            draggedItem = dragItem;
        }
        public void StartDrop(DragItem dragItem, ObservableCollection<DragItem> list)
        {
            if (draggedItem != null && list != null)
            {
                if (list == DragItems)
                    DragItems.Remove(draggedItem);
                else if (list == DragItems2)
                    DragItems2.Remove(draggedItem);
                else if (list == DragItems3)
                    DragItems3.Remove(draggedItem);
                else if (list == DragItems4)
                    DragItems4.Remove(draggedItem);

                list.Insert(list.IndexOf(dragItem) + 1, draggedItem);
            }

            draggedItem = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
