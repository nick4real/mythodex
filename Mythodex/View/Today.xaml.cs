using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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
        public Today(DateTime dateTime)
        {
            InitializeComponent();

            DataContext = new ViewModelToday(dateTime);
        }
    }
}
