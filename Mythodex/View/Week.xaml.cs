using System.Windows.Controls;
using System.Windows.Input;
using Mythodex.View;
using Mythodex.ViewModel;

namespace Mythodex.View
{
    /// <summary>
    /// Interaction logic for Today.xaml
    /// </summary>
    public partial class Week : Page
    {
        public Week()
        {
            InitializeComponent();

            DataContext = new ViewModelWeek();
        }
        private void StackPanel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta > 0)
            {
                scrollViewer.LineLeft();
                scrollViewer.LineLeft();
            }
            else if (e.Delta < 0)
            {
                scrollViewer.LineRight();
                scrollViewer.LineRight();
            }

            e.Handled = true;
        }
    }
}
