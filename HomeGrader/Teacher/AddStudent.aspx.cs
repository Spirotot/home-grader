using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Teacher_AddStudent : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Add student to DB
        SqlCommand cmd = new SqlCommand("INSERT INTO Students(Fname, Lname) VALUES (@first, @last)", connection);
        cmd.Parameters.AddWithValue("@first", TextBox1.Text);
        cmd.Parameters.AddWithValue("@last", TextBox2.Text);

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
        //END Add student to DB
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddClassToStudent.aspx");
    }
}