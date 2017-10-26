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

                SqlCommand cmd1 = new SqlCommand("select distinct medicine_code, generic_name from medicine", con);
                SqlDataReader reader1;
                reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    medicine_list.Items.Add(reader1["medicine_code"].ToString());
                }
                reader1.Close();

                //SqlCommand cmd = new SqlCommand("select vendor_code, sum(sale_cost) AS total_sale from vendorsales group by vendor_code", con);
                //SqlDataReader reader;
                //reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    TableRow tr = new TableRow();
                //    TableCell tc = new TableCell();
                //    TableCell tc2 = new TableCell();
                //    tc.Text = reader["vendor_code"].ToString();
                //    tr.Cells.Add(tc);
                //    tc2.Text = reader["total_sale"].ToString();
                //    tr.Cells.Add(tc2);
                //    vendorPaymentTable.Rows.Add(tr);
                //}
                //reader.Close();
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

    protected void rokdaShow()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select vendor_code, sum(sale_cost) AS total_sale from vendorsales group by vendor_code", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                TableCell tc2 = new TableCell();
                tc.Text = reader["vendor_code"].ToString();
                tr.Cells.Add(tc);
                tc2.Text = reader["total_sale"].ToString();
                tr.Cells.Add(tc2);
                vendorPaymentTable.Rows.Add(tr);
            }
            reader.Close();
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
            string vendor_code = vendorCodeGenerated(vendor_n.Text);
            string med_code = medicine_list.SelectedValue;
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