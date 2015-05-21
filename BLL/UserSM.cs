using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserSM
    {
        public int UserId { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public bool User { get; set; }
        public bool Poweruser { get; set; }
        public bool Admin { get; set; } 
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int SecLvl { get; set; }
    }
}
