using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Teacher_View : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownList1.SelectedIndex = 0;

            SqlCommand cmd = new SqlCommand("SELECT id, Fname + Lname AS Name FROM Students", connection);

            connection.Open();
            SqlDataReader r = cmd.ExecuteReader();
            DropDownList1.DataSource = r;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            r.Close();
            connection.Close();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.AppendDataBoundItems = true;
        DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList2.SelectedIndex = 0;

        SqlCommand cmd = new SqlCommand("SELECT DISTINCT Classes.Year AS Year, Classes.id AS id FROM Classes, Assignments WHERE SID = @StudID AND Assignments.CID = Classes.id", connection);
        cmd.Parameters.AddWithValue("@StudID", DropDownList1.SelectedValue);

        connection.Open();
        SqlDataReader r = cmd.ExecuteReader();
        DropDownList2.DataSource = r;
        DropDownList2.DataTextField = "Year";
        DropDownList2.DataValueField = "Year";
        DropDownList2.DataBind();
        r.Close();
        connection.Close();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.AppendDataBoundItems = true;
        DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList3.Items.Insert(1, new ListItem("Fall", "Fall"));
        DropDownList3.Items.Insert(2, new ListItem("Spring", "Spring"));
        DropDownList3.SelectedIndex = 0;
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        String cmdStr = "SELECT Classes.Title, Classes.id FROM Classes, Assignments WHERE Classes.id = Assignments.CID AND (1 = 2 ";

        foreach (ListItem li in DropDownList2.Items)
        {
            if (li.Selected == true)
            {
                cmdStr = cmdStr + "OR Classes.Year = '" + li.Value.ToString() + "' ";
            }
        }

        cmdStr = cmdStr + ") AND (1=2 ";

        foreach (ListItem li in DropDownList3.Items)
        {
            if (li.Selected == true)
            {
                cmdStr = cmdStr + "OR Classes.Semester = '" + li.Value.ToString() + "' ";
            }
        }

        cmdStr = cmdStr + ")";

        System.Diagnostics.Debug.WriteLine(cmdStr);
        SqlCommand cmd = new SqlCommand(cmdStr, connection);

        connection.Open();
        SqlDataReader r = cmd.ExecuteReader();

        ListBox1.DataSource = r;
        ListBox1.DataTextField = "Title";
        ListBox1.DataValueField = "id";
        ListBox1.DataBind();
        connection.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}