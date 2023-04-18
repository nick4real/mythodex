using System.Windows;
using System.Windows.Interactivity;
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
    }
}
