using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfoMS.Cricket
{
    public class CrickPlayer
    {
        public string player_id { get; set; }
        public string team_id { get; set; }
        public string img_path { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public string gender { get; set; }
        public string p_role { get; set; }
        public string team_name { get; set; }
    }
}
