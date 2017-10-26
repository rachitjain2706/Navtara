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

    protected void phaphda()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            string query = "select medicine_code, batch_number from inventory where expiry_date<=@today";
            SqlCommand cmd1 = new SqlCommand(query, con);
            string today = DateTime.Today.ToString();
            cmd1.Parameters.AddWithValue("@today", DateTime.Today);
            SqlDataReader reader;
            //Array array = new Array();
            string[] array = new string[100];
            reader = cmd1.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                //l7.Text = reader["medicine_code"].ToString();
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = reader["medicine_code"].ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = reader["batch_number"].ToString();
                array[count++] = reader["batch_number"].ToString();
                row.Cells.Add(cell);
                t4.Rows.Add(row);
            }
            reader.Close();
            query = "delete from inventory where expiry_date<=@today";
            cmd1 = new SqlCommand(query, con);
            today = DateTime.Today.ToString();
            cmd1.Parameters.AddWithValue("@today", DateTime.Today);
            int rows = cmd1.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            l7.Text = exc.ToString();
        }
        finally
        {
            con.Close();
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

    public void insertIntoVendor(SqlConnection con, string address, string name, string code, string med_code)
    {
        string query = "insert into vendor values(@vendor_code, @vendor_name, @address, @med_code)";
        SqlCommand cmd1 = new SqlCommand(query, con);
        cmd1.Parameters.AddWithValue("@vendor_code", code);
        cmd1.Parameters.AddWithValue("@vendor_name", name);
        cmd1.Parameters.AddWithValue("@address", address);
        cmd1.Parameters.AddWithValue("@med_code", med_code);
        int rows = cmd1.ExecuteNonQuery();
        if (rows > 0)
        {
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            string med_code = medicineCodeGenerated(gen_name.Text, trade_name.Text);
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
            reader.Close();

            insertIntoVendor(con, address, vendor_name, vendor_code, med_code);
        }
        catch(Exception exc)
        {
            l2.Text = exc.ToString();
        }
        finally
        {
            con.Close();
        }
    }

    public string medicineCode(SqlConnection con, string name)
    {
        string code = "";
        SqlCommand cmd = new SqlCommand("Select * from medicine where generic_name=@name", con);
        cmd.Parameters.AddWithValue("@name", name);
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            code = reader["medicine_code"].ToString();
            reader.Close();
            break;
        }
        reader.Close();
        return code;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            string med_name = TextBox1.Text;
            string med_code = medicineCode(con, med_name);
            string vendor_code = vendorCode(DropDownList1.SelectedValue);
            string query = "insert into inventory values(@medicine_code, @expiry_date, @purchase_date, @vendor_code, @threshold, @remaining)";
            SqlCommand cmd1 = new SqlCommand(query, con);
            DateTime today = DateTime.Today;
            cmd1.Parameters.AddWithValue("@medicine_code", med_code);
            cmd1.Parameters.AddWithValue("@expiry_date", TextBox2.Text);
            cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            cmd1.Parameters.AddWithValue("@purchase_date", today);
            cmd1.Parameters.AddWithValue("@remaining", TextBox3.Text);
            cmd1.Parameters.AddWithValue("@threshold", 50);
            int rows = cmd1.ExecuteNonQuery();
            if (rows > 0)
            {
                Response.Write("<script>alert('Successful insertion')</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }
        catch (Exception exc)
        {
            l2.Text = exc.ToString();
        }
        finally
        {
            con.Close();
        }
    }
}
 