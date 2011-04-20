using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Teacher_CreateClass : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Add class to database
        SqlCommand cmd = new SqlCommand("INSERT INTO Classes(Title, Semester, Grade, Year) VALUES (@ClassTitle, @Sem, @Grade, @Year)", connection);
        cmd.Parameters.AddWithValue("@Classtitle", TextBox1.Text);
        cmd.Parameters.AddWithValue("@Sem", drpSemester.SelectedValue);
        cmd.Parameters.AddWithValue("@Grade", ListBox1.SelectedValue);
        cmd.Parameters.AddWithValue("@Year", TextBox3.Text + "/" + TextBox4.Text);

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        //END Add class to database

        Response.Redirect("AddAssignments.aspx");
    }
}