using System.Windows;
using System.Windows.Interactivity;
using Mythodex.ViewModel;

namespace Mythodex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ViewMain : Window
    {
        public ViewMain()
        {
            InitializeComponent();

            DataContext = new ViewModelMain();
        }
    }
}
