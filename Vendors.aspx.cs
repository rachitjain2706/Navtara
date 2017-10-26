using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Vendors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select distinct medicine_code, generic_name from medicine", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    medicine_list.Items.Add(reader["medicine_code"].ToString());
                }
                reader.Close();
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

    public string vendorCodeGenerated(string name)
    {
        string vendorCode = "";
        for (int i = 0; i < 3; i++)
        {
            vendorCode += name[i];
        }
        for (int i = name.Length - 1; i >= name.Length - 3; i--)
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
        for (int j = nam.Length - 1; j >= nam.Length - 3; j--)
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
            //    string med_code = medicineCodeGenerated(gen_name.Text, trade_name.Text);
            //    string vendor_code = vendorCode(medicine_list.SelectedValue);
            //    string query = "insert into medicine values(@medicine_code, @generic_name, @trade_name, @purchasing_price, @selling_price, @description, @vendor_code)";
            //    SqlCommand cmd1 = new SqlCommand(query, con);
            //    cmd1.Parameters.AddWithValue("@medicine_code", med_code);
            //    cmd1.Parameters.AddWithValue("@generic_name", gen_name.Text);
            //    cmd1.Parameters.AddWithValue("@trade_name", trade_name.Text);
            //    cmd1.Parameters.AddWithValue("@description", med_desc.Text);
            //    cmd1.Parameters.AddWithValue("@purchasing_price", pp.Text);
            //    cmd1.Parameters.AddWithValue("@selling_price", sp.Text);
            //    cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            //    int rows = cmd1.ExecuteNonQuery();
            //    if (rows > 0)
            //    {
            //        Response.Write("<script>alert('Successful insertion')</script>");
            //        gen_name.Text = "";
            //        trade_name.Text = "";
            //        med_desc.Text = "";
            //        pp.Text = "";
            //        sp.Text = "";
            //    }
            //    query = "select * from vendor where vendor_code=@vendor_code";
            //    cmd1 = new SqlCommand(query, con);
            //    cmd1.Parameters.AddWithValue("@vendor_code", vendor_code);
            //    SqlDataReader reader;
            //    reader = cmd1.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        address = reader["address"].ToString();
            //        vendor_name = reader["vendor_name"].ToString();
            //    }
            //    reader.Close();
            //    l2.Text = address;

            string vendor_code = vendorCodeGenerated(vendor_n.Text);
            //string query = "select * from medicine";
            //SqlCommand cmd1 = new SqlCommand(query, con);
            //SqlDataReader reader;
            //reader = cmd1.ExecuteReader();
            //while(reader.Read())
            //{
            //    medicine_list.Items.Add(reader["medicine_code"].ToString());
            //}
            string med_code = medicine_list.SelectedValue;
            //reader.Close();
            insertIntoVendor(con, addr.Text, vendor_n.Text, vendor_code, med_code);
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