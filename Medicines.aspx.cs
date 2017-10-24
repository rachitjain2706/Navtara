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

                /*SqlCommand cmd = new SqlCommand("Select vendor_code, vendor_name from vendor where vendor_code in (Select distinct vendor_code from vendor)", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    vendor_list.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
                    DropDownList1.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
                }*/

                string query = "select inventory.vendor_code, generic_name, remaining, purchase_date, expiry_date, batch_number, vendor_name from medicine, inventory, vendor where medicine.medicine_code = inventory.medicine_code and vendor.vendor_code = inventory.vendor_code and vendor.vendor_code in (Select distinct vendor_code from vendor)";
                //string query = "select generic_name, remaining, purchase_date, expiry_date, batch_number, vendor_name from medicine, inventory, vendor where medicine.medicine_code = inventory.medicine_code and vendor.vendor_code = inventory.vendor_code";
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataReader reader;
                reader = cmd1.ExecuteReader();
                while(reader.Read())
                {
                    //l3.Text = reader1["medicine_code"].ToString();
                    //Response.Write("<script>alert(reader['generic_name'])</script>");
                    vendor_list.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
                    DropDownList1.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
                    TableRow row = new TableRow();
                    TableCell tableCell = new TableCell();
                    tableCell.Text = reader["generic_name"].ToString();
                    row.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = reader["remaining"].ToString();
                    row.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = reader["purchase_date"].ToString();
                    row.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = reader["expiry_date"].ToString();
                    row.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = reader["batch_number"].ToString();
                    row.Cells.Add(tableCell);

                    tableCell = new TableCell();
                    tableCell.Text = reader["vendor_name"].ToString();
                    row.Cells.Add(tableCell);
                    t3.Rows.Add(row);
                }
            }
            catch(Exception exc)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}
 