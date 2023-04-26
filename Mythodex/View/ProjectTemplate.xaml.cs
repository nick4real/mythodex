using System.Windows.Controls;
using System.Windows.Input;
using Mythodex.View;
using Mythodex.ViewModel;

namespace Mythodex.View
{
    /// <summary>
    /// Interaction logic for Today.xaml
    /// </summary>
    public partial class ProjectTemplate : Page
    {
        public ProjectTemplate()
        {
            InitializeComponent();

            DataContext = new ViewModelToday();
        }
        private void StackPanel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta > 0)
            {
                scrollViewer.LineLeft();
            }
            else if (e.Delta < 0)
            {
                scrollViewer.LineRight();
            }

            e.Handled = true;
        }
    }
}
