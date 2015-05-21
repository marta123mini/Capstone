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
    public class UserDAO:IUserDAO
    {
        private ISQLDAO dataWriter;
        private ILoggerIO logs;
        private string connectionString = @"Server=.\SQLEXPRESS;Database = GuestList;Trusted_Connection=True;";

        public UserDAO(ILoggerIO log)
        {
            logs = log;
        }
        public void SetDataWriter(ISQLDAO dataWriter)
        {
            this.dataWriter = dataWriter;
        }
        public List<UserDM> Read(SqlParameter[] parameters, string statement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                    List<UserDM> people = new List<UserDM>();
                    while (data.Read())
                    {
                        UserDM user = new UserDM();
                        user.UserId = data["Id"].ToString();
                        user.Username = data["Username"].ToString();
                        user.Password = data["Password"].ToString();
                        user.Admin = data["Admin"].ToString();
                        user.Poweruser = data["Poweruser"].ToString();
                        user.Street1 = data["Street1"].ToString();
                        user.Street2 = data["street2"].ToString();
                        user.City = data["City"].ToString();
                        user.State = data["State"].ToString();
                        user.Zipcode = data["Zipcode"].ToString();
                        people.Add(user);
                    }
                    return people;
                }
            }
        }
        public List<UserDM> GetAllUsers()
        {
            return Read(null, "GetAllUsers");
        }
        public void CreateUser(UserDM user)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Admin", user.Admin),
                new SqlParameter("@Poweruser", user.Poweruser),
                new SqlParameter("@User", user.User),
                new SqlParameter("@Street1",user.Street1),
                new SqlParameter("@Street2",user.Street2),
                new SqlParameter("@City",user.City),
                new SqlParameter("@State",user.State),
                new SqlParameter("@Zipcode",user.Zipcode)
            };
            dataWriter.Write(parameters, "CreateUser");
            logs.LogError("Event", "An User has been added to the database", "Class:UserDAO, Method:CreateUser");
        }
        public void DeleteUserById(string id)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@UserId", id)
            };
            dataWriter.Write(parameters, "DeleteUserById");
            logs.LogError("Event", "An User has been removed from the database", "Class:UserDAO, Method:DeleteUserById");
        }
        public void UpdateUser(UserDM user)
        {
            SqlParameter[] parameters = new SqlParameter[]{
               new SqlParameter("@Username", user.Username),
               new SqlParameter("@Password", user.Password),
               new SqlParameter("@Admin", user.Admin),
               new SqlParameter("@Poweruser", user.Poweruser),
               new SqlParameter("@User", user.User),
               new SqlParameter("@Street1",user.Street1),
               new SqlParameter("@Street2",user.Street2),
               new SqlParameter("@City",user.City),
               new SqlParameter("@State",user.State),
               new SqlParameter("@Zipcode",user.Zipcode),
               new SqlParameter("@Id", user.UserId) 
            }; 
            dataWriter.Write(parameters, "UpdateUserById");
            logs.LogError("Event", "An User has been updated", "Class:UserDAO, Method: UpdateUser");
        }
        public UserDM GetUserById(string id)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Id", id)
            };
            return Read(parameters, "GetUserById").SingleOrDefault();
        }
        public UserDM GetUser(UserDM veriUser)
        {
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@Username", veriUser.Username)
               ,new SqlParameter("@Password", veriUser.Password)
            };
            return Read(parameters, "GetUserById").SingleOrDefault();
        }
    }
}
