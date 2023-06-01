using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Mythodex.Model
{
    [Serializable]
    public class Task : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private int priority;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public int Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged(nameof(Priority));
                OnPropertyChanged(nameof(PriorityColor));
            }
        }
        public SolidColorBrush PriorityColor
        {
            get
            {
                switch (Priority)
                {
                    case 1:
                        return new SolidColorBrush(Colors.Green);
                    case 2:
                        return new SolidColorBrush(Colors.Yellow);
                    case 3:
                        return new SolidColorBrush(Colors.Red);
                    default:
                        return new SolidColorBrush(Colors.Black);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}