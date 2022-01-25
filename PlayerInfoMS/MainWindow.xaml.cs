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
        

        FetchData fetchData = new FetchData();
        DeleteData deleteData = new DeleteData();
        List<CrickPlayer> crickPlayers = new List<CrickPlayer>();
        List<CrickTour> crickTours = new List<CrickTour>();
        List<CrickTeams> crickTeams = new List<CrickTeams>();
        List<CrickTop10> crickTop10 = new List<CrickTop10>();
        List<CrickScore> crickScores = new List<CrickScore>();
        List<CrickTotalScore> crickTotalScores = new List<CrickTotalScore>();



        bool isCrickPlayer = false, isFootPlayer = false;
        public bool isAdmin = false, isTeamUp = false, isTourUp = false, isPlayerUp = false, isScoreUp = false;
        public string oldTeamID, oldTourID, oldPlayerID;
        public string selectedPlayerID, selectedTourID;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        public void adminPrevilege()
        {
            if(isAdmin == true)
            {
                addAchivement.Visibility = Visibility.Visible;
                addCricketPlayer.Visibility = Visibility.Visible;
                addCricketTeam.Visibility = Visibility.Visible;
                addCricketTour.Visibility = Visibility.Visible;
                addFootballPlayer.Visibility = Visibility.Visible;
                addFootballTeam.Visibility = Visibility.Visible;
                addFootballTour.Visibility = Visibility.Visible;
                addScore.Visibility = Visibility.Visible;
                crickTourCM.Focusable = true;
                crickTeamCM.Focusable = true;
                crickPlayerCM.Focusable = true;
                crickScoreCM.Focusable = true;
            }
            else
            {
                addAchivement.Visibility = Visibility.Collapsed;
                addCricketPlayer.Visibility = Visibility.Collapsed;
                addCricketTeam.Visibility = Visibility.Collapsed;
                addCricketTour.Visibility = Visibility.Collapsed;
                addFootballPlayer.Visibility = Visibility.Collapsed;
                addFootballTeam.Visibility = Visibility.Collapsed;
                addFootballTour.Visibility = Visibility.Collapsed;
                addScore.Visibility = Visibility.Collapsed;
                crickTourCM.Focusable = false;
                crickTeamCM.Focusable = false;
                crickPlayerCM.Focusable = false;
                crickScoreCM.Focusable = false;

            }
        }

        public void updateBinding()
        {
            crickTours = fetchData.getCirckTour();
            cricketTourList.ItemsSource = crickTours;

            crickTeams = fetchData.getCirckTeam();
            cricketTeamsList.ItemsSource = crickTeams;

            crickPlayers = fetchData.getCirckPlayer().ToList();
            cricketPlayersList.ItemsSource = crickPlayers;

            crickTop10 = fetchData.getCirckTop10();
            topCricketPlayers.ItemsSource = crickTop10;

            crickScores = fetchData.getCirckScores();
            playerInfoCard.DataContext = crickPlayers.Where(x => x.player_id == selectedPlayerID);
            scoresListBox.ItemsSource = crickScores.Where(x => x.p_id == selectedPlayerID).ToList();

            crickTotalScores = fetchData.getCirckTotalScores();
            totalScoreCard.DataContext = crickTotalScores.Where(x => x.player_id == selectedPlayerID).ToList();
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
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            updateBinding();
        }

        //Navbar tournaments button actions
        private void radioTournaments_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Visible;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            updateBinding();
        }

        //Navbar teams button actions
        private void radioTeams_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Visible;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            updateBinding();
        }

        //Navbar players button actions
        private void radioPlayers_Click(object sender, RoutedEventArgs e)
        {
            homePageScrollview.Visibility = Visibility.Collapsed;
            tourPageScrollview.Visibility = Visibility.Collapsed;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Visible;
            playerInfoScrollview.Visibility = Visibility.Collapsed;
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            updateBinding();
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
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            isAdmin = false;
            adminPrevilege();
            updateBinding();
        }

        private void homeLogout_Click(object sender, RoutedEventArgs e)
        {
            //Todo Remove the administrator privileges from currently logged in user
            isAdmin = false;
            adminPrevilege();

            MessageBoxResult result = MessageBox.Show("Do you want to logout?", "PlayerDB", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    isAdmin = false;
                    adminPrevilege();
                    homeLogin.Visibility = Visibility.Visible;
                    homeLogout.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxResult.No:
                    isAdmin = true;
                    adminPrevilege();
                    break;
            }

            
        }
        
        //Double Clicks
        //topCricketPlayers.SelectedIndex --> returns the selected index of a listboxitem
        //MessageBox.Show($"{emplist.ElementAt(topCricketPlayers.SelectedIndex).Ssn}");
        private void topCrickPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCrickPlayer = true;
            playerInfoScrollview.Visibility = Visibility.Visible;
            homePageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;
            string id = crickTop10.ElementAt(topCricketPlayers.SelectedIndex).player_id;
            selectedPlayerID = id;

            updateBinding();
        }

        //Cricket player list box item select event --> opens the cricket player info page
        private void crickPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCrickPlayer = true;

            playerInfoScrollview.Visibility = Visibility.Visible;
            homePageScrollview.Visibility = Visibility.Collapsed;
            playersPageScrollview.Visibility = Visibility.Collapsed;

            
            string id = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).player_id;
            selectedPlayerID = id;

            updateBinding();
        }
        //Cricket player listbox navigated from teams
        private void crickTeamPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCrickPlayer = true;

            playerInfoScrollview.Visibility = Visibility.Visible;
            crickTeamPlayersLB.Visibility = Visibility.Collapsed;

            ListBoxItem myListBoxItem = (ListBoxItem)(crickTeamPlayersLB.ItemContainerGenerator.ContainerFromItem(crickTeamPlayersLB.Items.CurrentItem));

            // Getting the ContentPresenter of myListBoxItem
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBlock teamCrickPlayerTB = (TextBlock)myDataTemplate.FindName("teamCrickPlayerTB", myContentPresenter);

            
            selectedPlayerID = teamCrickPlayerTB.Text;

            updateBinding();
        }

        //Football player list box item select event --> opens the football player info page
        private void footPlayerLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isFootPlayer = true;
        }

        private void crickTeamLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            isCrickPlayer = true;

            crickTeamPlayersLB.Visibility = Visibility.Visible;
            teamsPageScrollview.Visibility = Visibility.Collapsed;
            string id = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_id;
            crickTeamPlayersLB.ItemsSource = crickPlayers.Where(x => x.team_id == id);
        }
        //delete buttons
        //delete team context menu
        private void delCrickTeamLBI_Click(object sender, RoutedEventArgs e)
        {
            string id = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_id;
            string name = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_name;
            MessageBoxResult result = MessageBox.Show($"Do you want to delete Team-{name}?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    deleteData.delCrickTeam(id);
                    updateBinding();
                    break;
                case MessageBoxResult.No:
                    updateBinding();
                    break;
            }

        }
        //delete tour context menu
        private void delCrickTourLBI_Click(object sender, RoutedEventArgs e)
        {
            string id = crickTours.ElementAt(cricketTourList.SelectedIndex).t_id;
            string name = crickTours.ElementAt(cricketTourList.SelectedIndex).tname;
            MessageBoxResult result = MessageBox.Show($"Do you want to delete Tournament-{name}?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    deleteData.delCrickTour(id);
                    updateBinding();
                    break;
                case MessageBoxResult.No:
                    updateBinding();
                    break;
            }
        }
        //delete player context menu
        private void delCrickPlayerLBI_Click(object sender, RoutedEventArgs e)
        {
            string id = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).player_id;
            string name = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).name;
            MessageBoxResult result = MessageBox.Show($"Do you want to delete player-{name}?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    deleteData.delCrickPlayer(id);
                    updateBinding();
                    break;
                case MessageBoxResult.No:
                    updateBinding();
                    break;
            }
        }
        //delete crickScore context menu
        private void delCrickScoreLBI_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem myListBoxItem = (ListBoxItem)(scoresListBox.ItemContainerGenerator.ContainerFromItem(scoresListBox.Items.CurrentItem));

            // Getting the ContentPresenter of myListBoxItem
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBlock tourIdTB_DT = (TextBlock)myDataTemplate.FindName("tourIdTB", myContentPresenter);
            selectedTourID = tourIdTB_DT.Text;

            MessageBoxResult result = MessageBox.Show($"Do you want to delete score of player-{selectedPlayerID} in tournament-{selectedTourID}?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    deleteData.delCrickScore(selectedPlayerID, selectedTourID);
                    updateBinding();
                    break;
                case MessageBoxResult.No:
                    updateBinding();
                    break;
            }
        }

        //edit buttons
        //team edit context menu click
        private void upCrickTeamLBI_Click(object sender, RoutedEventArgs e)
        {

            isTeamUp = true;

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamInsScroll.Visibility = Visibility.Visible;

            oldTeamID = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_id;
            adminWindow.teamIdText.Text = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_id;
            adminWindow.teamNameText.Text = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_name;
            adminWindow.teamIcoText.Text = crickTeams.ElementAt(cricketTeamsList.SelectedIndex).team_img_path;

            adminWindow.ShowDialog();
        }
        //tour edit context menu click
        private void upCrickTourLBI_Click(object sender, RoutedEventArgs e)
        {
            isTourUp = true;

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.tourInsScroll.Visibility = Visibility.Visible;
            oldTourID = crickTours.ElementAt(cricketTourList.SelectedIndex).t_id;

            adminWindow.tourIdText.Text = crickTours.ElementAt(cricketTourList.SelectedIndex).t_id;
            adminWindow.tourNameText.Text = crickTours.ElementAt(cricketTourList.SelectedIndex).tname;
            adminWindow.startDateText.Text = crickTours.ElementAt(cricketTourList.SelectedIndex).start_date;
            adminWindow.endDateText.Text = crickTours.ElementAt(cricketTourList.SelectedIndex).end_date;
            adminWindow.tourLocationText.Text = crickTours.ElementAt(cricketTourList.SelectedIndex).t_location;

            adminWindow.ShowDialog();
        }
        //player edit context menu click
        private void upCrickPlayerLBI_Click(object sender, RoutedEventArgs e)
        {
            isPlayerUp = true;

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.playerInsScroll.Visibility = Visibility.Visible;
            oldPlayerID = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).player_id;

            adminWindow.playerIdText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).player_id;
            adminWindow.playerTeamIdText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).team_id;
            adminWindow.playerNameText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).name;
            adminWindow.playerImgText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).img_path;
            adminWindow.playerAgeText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).age.ToString();
            adminWindow.playerHeightText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).height.ToString();
            adminWindow.playerWeightText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).weight.ToString();
            adminWindow.playerGenderText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).gender;
            adminWindow.playerRoleText.Text = crickPlayers.ElementAt(cricketPlayersList.SelectedIndex).p_role;

            adminWindow.ShowDialog();
        }
        //crickScore edit context menu click
        private void upCrickScoreLBI_Click(object sender, RoutedEventArgs e)
        {
            isScoreUp = true;

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.crickScoreInsScroll.Visibility = Visibility.Visible;
            
            ListBoxItem myListBoxItem = (ListBoxItem)(scoresListBox.ItemContainerGenerator.ContainerFromItem(scoresListBox.Items.CurrentItem));

            // Getting the ContentPresenter of myListBoxItem
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBlock tourIdTB_DT = (TextBlock)myDataTemplate.FindName("tourIdTB", myContentPresenter);
            selectedTourID = tourIdTB_DT.Text;

            TextBlock matchesTB_DT = (TextBlock)myDataTemplate.FindName("matchesTB", myContentPresenter);
            TextBlock runsTB_DT = (TextBlock)myDataTemplate.FindName("runsTB", myContentPresenter);
            TextBlock wicketsTB_DT = (TextBlock)myDataTemplate.FindName("wicketsTB", myContentPresenter);
            TextBlock maidensTB_DT = (TextBlock)myDataTemplate.FindName("maidensTB", myContentPresenter);
            TextBlock sixesTB_DT = (TextBlock)myDataTemplate.FindName("sixesTB", myContentPresenter);
            TextBlock foursTB_DT = (TextBlock)myDataTemplate.FindName("foursTB", myContentPresenter);
            TextBlock centuriesTB_DT = (TextBlock)myDataTemplate.FindName("centuriesTB", myContentPresenter);
            TextBlock fiftiesTB_DT = (TextBlock)myDataTemplate.FindName("fiftiesTB", myContentPresenter);

            adminWindow.crickMatchesText.Text = matchesTB_DT.Text;
            adminWindow.runsText.Text = runsTB_DT.Text;
            adminWindow.wicketsText.Text = wicketsTB_DT.Text;
            adminWindow.maidensText.Text = maidensTB_DT.Text;
            adminWindow.sixesText.Text = sixesTB_DT.Text;
            adminWindow.foursText.Text = foursTB_DT.Text;
            adminWindow.centuriesText.Text = centuriesTB_DT.Text;
            adminWindow.fiftiesText.Text = fiftiesTB_DT.Text;


            adminWindow.ShowDialog();
        }

        //view buttons
        //context menu view click
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            playerInfoScrollview.Visibility = Visibility.Visible;
            homePageScrollview.Visibility = Visibility.Collapsed;
            string id = crickTop10.ElementAt(topCricketPlayers.SelectedIndex).player_id;
            playerInfoScrollview.DataContext = crickPlayers.Where(x => x.player_id == id);
        }
        //add buttons
        //Add buttons in Players page
        private void addCricketPlayer_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            adminWindow.teamSelectScroll.Visibility = Visibility.Visible;
            adminWindow.teamSelectLB.ItemsSource = crickTeams;
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


        //Add buttons in Player Info page
        private void addScore_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Owner = this;
            if (isCrickPlayer)
            {
                adminWindow.tourSelectScroll.Visibility = Visibility.Visible;
                adminWindow.tourSelectLB.ItemsSource = crickTours;
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