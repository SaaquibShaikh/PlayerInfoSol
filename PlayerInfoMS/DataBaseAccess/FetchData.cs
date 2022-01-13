using Dapper;
using MySql.Data.MySqlClient;
using PlayerInfoMS.Administrators;
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
    public class FetchData
    {
        public List<Employee> employees()
        {
            using(IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CompanyDB")))
            {
                var output = connection.Query<Employee>("select * from employee").ToList();
                return output;
            }
        }

        //returns the list of Administators
        public List<Users> getUsers()
        {
            using(IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("UsersDB")))
            {
                
                    return connection.Query<Users>("select * from administrators").ToList();
            }
        }

        public List<CrickPlayer> getCirckPlayer()
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                return connection.Query<CrickPlayer>("call select_player").ToList(); 
            }
        }

        public List<CrickTour> getCirckTour()
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                
                
                return connection.Query<CrickTour>("call select_tournament").ToList();
                
            }
        }

        public List<CrickTeams> getCirckTeam()
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {


                return connection.Query<CrickTeams>("call select_teams").ToList();

            }
        }
    }
}