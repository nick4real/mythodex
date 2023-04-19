using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Mythodex.ViewModel
{
    internal class ViewModelMain : INotifyPropertyChanged
    {
        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(
                        param => CloseButton_Click(param, EventArgs.Empty),
                        param => true
                    );
                }
                return closeCommand;
            }
        }

        private ICommand maximizeCommand;
        public ICommand MaximizeCommand
        {
            get
            {
                if (maximizeCommand == null)
                {
                    maximizeCommand = new RelayCommand(
                        param => MaximizeButton_Click(param, EventArgs.Empty),
                        param => true
                    );
                }
                return maximizeCommand;
            }
        }

        private ICommand minimizeCommand;
        public ICommand MinimizeCommand
        {
            get
            {
                if (minimizeCommand == null)
                {
                    minimizeCommand = new RelayCommand(
                        param => MinimizeButton_Click(param, EventArgs.Empty),
                        param => true
                    );
                }
                return minimizeCommand;
            }
        }

        private ICommand dragWindowCommand;
        public ICommand DragWindowCommand
        {
            get
            {
                return new RelayCommand(param => Application.Current.MainWindow.DragMove());
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        public void DragWindowLeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
