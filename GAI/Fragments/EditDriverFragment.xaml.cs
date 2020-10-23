using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace GAI.Fragments
{
    /// <summary>
    /// Логика взаимодействия для EditDriverPage.xaml
    /// </summary>
    public partial class EditDriverFragment : Page
    {
        private int driverId;
        public driver currentDriver
        { get; set; }
        

        public EditDriverFragment(int driverId)
        {
            InitializeComponent();
            this.driverId = driverId;
            LoadDriver();
            DataContext = this;

        }

        private void Fragment_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void LoadDriver()
        {
            currentDriver = (from driver in DBHolder.DB.drivers
                             where driver.id == driverId
                             select driver).First();
            string avatar_path = AppDomain.CurrentDomain.BaseDirectory + "photo/" + currentDriver.photo;
            //FirstNameField.Text = avatar_path;
            Avatar.Source = new BitmapImage(new Uri(avatar_path));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DBHolder.DB.drivers.AddOrUpdate<driver>(currentDriver);
            DBHolder.DB.SaveChanges();
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            //MessageBox.Show(currentDriver.first_name);
        }
    }
}
