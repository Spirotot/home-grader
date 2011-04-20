using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Teacher_AddAssignments : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToShortDateString();
            drpStudent.Items.Clear();
            drpStudent.AppendDataBoundItems = true;
            drpStudent.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            drpStudent.SelectedIndex = 0;

            //Grab students...
            SqlCommand cmd = new SqlCommand("SELECT id, Fname + Lname AS Name FROM Students", connection);
            connection.Open();
            SqlDataReader r = cmd.ExecuteReader();
            drpStudent.DataSource = r;
            drpStudent.DataTextField = "Name";
            drpStudent.DataValueField = "id";
            drpStudent.DataBind();
            r.Close();
            connection.Close();
            //END Grab students...

            drpSchoolYear.Items.Clear();
            drpSchoolYear.AppendDataBoundItems = true;
            drpSchoolYear.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            drpSchoolYear.SelectedIndex = 0;
            //Grab schoolyears
            cmd = new SqlCommand("SELECT DISTINCT Year FROM Classes", connection);
            connection.Open();
            r = cmd.ExecuteReader();
            drpSchoolYear.DataSource = r;
            drpSchoolYear.DataTextField = "Year";
            drpSchoolYear.DataValueField = "Year";
            drpSchoolYear.DataBind();
            r.Close();
            connection.Close();
            //END Grab schoolyears

            //Set up panels...
            chooseClassPanel.Visible = true;
            addAssignmentPanel.Visible = false;
            //END Set up panels...
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
    }
    protected void drpSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpClass.Items.Clear();
        drpClass.AppendDataBoundItems = true;
        drpClass.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        drpClass.SelectedIndex = 0;
        //Populate Classes dropdown...
        SqlCommand cmd = new SqlCommand("SELECT Title, id FROM Classes WHERE Semester = @Semester AND Year = @Year", connection);
        cmd.Parameters.AddWithValue("@Semester", drpSemester.SelectedValue);
        cmd.Parameters.AddWithValue("@Year", drpSchoolYear.SelectedValue);

        connection.Open();
        SqlDataReader r = cmd.ExecuteReader();
        drpClass.DataSource = r;
        drpClass.DataTextField = "Title";
        drpClass.DataValueField = "id";
        drpClass.DataBind();
        r.Close();
        connection.Close();
        //END Populate Classes dropdown...
    }
    protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Swap panel visibilities
        chooseClassPanel.Visible = false;
        addAssignmentPanel.Visible = true;
        lblClassTitle.Text = drpClass.SelectedItem.ToString();
        //END Swap panel visibilities
    }
    protected void btnAddAssign_Click(object sender, EventArgs e)
    {
        //Add assignment
        SqlCommand cmd = new SqlCommand("INSERT INTO Assignments(SID, CID, Title, PossibleScore, Date) VALUES (@SID, @CID, @Title, @PossibleScore, @Date)", connection);
        cmd.Parameters.AddWithValue("@SID", drpStudent.SelectedValue);
        cmd.Parameters.AddWithValue("@CID", drpClass.SelectedValue);
        cmd.Parameters.AddWithValue("@Title", txtAssignmentTitle.Text);
        cmd.Parameters.AddWithValue("@PossibleScore", txtPossibleScore.Text);
        cmd.Parameters.AddWithValue("@Date", Calendar1.SelectedDate.ToShortDateString());

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();

        //END Add assignment
    }
}