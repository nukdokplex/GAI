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
        public StartFragment()
        {
            InitializeComponent();
            
        }

        public void setHeaderTitle(string title)
        {
            try
            {
                DefaultHeader header = (HeaderContainer.Content as DefaultHeader);
                header.HeaderTitle.Text = title;
            }
            catch (Exception)
            {

            }
        }

        private void NavigationContainer_Navigated(object sender, NavigationEventArgs e)
        {
            if (NavigationContainer.CanGoBack)
            {
                try
                {
                    DefaultHeader header = (HeaderContainer.Content as DefaultHeader);
                    header.HeaderBackButton.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {
                    
                }
            }
            else
            {
                try
                {
                    DefaultHeader header = (HeaderContainer.Content as DefaultHeader);
                    header.HeaderBackButton.Visibility = Visibility.Collapsed;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
