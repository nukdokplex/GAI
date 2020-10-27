using GAI.Fragments.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAI
{
    /// <summary>
    /// Логика взаимодействия для StartFragment.xaml
    /// </summary>
    public partial class StartFragment : Page
    {

        public static DefaultHeader MainHeader;
        public StartFragment()
        {
            InitializeComponent();
            MainHeader = new DefaultHeader();
            HeaderContainer.Navigate(MainHeader);
        }

        public static void setHeaderTitle(string title)
        {
            MainHeader.HeaderTitle.Text = title;
        }

        private void NavigationContainer_Navigated(object sender, NavigationEventArgs e)
        {
            if (NavigationContainer.CanGoBack)
            {
                MainHeader.HeaderBackButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainHeader.HeaderBackButton.Visibility = Visibility.Visible;
            }
        }
    }
}
