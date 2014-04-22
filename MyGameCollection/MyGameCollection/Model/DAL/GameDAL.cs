using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyGameCollection.Model.DAL
{
    public class GameDAL : DALBase
    {
        public IEnumerable<Game> GetGames()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var games = new List<Game>(100);
                    var cmd = new SqlCommand("appSchema.usp_getgames", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var gameID = reader.GetOrdinal("SpelID");
                        var gameName = reader.GetOrdinal("SpelNamn");
                        var gameText = reader.GetOrdinal("Information");

                        while (reader.Read())
                        {
                            games.Add(new Game
                            {
                                GameID = reader.GetInt32(gameID),
                                GameName = reader.GetString(gameName),
                                GameText = reader.GetString(gameText)
                            });
                        }
                    }
                    games.TrimExcess();

                    return games;
                }
                catch 
                {
                    throw new ApplicationException("Ett fel uppstod när spelen skulle hämtas");
                }
            }
        }
    }
}