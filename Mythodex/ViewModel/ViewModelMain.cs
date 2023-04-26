using Mythodex.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Mythodex.ViewModel
{
    internal class ViewModelMain : INotifyPropertyChanged
    {
        private Frame mainPanelPage;
        public ViewModelMain(Frame frame)
        {
            mainPanelPage = frame;
            mainPanelPage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
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

        private ICommand openPageCommand;
        public ICommand OpenPageCommand
        {
            get
            {
                return openPageCommand ?? (openPageCommand = new RelayCommand(param =>
                {
                    if (param != null && param is string viewPath)
                    {
                        var uri = new Uri($"View/{viewPath}.xaml", UriKind.Relative);
                        mainPanelPage.NavigationService.Navigate(uri);
                    }
                }));
            }
        }

        private ICommand newProjectCommand;
        public ICommand NewProjectCommand
        {
            get
            {
                return newProjectCommand ?? (newProjectCommand = new RelayCommand(param =>
                {
                    if (param != null && param is string viewPath)
                    {
                        var uri = new Uri($"View/{viewPath}.xaml", UriKind.Relative);
                        mainPanelPage.NavigationService.Navigate(uri);
                    }
                }));
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            var WindowState = Application.Current.MainWindow.WindowState;
            if (WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
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
