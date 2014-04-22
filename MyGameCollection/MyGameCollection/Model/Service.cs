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

        public IEnumerable<Game> GetGames()
        {
            return GameDAL.GetGames();
        }

    }
}