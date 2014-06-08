using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyGameCollection.Model.DAL
{
    public class UserDAL : DALBase
    {
        public User GetUser(string name)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var user = new User();

                    var cmd = new SqlCommand("appSchema.usp_getuserbyname", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@användaren", name);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            var userID = reader.GetOrdinal("AnvändarID");
                            var username = reader.GetOrdinal("AnvändarNamn");
                            var password = reader.GetOrdinal("Lösenord");

                            return new User
                            {
                                UserID = reader.GetInt32(userID),
                                UserName = reader.GetString(username),
                                Password = reader.GetString(password)

                            };
                        }
                    }
                    return null;


                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod");
                }
            }
        }

        public void CreateUser(string name, string password) 
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_newuser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@namn", SqlDbType.VarChar, 50).Value = name;
                    cmd.Parameters.Add("@lösenord", SqlDbType.VarChar, 50).Value = password;

                    cmd.Parameters.Add("@användarid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    // Kanske kommer att använda denna senare
                    int userid = (int)cmd.Parameters["@användarid"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }
        }
    }
}