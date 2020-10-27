using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GAI.Utils;

namespace GAI.Fragments
{
    /// <summary>
    /// Логика взаимодействия для AuthFragment.xaml
    /// </summary>
    public partial class AuthFragment : Page
    {
        public user? CurrentUser = null; // Why? IDK, maybe will be used...
        public AuthFragment()
        {
            InitializeComponent();
        }

        private async void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser = await FindUser(UsernameTextBox.Text, PasswordTextBox.Password);
            if (CurrentUser != null)
            { // Authintification is successful! 
                App.CurrentUser = CurrentUser; // Declared to get info about authenticated user from any code place
                NavigationService.Navigate(new MainMenu()); // Going to MainMenu 'cause authentification is successful
            }
            else // CurrentUser is null so authentification is not successful
            {
                MessageBox.Show("Пользователь с таким именем и паролем не найден.");
            }
        }

        private async Task<user?> FindUser(string username, string password)
        {
            string PasswordHash = Utils.Utils.HashStringMD5(password); // Hash darling, hash!
            try
            {
                user? foundUser = await DBHolder.DB.users
                    .Where(u => u.username == username && u.password_hash == PasswordHash)
                    .FirstAsync();
                return foundUser;
            }
            catch (Exception)
            {
                return null;
            }
            
            
        }
    }
}
