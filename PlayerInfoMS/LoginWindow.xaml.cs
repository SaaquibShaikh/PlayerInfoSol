using PlayerInfoMS.Administrators;
using PlayerInfoMS.DataBaseAccess;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PlayerInfoMS
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        List<Users> userList = new List<Users>();

        public LoginWindow()
        {
            InitializeComponent();
        }

        //convert string to MD5 hash
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        //login window closed event
        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            mainWindow.homePageScrollview.Visibility = Visibility.Visible;
        }
        // When window is loaded retrive the users data from the database
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FetchData fd = new FetchData();
            userList = fd.getUsers();
        }

        //login button click event
        private void loginBT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            if (userList.Exists(x => x.userName == usernameTB.Text) == false)
                MessageBox.Show("Username doesn't exist");
            else
            if (userList.Exists(x => x.userName == usernameTB.Text && x.password == MD5Hash(passwordB.Password)))
            {
                //Todo Handover the administrator privileges
                Close();
                MessageBox.Show($"logged in as {usernameTB.Text}");
                mainWindow.homePageScrollview.Visibility = Visibility.Visible;
                mainWindow.homeLogin.Visibility = Visibility.Collapsed;
                mainWindow.homeLogout.Visibility = Visibility.Visible;
            }    
            else
                MessageBox.Show("Incorrect password");


            mainWindow.isAdmin = true;

            mainWindow.adminPrevilege();
        }
    }
}
