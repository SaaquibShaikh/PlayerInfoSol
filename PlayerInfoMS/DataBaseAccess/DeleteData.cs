using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfoMS.DataBaseAccess
{
    public class DeleteData
    {
        public void delCrickTeam(string id)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                connection.Execute($"call delete_team('{id}')");
            }
        }
    }
}
