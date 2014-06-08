using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using MyGameCollection.Model;

namespace MyGameCollection
{
    public partial class Details : System.Web.UI.Page
    {
        int _id;

        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        private Gallery _gal;
        public Gallery Gal
        {
            get { return _gal ?? (_gal = new Gallery()); }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["img"];
            if (url != null)
            {
                url = url.Replace("Thumbnails", "Images"); ;
                ShowImage.ImageUrl = Request.QueryString["img"];
            }
            if (Session["user"] != null)
            {
                TextBox1.Visible = true;
                Button1.Visible = true;
                ImageFileUpload.Visible = true;
                Label1.Visible = true;
                UpploadImageButton.Visible = true;
            }
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public MyGameCollection.Model.Game FormView1_GetItem([RouteData]int id)
        {
            _id = id;

            try
            {
                CoverImage.ImageUrl = "~/Covers/" + id + ".jpg";
                return Service.GetGame(id);
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när spelet skulle skulle hämtas";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                return null;
            }
        }

        public IEnumerable<FileData> GalleryRepeater_GetData([RouteData]int id)
        {
            return Gal.GetImagesNames(id);
        }

        public IEnumerable<MyGameCollection.Model.Comment> Repeater1_GetData([RouteData]int id)
        {
            return Service.GetComments(id);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = Session["user"] as User;
            Service.MakeComment(TextBox1.Text, user.UserID, Convert.ToInt32(Page.RouteData.Values["id"]));
        }

        protected void UpploadImageButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Page.RouteData.Values["id"]);
            try
            {
                var name = Gal.SaveImage(ImageFileUpload.PostedFile.InputStream, ImageFileUpload.PostedFile.FileName, id);
                Session["a"] = true;
               // Response.Redirect("~/Default.aspx?name=Thumbnails/" + name);
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