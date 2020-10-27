using GAI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAI.Fragments
{
    /// <summary>
    /// Логика взаимодействия для DriversFragment.xaml
    /// </summary>
    public partial class DriversFragment : Page
    {
        

        public DriversFragment()
        {
            InitializeComponent();
            
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var getDriversQuery = from driver in DBHolder.DB.drivers select driver;
            driversDataGrid.ItemsSource = getDriversQuery.ToList();

            

            if (System.Windows.Application.Current.Resources.Contains("DriverFields"))
            {
                var fieldHeaders = (ObjectCollection)Application.Current.Resources["DriverFields"];
                int[] hidden_fields = { 6, 7, 8, 9, 10, 12, 13, 14 };
                for (int i = 0; i <= driversDataGrid.Columns.Count - 1; i++)
                {
                    if (hidden_fields.Contains(i))
                    {
                        driversDataGrid.Columns[i].Visibility = Visibility.Hidden;
                    }
                    driversDataGrid.Columns[i].Header = fieldHeaders[i] as string;
                }
                
            }

        }

        private void SelectDriverButton_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = driversDataGrid.SelectedCells[0];
            var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            //MessageBox.Show(content.ToString());
            //I wanna die
            //So... Continuing...
            GoToEditDriverPage(int.Parse(content));
        }

        private void ScrollViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var cellInfo = driversDataGrid.SelectedCells[0];
            var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            GoToEditDriverPage(int.Parse(content));
        }

        private void GoToEditDriverPage(int driverId)
        {
            this.NavigationService.Navigate(new EditDriverFragment(driverId));
        }
    }
}
