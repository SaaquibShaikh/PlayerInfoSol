using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfoMS.Cricket
{
    public class CrickScore
    {
        public string p_id { get; set; }
        public string t_id { get; set; }
        public string t_name { get; set; }
        public int matches_played { get; set; }
        public int runs { get; set; }
        public int wickets { get; set; }
        public int maidens { get; set; }
        public int sixes { get; set; }
        public int fours { get; set; }
        public int centuries { get; set; }
        public int fifties { get; set; }
    }
}
