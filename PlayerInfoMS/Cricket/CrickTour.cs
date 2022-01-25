using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlayerInfoMS.Cricket
{
    public class CrickTour
    {
        Regex regex = new Regex(@"\d\d/\d\d/\d\d\d\d");


        public string t_id { get; set; }
        public string new_t_id { get; set; }
        public string tname { get; set; }
        private string date;
        public string start_date
        {
            get { return date; }
            set 
            {
                if (value != null)
                {
                    Match match = regex.Match(value);
                    if (match.Success)
                    {
                        var s = match.Value.Split('/');
                        date = s[2] + "-" + s[0] + "-" + s[1];
                    }
                    else
                        date = value;
                }
                else
                    date = value;
            }
        }
        public string end_date
        {
            get { return date; }
            set
            {
                if (value != null)
                {
                    Match match = regex.Match(value);
                    if (match.Success)
                    {
                        var s = match.Value.Split('/');
                        date = s[2] + "-" + s[0] + "-" + s[1];
                    }
                    else
                        date = value;
                }
                else
                    date = value;
            }
        }
        public string t_location { get; set; }

    }
}
