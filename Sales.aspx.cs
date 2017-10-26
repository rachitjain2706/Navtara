using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Sales : System.Web.UI.Page
{
    public int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Select distinct medicine_code, generic_name from medicine", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DropDownList1.Items.Add(reader["medicine_code"].ToString() + " - " + reader["generic_name"].ToString());
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

    /*protected void Button2_Click(object sender, EventArgs e)
    {
        count++;
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = "Medicine";
        DropDownList dropDownList = new DropDownList();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = MedPlus; Integrated Security = True";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct medicine_code, generic_name from medicine", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                //dropDownList.ID = "";
                dropDownList.Items.Add(new ListItem(reader["medicine_code"].ToString() + " - " + reader["generic_name"].ToString(), reader["medicine_code"].ToString()));
                //dropDownList.Style.Add()
            }
            TableCell tableCell = new TableCell();
            tableCell.Controls.Add(dropDownList);

            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = "Quantity";
            tableCell = new TableCell();
            TextBox tb = new TextBox();
            tableCell.Controls.Add(tb);
            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = "Cost";
            tableCell = new TableCell();
            tb = new TextBox();
            tableCell.Controls.Add(tb);
            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);
        }
        catch(Exception exc)
        {

        }
        finally
        {
            con.Close();
        }
    }*/

    /*public void insertIntoSales(SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand("insert into sales (medicine_code, quantity, price, sale_date) values(@med_code, @quan, @price, @date)", con);
        cmd.Parameters.AddWithValue("@med_code", );
        cmd.Parameters.AddWithValue("@quan", );
        cmd.Parameters.AddWithValue("@price", );
        cmd.Parameters.AddWithValue("@date", );
        int rows = cmd.ExecuteNonQuery();
        if(rows > 0)
        {
            Response.Write("<script>alert('Successful insertion')</script>");
        }
    }*/

    protected void Button3_Click(object sender, EventArgs e)
    {
        //SqlConnection con = new SqlConnection();
        //con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = MedPlus; Integrated Security = True";
        /*try
        {
            con.Open();
            insertIntoSales(con);
            SqlCommand cmd = new SqlCommand("Select distinct medicine_code, generic_name from medicine", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DropDownList1.Items.Add(reader["medicine_code"].ToString() + " - " + reader["generic_name"].ToString());
            }
        }
        catch (Exception exc)
        {

        }
        finally
        {
            con.Close();
        }*/

        //Table table = new Table();
        TableHeaderRow tableHeader = new TableHeaderRow();
        TableHeaderCell tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Medicine";
        tableHeader.Cells.Add(tableHeaderCell);
        tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Quantity";
        tableHeader.Cells.Add(tableHeaderCell);
        tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Cost";
        tableHeader.Cells.Add(tableHeaderCell);
        tableHeaderCell = new TableHeaderCell();
        tableHeaderCell.Text = "Total cost";
        tableHeader.Cells.Add(tableHeaderCell);
        show_receipt.Rows.Add(tableHeader);

        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = DropDownList1.SelectedValue;
        row.Cells.Add(cell);
        cell = new TableCell();
        cell.Text = TextBox1.Text;
        row.Cells.Add(cell);
        cell = new TableCell();
        cell.Text = TextBox2.Text;
        row.Cells.Add(cell);
        cell = new TableCell();
        cell = new TableCell();
        int val1, val2;
        int.TryParse(TextBox1.Text, out val1);
        int.TryParse(TextBox2.Text, out val2);
        cell.Text = (val1 * val2).ToString();
        row.Cells.Add(cell);
        show_receipt.Rows.Add(row);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        count++;
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Text = "Medicine";
        DropDownList dropDownList = new DropDownList();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select distinct medicine_code, generic_name from medicine", con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dropDownList.ID = "txt-" + count;
                dropDownList.Items.Add(new ListItem(reader["medicine_code"].ToString() + " - " + reader["generic_name"].ToString(), reader["medicine_code"].ToString()));
                //dropDownList.Style.Add()
            }
            TableCell tableCell = new TableCell();
            tableCell.Controls.Add(dropDownList);

            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = "Quantity";
            tableCell = new TableCell();
            TextBox tb = new TextBox();
            tableCell.Controls.Add(tb);
            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = "Cost";
            tableCell = new TableCell();
            tb = new TextBox();
            tableCell.Controls.Add(tb);
            row.Cells.Add(cell);
            row.Cells.Add(tableCell);
            new_row.Rows.Add(row);
        }
        catch(Exception exc)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public void monthly_sale()
    {
        /*l4.Text = "Rachoi";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocaldb; Initial Catalog = Navtara; Integrated Security = True";
        try
        {
            con.Open();
            l4.Text = "";
            DateTime today = DateTime.Today;
            string date = today.ToString();
            string query = "select from sales where date-sales_date < 30";
        }
        catch(Exception exc)
        {
            l4.Text = exc.ToString();
        }
        finally
        {
            con.Close();
        }*/
    }
}