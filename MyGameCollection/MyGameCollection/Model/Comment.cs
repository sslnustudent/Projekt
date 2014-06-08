using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGameCollection.Model
{
    public class Comment
    {
        public int CommentID { get; set; }

        public int UserID { get; set; }

        public int GameID { get; set; }

        public string CommentText { get; set; }

        public string UserName { get; set; }

        public DateTime DateAndTime { get; set; }

    }
}