using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MyGameCollection.Model;

namespace MyGameCollection
{
    public partial class NewGame : System.Web.UI.Page
    {
        private Gallery _gal;
        public Gallery Gal
        {
            get { return _gal ?? (_gal = new Gallery()); }

        }

        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Service.GetGameByName(GameNameTextBox.Text) != null)
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Spelet finns redan";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                }
                else
                {
                    try
                    {
                        int id;
                        id = Service.NewGame(GameNameTextBox.Text, GameTextBox.Text);
                        Gal.SaveCover(ImageFileUpload.PostedFile.InputStream, Convert.ToString(id) + ".jpg");
                        Session["a"] = true;
                        if (!Directory.Exists(Convert.ToString(id)))
                        {
                            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), @"Pictures\" + id));
                        }
                        Response.Redirect("spel/" + id);
                    }
                    catch (Exception)
                    {
                        CustomValidator cv = new CustomValidator();
                        cv.ErrorMessage = "Uppladningen misslyckades";
                        cv.IsValid = false;
                        Page.Validators.Add(cv);
                    }
                }
            }
        }
    }
}