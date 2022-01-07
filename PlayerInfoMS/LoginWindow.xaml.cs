using PlayerInfoMS.Administrators;
using PlayerInfoMS.DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (userList.Exists(x => x.userName == usernameTB.Text) == false)
                MessageBox.Show("Username doesn't exist");
            else
            if (userList.Exists(x => x.userName == usernameTB.Text && x.password == passwordB.Password))
            {
                //Todo Handover the administrator privileges
                Close();
                MessageBox.Show($"logged in as {usernameTB.Text}");
                MainWindow mainWindow = Owner as MainWindow;
                mainWindow.homePageScrollview.Visibility = Visibility.Visible;
                mainWindow.homeLogin.Visibility = Visibility.Collapsed;
                mainWindow.homeLogout.Visibility = Visibility.Visible;
            }    
            else
                MessageBox.Show("Incorrect password");
            
        }
    }
}
