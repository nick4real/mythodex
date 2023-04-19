using System.Windows;
using System.Windows.Input;
using Mythodex.View;
using Mythodex.ViewModel;

namespace Mythodex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModelMain();
            MainPanelPage.Navigate(new Today());
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
