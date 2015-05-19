using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class GuestSM
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public uint Phone { get; set; }
        public bool Active { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }

}
