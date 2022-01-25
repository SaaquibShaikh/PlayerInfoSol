using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlayerInfoMS.DataBaseAccess
{
    public class DeleteData
    {
        public void delCrickTeam(string id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                try
                {
                    connection.Execute($"call delete_team('{id}')");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void delCrickTour(string id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                try
                {
                    connection.Execute($"call delete_tournament('{id}')");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void delCrickPlayer(string id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                try
                {
                    connection.Execute($"call delete_player('{id}')");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void delCrickScore(string pid, string tid)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                try
                {
                    connection.Execute($"call delete_score('{pid}','{tid}')");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }
    }
}
