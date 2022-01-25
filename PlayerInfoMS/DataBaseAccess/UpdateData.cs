using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PlayerInfoMS.Cricket;
using System.Windows;

namespace PlayerInfoMS.DataBaseAccess
{
    public class UpdateData
    {
        public void updateCrickTeams(string teamID, string newTeamID, string teamName, string imgPath)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                CrickTeams teamObj = new CrickTeams { team_id = teamID, new_team_id = newTeamID, team_name = teamName, team_img_path = imgPath };

                List<CrickTeams> teams = new List<CrickTeams>();
                teams.Add(teamObj);

                try
                {
                    connection.Execute("call update_team(@team_id, @new_team_id, @team_name, @team_img_path)", teams);
                    MessageBox.Show($"Team ID {teamID} updated");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void updateCrickTour(string tourID, string newTourID,  string tourName, string startDate, string endDate, string location)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                CrickTour tourObj = new CrickTour { t_id = tourID, new_t_id = newTourID, tname = tourName, start_date = startDate, end_date = endDate, t_location = location };

                List<CrickTour> tour = new List<CrickTour>();
                tour.Add(tourObj);

                try
                {
                    connection.Execute("call update_tournament(@t_id, @new_t_id, @tname, @start_date, @end_date, @t_location)", tour);
                    MessageBox.Show($"Team ID {tourID} updated");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void updateCrickPlayer(string pid, string newpid, string teamId, string pname, string imgpath, int page, float pheight, float pweight, string pgender, string prole)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                CrickPlayer playerObj = new CrickPlayer { player_id = pid, new_player_id = newpid, team_id = teamId, name = pname, img_path = imgpath, age = page, height = pheight, weight = pweight, gender = pgender, p_role = prole };

                List<CrickPlayer> player = new List<CrickPlayer>();
                player.Add(playerObj);

                try
                {
                    connection.Execute("call update_player(@player_id, @new_player_id, @team_id, @name, @img_path, @age, @height, @weight, @gender, @p_role)", player);
                    MessageBox.Show($"Team ID {pid} updated");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

        public void updateCrickScore(string pid, string tid, int matchesPlayed, int sRuns, int sWickets, int sMaidens, int sSixes, int sFours, int sCenturies, int sFifties)
        {
            using (IDbConnection connection = new MySqlConnection(ConnStringHelper.getConnString("CricketDB")))
            {
                CrickScore scoreObj = new CrickScore { p_id = pid, t_id = tid, matches_played = matchesPlayed, runs = sRuns, wickets = sWickets, maidens = sMaidens, sixes = sSixes, fours = sFours, centuries = sCenturies, fifties = sFifties };

                List<CrickScore> score = new List<CrickScore>();
                score.Add(scoreObj);

                try
                {
                    connection.Execute("call update_score( @p_id, @t_id, @matches_played ,@runs, @wickets, @maidens, @sixes, @fours, @centuries, @fifties)", score);
                    MessageBox.Show($"Score for Player-{pid}, torunament-{tid} is updated");
                }
                catch (MySqlException e)
                {
                    MessageBox.Show($"{e.Message}\n{e.InnerException}");
                }
            }
        }

    }
}
