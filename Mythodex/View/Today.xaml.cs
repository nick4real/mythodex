using System.Windows.Controls;
using Mythodex.View;
using Mythodex.ViewModel;

namespace Mythodex.View
{
    /// <summary>
    /// Interaction logic for Today.xaml
    /// </summary>
    public partial class Today : Page
    {
        public Today()
        {
            InitializeComponent();

            DataContext = new ViewModelToday();
        }
    }
}
