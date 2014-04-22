using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyGameCollection
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["a"] != null)
            {
                Label1.Text = Session["a"] as string;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["a"] = TextBox1.Text;
        }
    }
}