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

                SqlCommand cmd = new SqlCommand("Select distinct vendor_code, vendor_name from vendor", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    vendor_list.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
                    DropDownList1.Items.Add(reader["vendor_code"].ToString() + " - " + reader["vendor_name"].ToString());
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

    protected void inventory_diplay()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            string query = "select generic_name, remaining, purchase_date, expiry_date, vendor.vendor_code, vendor.vendor_name, batch_number from medicine, vendor, inventory where medicine.medicine_code = inventory.medicine_code and vendor.vendor_code = inventory.vendor_code and vendor.vendor_code = medicine.vendor_code and vendor.medicine_code = medicine.medicine_code";
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            while(reader.Read())
            {
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
        catch (Exception exc)
        {

        }
        finally
        {
            con.Close();
        }
    }
}
 