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

    public string vendorCodeGenerated(string name)
    {
        string vendorCode = "";
        for(int i=0; i<3; i++)
        {
            vendorCode += name[i+10];
        }
        for(int i=name.Length-1; i >= name.Length-3; i--)
        {
            vendorCode += name[i];
        }
        return vendorCode;
    }

    public string medicineCodeGenerated(string name, string nam)
    {
        string medicineCode = "";
        for (int i = 0; i < 3; i++)
        {
            medicineCode += name[i];
        }
        for (int j = nam.Length-1; j >= nam.Length - 3; j--)
        {
            medicineCode += nam[j];
        }
        return medicineCode;
    }

    public string vendorCode(string name)
    {
        string code = "";
        for (int i = 0; i < 6; i++)
        {
            code += name[i];
        }
        return code;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        //Response.Write("<script>alert('Hola')</script>");
        try
        {
            con.Open();
            string med_code = medicineCodeGenerated(gen_name.Text, trade_name.Text);
            //string vendor_code = vendorCodeGenerated(vendor_list.SelectedValue);
            string vendor_code = vendorCode(vendor_list.SelectedValue);
            string query = "insert into medicine values(@medicine_code, @generic_name, @trade_name, @purchasing_price, @selling_price, @description, @vendor_code)";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@medicine_code", med_code);
            cmd1.Parameters.AddWithValue("@generic_name", gen_name.Text);
            cmd1.Parameters.AddWithValue("@trade_name", trade_name.Text);
            cmd1.Parameters.AddWithValue("@description", med_desc.Text);
            cmd1.Parameters.AddWithValue("@purchasing_price", pp.Text);
            cmd1.Parameters.AddWithValue("@selling_price", sp.Text);
            cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            int rows = cmd1.ExecuteNonQuery();
            if(rows > 0)
            {
                Response.Write("<script>alert('Successful insertion')</script>");
                gen_name.Text = "";
                trade_name.Text = "";
                med_desc.Text = "";
                pp.Text = "";
                sp.Text = "";
            }
            query = "select * from vendor where vendor_code=@vendor_code";
            cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            SqlDataReader reader;
            reader = cmd1.ExecuteReader();
            string address = "";
            string vendor_name = "";

            while (reader.Read())
            {
                address = reader["address"].ToString();
                vendor_name = reader["vendor_name"].ToString();
            }
            l2.Text = address;
            query = "insert into vendor values(@vendor_code, @vendor_name, @address, @med_code)";
            cmd1 = new SqlCommand(query, con);
            cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            cmd1.Parameters.AddWithValue("@vendor_name", vendor_name);
            cmd1.Parameters.AddWithValue("@address", address);
            cmd1.Parameters.AddWithValue("@med_code", med_code);
            rows = cmd1.ExecuteNonQuery();
            if(rows > 0)
            {
                Response.Write("<script>alert('Lowla')</script>");
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
 