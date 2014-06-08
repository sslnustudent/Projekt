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

        public Game GetGame(int id) 
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var game = new Game();

                    var cmd = new SqlCommand("appSchema.usp_getgame", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            var gameID = reader.GetOrdinal("SpelID");
                            var gameName = reader.GetOrdinal("SpelNamn");
                            var gameText = reader.GetOrdinal("Information");

                            return new Game
                            {
                                GameID = reader.GetInt32(gameID),
                                GameName = reader.GetString(gameName),
                                GameText = reader.GetString(gameText),
                            };
                        }
                    }
                    return null;


                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när spelet skulle hämtas");
                }
            }
        }

        public Game GetGameByName(string name)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var game = new Game();

                    var cmd = new SqlCommand("appSchema.usp_getgamebyname", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@namn", name);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            var gamename = reader.GetOrdinal("SpelNamn");

                            return new Game
                            {
                                GameName = reader.GetString(gamename)

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

        public int NewGame(string name, string text)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_newgame", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@namn", SqlDbType.VarChar, 50).Value = name;
                    cmd.Parameters.Add("@beskrivning", SqlDbType.VarChar, 5000).Value = text;

                    cmd.Parameters.Add("@spelid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    int gameid = (int)cmd.Parameters["@spelid"].Value;
                    return gameid;
                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }

 
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var comments = new List<Comment>(100);
                    var cmd = new SqlCommand("appSchema.usp_getcomments", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        var commentID = reader.GetOrdinal("KommentariID");
                        var commentText = reader.GetOrdinal("Kommentar");
                        var dateAndTime = reader.GetOrdinal("Datum");
                        var userName = reader.GetOrdinal("AnvändarNamn");

                        while (reader.Read())
                        {
                            comments.Add(new Comment
                            {
                                CommentID = reader.GetInt32(commentID),
                                CommentText = reader.GetString(commentText),
                                UserName = reader.GetString(userName),
                                DateAndTime = reader.GetDateTime(dateAndTime)
                            });
                        }
                    }
                    comments.TrimExcess();

                    return comments;
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod när kommentarerna skulle hämtas");
                }
            }
 
        }

        public void MakeComment(string commentText, int userID, int gameid)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_makecomment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@användarid", SqlDbType.Int, 4).Value = userID;
                    cmd.Parameters.Add("@spelid", SqlDbType.Int, 4).Value = gameid;
                    cmd.Parameters.Add("@kommentar", SqlDbType.VarChar, 150).Value = commentText;

                    cmd.Parameters.Add("@kommentarid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    int commentid = (int)cmd.Parameters["@kommentarid"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }

 
        }
    }
}