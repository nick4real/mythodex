using System.Windows;
using Mythodex;
  

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

            DataContext = new ViewModel.ViewModelMain();
        }
    }
}
