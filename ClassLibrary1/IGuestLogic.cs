using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IGuestLogic
    {
  
        List<GuestSM> GetAllGuests();
        GuestSM GetGuestById(int id);
        void CreateGuest(GuestSM guest);
        void UpdateGuest(GuestSM guest);
        void DeleteGuestById(int id);
    }
}
