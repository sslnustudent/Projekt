using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyGameCollection.Model;

namespace MyGameCollection
{
    public partial class GameList : System.Web.UI.Page
    {
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Game> GameListView_GetData()
        {
            try
            {
                return Service.GetGames();
            }
            catch
            {

                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när spelen skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
        }
    }
}