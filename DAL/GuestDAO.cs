using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogger;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class GuestDAO : IGuestDAO
    {
        private ISQLDAO dataWriter;
        private ILoggerIO logs;
        private string connectionstring = @"Server.\SQLEXPRESS;Database = GuestList;Trusted_Connection=True;";
        public GuestDAO(ILoggerIO log)
        {
            logs = log;
        }
        public void SetDataWriter(ISQLDAO dataWriter)
        {
            this.dataWriter = dataWriter;
        }
        public List<GuestDM> Read(SqlParameter[] parameters, string statement)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    connection.Open();
                    SqlDataReader data = command.ExecuteReader();
                    List<GuestDM> person = new List<GuestDM>();
                    while (data.Read())
                    {
                        GuestDM guest = new GuestDM();
                        guest.GuestId = data["Id"].ToString();
                        guest.Name = data["Name"].ToString();
                        guest.Phone = data["Phone"].ToString();
                        guest.Active = data["Active"].ToString();
                        guest.Street1 = data["Street1"].ToString();
                        guest.Street2 = data["street2"].ToString();
                        guest.City = data["City"].ToString();
                        guest.State = data["State"].ToString();
                        guest.Zipcode = data["ZipCode"].ToString();
                        person.Add(guest);
                    }
                    return person;
                }
            }

        }

        public List<GuestDM> GetAllGuests()
        {
            return Read(null, "GetAllGuests");
        }
        public void CreateGuest(GuestDM guest)
        {
            SqlParameter[] parameters = new SqlParameter[]{
       new SqlParameter("@Name",guest.Name),
       new SqlParameter("@Phone",guest.Phone),
       new SqlParameter("@Active",guest.Active),
       new SqlParameter("@Street1",guest.Street1),
       new SqlParameter("@Street2",guest.Street2),
       new SqlParameter("@City",guest.City),
       new SqlParameter("@State",guest.State),
       new SqlParameter("@Zipcode",guest.Zipcode)
       };
            dataWriter.Write(parameters, "CreateGuest");
            logs.LogError("Event", "A Guest has been added to the database", "Class:GuestDAO, Method:CreateGuest");

        }
        public GuestDM GetGuestById(String id)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@GuestId", id)
            };
            return Read(parameters, "GetGuestById").SingleOrDefault();
        }
        public void UpdateGuest(GuestDM guest)
        {
            SqlParameter[] parameters = new SqlParameter[]{
        new SqlParameter("Id",guest.GuestId),
       new SqlParameter("@Name",guest.Name),
       new SqlParameter("@Phone",guest.Phone),
       new SqlParameter("@Active",guest.Active),
       new SqlParameter("@Street1",guest.Street1),
       new SqlParameter("@Street2",guest.Street2),
       new SqlParameter("@City",guest.City),
       new SqlParameter("@State",guest.State),
       new SqlParameter("@Zipcode",guest.Zipcode)
       };
            dataWriter.Write(parameters, "UpdateGuestById");
            logs.LogError("Event", "A Guest has been Updated ", "Class:GuestDAO, Method:UpdateGuest");

        }
        public void DeleteGuestById(String id)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Id", id)
            };
            dataWriter.Write(parameters, "DeleteGuestById");
            logs.LogError("Event", "A Guest has been removed from the database", "Class:GuestDAO, Method:DeleteGuestById");
        }

    }
}
