using PlayerInfoMS.Cricket;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayerInfoMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> emplist = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Exit on window close button
        private void windowClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // Right click to minimize
        private void windowClose_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        //Navbar Home button actions
        private void radioHome_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Visible;
        }

        //Navbar tournaments button actions
        private void radioTournaments_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
        }

        //Navbar teams button actions
        private void radioTeams_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
        }

        //Navbar login button actions
        private void radioPlayers_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
        }

        private void homeLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Owner = this;
            homePageScrollview.Visibility = Visibility.Collapsed;

            login.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FetchData empdata = new FetchData();
            emplist = empdata.employees();

            topCricketPlayers.ItemsSource = emplist;
        }

        private void homeLogout_Click(object sender, RoutedEventArgs e)
        {
            //Todo Remove the administrator privileges from currently logged in user
        }
    }
}