using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select distinct vendor_name from Vendor", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    vendor_list.Items.Add(reader["vendor_name"].ToString());
                }
            }
            catch(Exception exc)
            {

            }
        }
    }
}