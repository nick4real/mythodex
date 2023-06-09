using Mythodex.Model;
using Mythodex.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Mythodex.ViewModel
{
    internal class ViewModelMain : INotifyPropertyChanged
    {
        private Frame mainPanelPage;

        private ObservableCollection<ProjectButton> buttonList;
        public ObservableCollection<ProjectButton> ButtonList
        {
            get { return buttonList; }
            set
            {
                buttonList = value;
                OnPropertyChanged(nameof(ButtonList));
            }
        }
        private Color primaryColor;
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set
            {
                primaryColor = value;
                OnPropertyChanged(nameof(PrimaryColor));
            }
        }
        private Color secondaryColor;
        public Color SecondaryColor
        {
            get { return secondaryColor; }
            set
            {
                secondaryColor = value;
                OnPropertyChanged(nameof(SecondaryColor));
            }
        }
        private Color accentColor;
        public Color AccentColor
        {
            get { return accentColor; }
            set
            {
                accentColor = value;
                OnPropertyChanged(nameof(AccentColor));
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

            PrimaryColor = (Color)ColorConverter.ConvertFromString("#f3c9a0");
            SecondaryColor = (Color)ColorConverter.ConvertFromString("#f7e8bb");

            ApplicationPaths.Check();

            frame.Content = new Today();

            ReloadButtons();
        }

        private void ReloadButtons()
        {
            string folderPath = ApplicationPaths.ProjectsFolder;
            ButtonList = new ObservableCollection<ProjectButton>();

            string[] files = Directory.GetFiles(folderPath);

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);

                ProjectButton projectButton = new ProjectButton()
                {
                    ProjectName = fileName
                };

                ButtonList.Add(projectButton);
            }
        }

        #region Commands
        private ICommand themeCommand;
        public ICommand ThemeCommand
        {
            get
            {
                return themeCommand ?? new RelayCommand(param =>
                {
                    switch((string)param)
                    {
                        case "Light":
                            PrimaryColor = (Color)ColorConverter.ConvertFromString("#f3c9a0");
                            SecondaryColor = (Color)ColorConverter.ConvertFromString("#f7e8bb");
                            break;
                        case "Dark":
                            PrimaryColor = (Color)ColorConverter.ConvertFromString("#333333");
                            SecondaryColor = (Color)ColorConverter.ConvertFromString("#4d4d4d");
                            break;
                        case "Emerald":
                            PrimaryColor = (Color)ColorConverter.ConvertFromString("#2e6b41");
                            SecondaryColor = (Color)ColorConverter.ConvertFromString("#558263");
                            break;
                        case "Ruby":
                            PrimaryColor = (Color)ColorConverter.ConvertFromString("#e84a4a");
                            SecondaryColor = (Color)ColorConverter.ConvertFromString("#d86e6e");
                            break; 
                        case "Aquamarine":
                            PrimaryColor = (Color)ColorConverter.ConvertFromString("#297a69");
                            SecondaryColor = (Color)ColorConverter.ConvertFromString("#297a69");
                            break;
                    }
                });
            }
        }
        private ICommand darkThemeCommand;
        public ICommand DarkThemeCommand
        {
            get
            {
                return darkThemeCommand ?? new RelayCommand(param =>
                {
                    PrimaryColor = (Color)ColorConverter.ConvertFromString("PeachPuff");
                    SecondaryColor = (Color)ColorConverter.ConvertFromString("PapayaWhip");
                });
            }
        }
        private ICommand lightThemeCommand;
        public ICommand LightThemeCommand
        {
            get
            {
                return lightThemeCommand ?? new RelayCommand(param =>
                {
                    PrimaryColor = (Color)ColorConverter.ConvertFromString("#2e6b41");
                    SecondaryColor = (Color)ColorConverter.ConvertFromString("#558263");
                });
            }
        }
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
                        mainPanelPage.Content = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
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
                        ReloadButtons();
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
                    var page = mainPanelPage.Content as ProjectTemplate;
                    if (page != null)
                    {
                        page.Cleanup();

                        mainPanelPage.Content = null;

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    mainPanelPage.Navigate(new ProjectTemplate((string)param));
                }));
            }
        }
        private ICommand deleteProjectCommand;
        public ICommand DeleteProjectCommand
        {
            get
            {
                return deleteProjectCommand ?? (deleteProjectCommand = new RelayCommand(param =>
                {
                    var page = mainPanelPage.Content as ProjectTemplate;
                    if (page != null)
                    {
                        page.Cleanup();

                        mainPanelPage.Content = null;

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    TaskDataManager.DeleteProjectFile((string)param);
                    ReloadButtons();
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
