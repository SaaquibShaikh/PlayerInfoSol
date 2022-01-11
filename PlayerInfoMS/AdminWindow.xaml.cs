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
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void doneTeams_Click(object sender, RoutedEventArgs e)
        {
            PutData insTeam = new PutData();
            string id = teamIdText.Text, name = teamNameText.Text, img = teamIcoText.Text;
            
            if(id == "")
                id = null;

            if ( name == "")
               name = null;

            if ( img == "")
                img = "Icons/default.jpg";


            insTeam.insertCrickTeams(id, name, img);
        }
    }
}
