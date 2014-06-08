using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyGameCollection.Model;

namespace MyGameCollection
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

                User user = Session["user"] as User;
                Label1.Text = user.UserName;
                LogInButton.Visible = false;
                RgistertButton.Visible = false;
                LogOutButton.Visible = true;
                NameTextBox.Visible = false;
                PasswordTextBox.Visible = false;
            }
        }
        protected void LogInButton_Click(object sender, EventArgs e)
        {
            User user;
            user = Service.GetUser(NameTextBox.Text);
            if (user == null)
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Fel användarnamn eller lösenord";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
            else if (user.Password == PasswordTextBox.Text)
            {
                Label1.Text = user.UserName;
                LogInButton.Visible = false;
                RgistertButton.Visible = false;
                LogOutButton.Visible = true;
                NameTextBox.Visible = false;
                PasswordTextBox.Visible = false;

                Session["user"] = user;
            }
            else 
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Fel användarnamn eller lösenord";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
        }

        protected void RgistertButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Label1.Text = "";
            LogInButton.Visible = true;
            RgistertButton.Visible = true;
            LogOutButton.Visible = false;
            NameTextBox.Visible = true;
            PasswordTextBox.Visible = true;
        }
    }
}