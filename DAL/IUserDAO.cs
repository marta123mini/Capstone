using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUserDAO
    {
        void SetDataWriter(ISQLDAO dataWriter);
        List<UserDM> Read(SqlParameter[] parameters, string statement);
        List<UserDM> GetAllUsers();
        void CreateUser(UserDM user);
        void DeleteUserById(string id);
        void UpdateUser(UserDM user);
        UserDM GetUserById(string Id);
        UserDM GetUser(UserDM veriUser);
    
    }
}