using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = TextBox1.Text;
        string password = TextBox2.Text;
        if(email.Equals("email@gmail.com"))
        {
            if(password.Equals("password"))
            {
                Response.Redirect("~/Medicines.aspx");
            }
        }
    }
}