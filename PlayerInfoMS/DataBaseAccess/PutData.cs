using Dapper;
using MySql.Data.MySqlClient;
using PlayerInfoMS.Cricket;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerInfoMS.DataBaseAccess
{
    public class PutData
    {
        //using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CompanyDB")))
        public void insertCrickTeams(string teamID, string teamName, string imgPath)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                CrickTeams teamObj = new CrickTeams { team_id = teamID, team_name = teamName, team_img_path = imgPath };

                List<CrickTeams> teams = new List<CrickTeams>();
                teams.Add(teamObj);

                try
                { 
                    connection.Execute("call insert_team(@team_id, @team_name, @team_img_path)", teams);
                    MessageBox.Show($"Team ID {teamID} inserted");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }
    }
}
