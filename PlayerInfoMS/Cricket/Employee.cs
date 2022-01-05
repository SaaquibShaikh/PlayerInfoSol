using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerInfoMS.Cricket
{
    public class Employee
    {
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public string Ssn { get; set; }
        public string Bdate { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public double Salary { get; set; }
        public string Super_ssn { get; set; }
        public int Dno { get; set; }

        public string  Name
        {
            get { return $"{Fname} {Minit} {Lname}"; }
            set { }
        }

    }
}
