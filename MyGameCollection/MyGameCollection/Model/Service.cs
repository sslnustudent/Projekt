using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MyGameCollection.Model.DAL;

namespace MyGameCollection.Model
{
    public class Service
    {
        private GameDAL _gameDAL;

        public GameDAL GameDAL { get { return _gameDAL ?? (_gameDAL = new GameDAL()); } }

        private UserDAL _userDAL;

        public UserDAL UserDAL { get { return _userDAL ?? (_userDAL = new UserDAL()); } }

        public IEnumerable<Game> GetGames()
        {
            return GameDAL.GetGames();
        }

        public User GetUser(string name)
        {
            return UserDAL.GetUser(name);
        }
        public Game GetGame(int id)
        {
            return GameDAL.GetGame(id);
        }
        public int NewGame(string name, string text)
        {
            return GameDAL.NewGame(name, text);
 
        }
        public Game GetGameByName(string name)
        {
            return GameDAL.GetGameByName(name);
        }
        public IEnumerable<Comment> GetComments(int id)
        {
            return GameDAL.GetComments(id);
        }
        public void MakeComment(string comment, int userid, int gameid)
        {
            GameDAL.MakeComment(comment, userid, gameid);
        }
        public void CreateUser(string name, string password)
        {
            UserDAL.CreateUser(name, password);        }
    }
}