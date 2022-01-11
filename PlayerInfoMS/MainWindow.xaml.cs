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
        List<Employee> emplist2 = new List<Employee>();
        bool isCrikPlayer = false, isFootPlayer = false;

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
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
        }

        //Navbar tournaments button actions
        private void radioTournaments_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Visible;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
        }

        //Navbar teams button actions
        private void radioTeams_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Visible;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
        }

        //Navbar players button actions
        private void radioPlayers_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Visible;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
        }

        private void homeLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Owner = this;
            homePageScrollview.Visibility = Visibility.Collapsed;

            login.ShowDialog();
        }

        //Main window loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Visible;
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
            FetchData empdata = new FetchData();
            emplist = empdata.employees();

            topCricketPlayers.ItemsSource = emplist;
        }

        private void homeLogout_Click(object sender, RoutedEventArgs e)
        {
            //Todo Remove the administrator privileges from currently logged in user
        }

        //topCricketPlayers.SelectedIndex --> returns the selected index of a listboxitem
        //MessageBox.Show($"{emplist.ElementAt(topCricketPlayers.SelectedIndex).Ssn}");
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isFootPlayer = true;
            playerInfoScrollview.Visibility = Visibility.Visible;
            homePageScrollview.Visibility = Visibility.Collapsed;
            MessageBox.Show($"{emplist.ElementAt(topCricketPlayers.SelectedIndex).Ssn}");
            playerInfoScrollview.DataContext = emplist;
        }

        //context menu view click
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            playerInfoScrollview.Visibility = Visibility.Visible;
            homePageScrollview.Visibility = Visibility.Collapsed;
            MessageBox.Show($"{emplist.ElementAt(topCricketPlayers.SelectedIndex).Ssn}");
            playerInfoScrollview.DataContext = emplist;
        }

        //Add buttons in Players page
        private void addCricketPlayer_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamSelectScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        private void addFootballPlayer_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamSelectScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        //Add buttons in Teams page
        private void addCricketTeam_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamInsScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        private void addFootballTeam_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamInsScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        //Add buttons in Tournament page
        private void addCricketTour_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.tourInsScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        private void addFootballTour_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.tourInsScroll.Visibility = Visibility.Visible;
            adminWindow.ShowDialog();
        }

        //Cricket player list box item select event --> opens the cricket player info page
        private void crickPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCrikPlayer = true;
        }

        //Football player list box item select event --> opens the football player info page
        private void footPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isFootPlayer = true;
        }

        //Add buttons in Player Info page
        private void addScore_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            if (isCrikPlayer)
            {
                adminWindow.crickScoreInsScroll.Visibility = Visibility.Visible;
                adminWindow.ShowDialog();
            }
            else
            if (isFootPlayer)
            {
                adminWindow.footScoreInsScroll.Visibility = Visibility.Visible;
                adminWindow.ShowDialog();
            }
        }
  
    }
}