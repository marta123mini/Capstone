using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGuestDAO
    {
        void SetDataWriter(ISQLDAO dataWriter);
        List<GuestDM> Read(SqlParameter[] parameters, string statement);
        List<GuestDM> GetAllGuests();
        void CreateGuest(GuestDM guest);
        void DeleteGuestById(String id);
        void UpdateGuest(GuestDM guest);
        GuestDM GetGuestById(String id);
    }
}