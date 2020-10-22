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

namespace GAI.Fragments
{
    /// <summary>
    /// Логика взаимодействия для EditDriverPage.xaml
    /// </summary>
    public partial class EditDriverFragment : Page
    {
        private int driverId;
        public EditDriverFragment(int driverId)
        {
            this.driverId = driverId;
        }

        
    }
}
