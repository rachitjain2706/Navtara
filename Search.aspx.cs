using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Search : System.Web.UI.Page
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
                string name = Request.QueryString["name"];
                string query = "select distinct inventory.batch_number, medicine.medicine_code, remaining from medicine, inventory where medicine.medicine_code = inventory.medicine_code and (@names = Generic_name or @names= Trade_name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@names", name);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    l5.Text += reader["medicine_code"].ToString() + " - " +  reader["remaining"].ToString() + "<br />";
                }
            }
            catch(Exception exc)
            {
                l5.Text = exc.ToString();
            }
            finally
            {
                con.Close();
            }
        }
    }
}