using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyGameCollection.Model;

namespace MyGameCollection
{
    public partial class Register : System.Web.UI.Page
    {
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
                if (Service.GetUser(UserNameTextBox.Text) != null)
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Användaren finns redan";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                }
                else
                {
                    Service.CreateUser(UserNameTextBox.Text, PasswordTextBox.Text);
                    Response.Redirect("~/Default.aspx");
                }
            }

        }
    }
}