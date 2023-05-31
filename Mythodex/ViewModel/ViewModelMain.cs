using Mythodex.Model;
using Mythodex.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Mythodex.ViewModel
{
    internal class ViewModelMain : INotifyPropertyChanged
    {
        private Frame mainPanelPage;

        private ObservableCollection<ButtonCommand> buttonList;
        public ObservableCollection<ButtonCommand> ButtonList
        {
            get { return buttonList; }
            set
            {
                buttonList = value;
                OnPropertyChanged(nameof(ButtonList));
            }
        }
        
        private string newProjectTextBox;
        public string NewProjectTextBox
        {
            get
            {
                return newProjectTextBox;
            }
            set
            {
                newProjectTextBox = value;
                OnPropertyChanged(nameof(NewProjectTextBox));
            }
        }
        public ViewModelMain(Frame frame)
        {
            mainPanelPage = frame;
            mainPanelPage.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            ApplicationPaths.Check();

            frame.Content = new Today();
        }

        #region Commands
        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(
                        param => CloseButton_Click(param, EventArgs.Empty)
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
                        if (viewPath == "Month")
                            mainPanelPage.Navigate(new Month(mainPanelPage));
                        else
                        {

                        var uri = new Uri($"View/{viewPath}.xaml", UriKind.Relative);
                        mainPanelPage.NavigationService.Navigate(uri);
                        }
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
                    if (!String.IsNullOrWhiteSpace(NewProjectTextBox))
                    {
                        TaskDataManager.NewProjectFile(NewProjectTextBox);
                    }
                }
                )) ;
            }
        }
        private ICommand openProjectCommand;
        public ICommand OpenProjectCommand
        {
            get
            {
                return openProjectCommand ?? (openProjectCommand = new RelayCommand(param =>
                {
                    var uri = new Uri($"View/ProjectTemplate.xaml", UriKind.Relative);
                    mainPanelPage.NavigationService.Navigate(uri);
                }));
            }
        }
        #endregion

        #region Events
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
        #endregion

        #region INotifyPropertyChanged realisation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
