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
using System.Windows.Shapes;

namespace PlayerInfoMS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        string selectedTourId;

        public AdminWindow()
        {
            InitializeComponent();
        }

        private void doneTeams_Click(object sender, RoutedEventArgs e)
        {
            PutData insTeam = new PutData();
            UpdateData upTeam = new UpdateData();
            MainWindow mainWindow = Owner as MainWindow;

            string id = teamIdText.Text, name = teamNameText.Text, img = teamIcoText.Text;
            
            if(id == "")
                id = null;

            if ( name == "")
               name = null;

            if ( img == "")
                img = "Icons/group.png";

            if(mainWindow.isTeamUp == true)
                upTeam.updateCrickTeams(mainWindow.oldTeamID, id, name, img);
            else
                insTeam.insertCrickTeams(id, name, img);


            mainWindow.updateBinding();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = Owner as MainWindow;
            mainWindow.updateBinding();
        }

        private void doneTour_Click(object sender, RoutedEventArgs e)
        {
            PutData insTour = new PutData();
            UpdateData upTour = new UpdateData();
            MainWindow mainWindow = Owner as MainWindow;

            string id = tourIdText.Text, name = tourNameText.Text, sDate = startDateText.Text, eData = endDateText.Text, loc = tourLocationText.Text;

            if (id == "")
                id = null;

            if (name == "")
                name = null;

            if (sDate == "")
                sDate = null;

            if (eData == "")
                eData = null;

            if (loc == "")
                loc = null;

            if (mainWindow.isTourUp == true)
                upTour.updateCrickTour(mainWindow.oldTourID, id, name, sDate, eData, loc);
            else
                insTour.insertCrickTour(id, name, sDate, eData, loc);


            mainWindow.updateBinding();
        }

        private void donePlayers_Click(object sender, RoutedEventArgs e)
        {
            PutData insPlayer= new PutData();
            UpdateData upPlayer = new UpdateData();
            MainWindow mainWindow = Owner as MainWindow;

            string pid = playerIdText.Text, teamId = playerTeamIdText.Text,
                pname = playerNameText.Text, imgpath = playerImgText.Text,
                 page = playerAgeText.Text, pheight = playerHeightText.Text, pweight = playerWeightText.Text, 
                pgender = playerGenderText.Text, prole = playerRoleText.Text;
            int iage;
            float fheight, fweight;

            if (pid == "")
                pid = null;

            if (teamId == "")
                teamId = null;

            if (pname == "")
                pname = null;

            if (imgpath == "")
                imgpath = "Icons/default.png";

            if (page == "")
                iage = 0;
            else
                iage = int.Parse(page);

            if (pheight == "")
                fheight = 0;
            else
                fheight = float.Parse(pheight);

            if (pweight == "")
                fweight = 0;
            else
                fweight = float.Parse(pweight);

            if (pgender == "")
                pgender = null;

            if (prole == "")
                prole = null;

            if (mainWindow.isPlayerUp == true)
                upPlayer.updateCrickPlayer(mainWindow.oldPlayerID, pid, teamId, pname, imgpath, iage, fheight, fweight, pgender, prole);
            else
                insPlayer.insertCrickPlayer(pid, teamId, pname, imgpath, iage, fheight, fweight, pgender, prole);


            mainWindow.updateBinding();
        }

        private void doneCrickScore_Click(object sender, RoutedEventArgs e)
        {
            PutData insScore = new PutData();
            UpdateData upScore = new UpdateData();
            MainWindow mainWindow = Owner as MainWindow;

            string strMatchesPlayed = crickMatchesText.Text, strRuns = runsText.Text, strWickets = wicketsText.Text, strMaidens = maidensText.Text, 
                strSixes = sixesText.Text, strFours = foursText.Text, strCenturies = centuriesText.Text, strFifties = fiftiesText.Text;

            int iMatchesPlayed, iRuns, iWickets, iMaidens, iSixes, iFours, iCenturies, iFifties;

            if (strMatchesPlayed == "")
                iMatchesPlayed = 0;
            else
                iMatchesPlayed = int.Parse(strMatchesPlayed);

            if (strRuns == "")
                iRuns = 0;
            else
                iRuns = int.Parse(strRuns);

            if (strWickets == "")
                iWickets = 0;
            else
                iWickets = int.Parse(strWickets);

            if (strMaidens == "")
                iMaidens = 0;
            else
                iMaidens = int.Parse(strMaidens);

            if (strSixes == "")
                iSixes = 0;
            else
                iSixes = int.Parse(strSixes);

            if (strFours == "")
                iFours = 0;
            else
                iFours = int.Parse(strFours);

            if (strCenturies == "")
                iCenturies = 0;
            else
                iCenturies = int.Parse(strCenturies);

            if (strFifties == "")
                iFifties = 0;
            else
                iFifties = int.Parse(strFifties);

            if (mainWindow.isScoreUp == true)
                upScore.updateCrickScore(mainWindow.selectedPlayerID, mainWindow.selectedTourID, iMatchesPlayed, iRuns, iWickets, iMaidens, iSixes, iFours, iCenturies, iFifties);
            else
                insScore.insertCrickScore(mainWindow.selectedPlayerID, mainWindow.selectedTourID, iMatchesPlayed, iRuns, iWickets, iMaidens, iSixes, iFours, iCenturies, iFifties);


            mainWindow.updateBinding();

        }

        private void teamSelectLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            List<CrickTeams> crickTeams = new List<CrickTeams>();

            //MessageBox.Show($"{teamSelectLB.SelectedIndex}");
            FetchData fetchData = new FetchData();
            crickTeams = fetchData.getCirckTeam();
            string id = crickTeams.ElementAt(teamSelectLB.SelectedIndex).team_id;
            teamSelectScroll.Visibility = Visibility.Collapsed;
            playerInsScroll.Visibility = Visibility.Visible;
            playerTeamIdText.Text = id;
        }

        private void tourSelectLBI_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            List<CrickTour> crickTours = new List<CrickTour>();

            //MessageBox.Show($"{teamSelectLB.SelectedIndex}");
            FetchData fetchData = new FetchData();
            crickTours = fetchData.getCirckTour();
            selectedTourId = crickTours.ElementAt(tourSelectLB.SelectedIndex).t_id;
            tourSelectScroll.Visibility = Visibility.Collapsed;
            crickScoreInsScroll.Visibility = Visibility.Visible;
        }

        
    }
}
