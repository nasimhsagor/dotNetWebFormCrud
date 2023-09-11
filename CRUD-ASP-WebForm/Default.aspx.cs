using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace CRUD_ASP_WebForm
{
    public partial class _Default : Page
    {
        private readonly string connctionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connctionString))
                {
                    string cmdText = "SELECT * FROM tblStudent";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(xSqlCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    grvStudent.DataSource = ds;
                    grvStudent.DataBind();
                }
            }
        }

        protected void IdLinkButtonDob_Click(object sender, EventArgs e)
        {

        }

        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            if (hdID.Value == "")
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connctionString))
                {
                    string cmdText = "INSERT INTO tblStudent (FirstName,LastName,Gender,Grade,DOB) VALUES(@firstname,@lastname,@gender,@grade,@dob)";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@firstname", IdtxtFirstName.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@lastname", IdtxtLastName.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@gender", IdRbListGender.SelectedValue);
                    xSqlCommand.Parameters.AddWithValue("@grade", IdDdListGrade.SelectedValue);
                    xSqlCommand.Parameters.AddWithValue("@dob", IdtxtDtp.Text.Trim());

                    xSqlConnection.Open();
                    int isInserted = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                    if (isInserted > 0)
                    {
                        lblMessage.Text = "Data Saved Sucessfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Saved.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connctionString))
                {
                    string cmdText = " UPDATE tblStudent SET FirstName=@firstname,LastName=@lastname,Gender=@gender,Grade=@grade,DOB=@dob WHERE ID=@id";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@id", hdID.Value);
                    xSqlCommand.Parameters.AddWithValue("@firstname", IdtxtFirstName.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@lastname", IdtxtLastName.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@gender", IdRbListGender.SelectedValue);
                    xSqlCommand.Parameters.AddWithValue("@grade", IdDdListGrade.SelectedValue);
                    xSqlCommand.Parameters.AddWithValue("@dob", IdtxtDtp.Text.Trim());

                    xSqlConnection.Open();
                    int isUpdated = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                    if (isUpdated > 0)
                    {
                        lblMessage.Text = "Data Updated Sucessfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void grvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = row.RowIndex;
            hdID.Value = grvStudent.DataKeys[index].Value.ToString();

            if (e.CommandName == "EditStudent")
            {
                hdID.Value = grvStudent.DataKeys[index].Value.ToString();
                IdtxtFirstName.Text = grvStudent.Rows[index].Cells[0].Text;
                IdtxtLastName.Text = grvStudent.Rows[index].Cells[1].Text;
                IdRbListGender.SelectedValue = grvStudent.Rows[index].Cells[2].Text;
                IdDdListGrade.SelectedValue = grvStudent.Rows[index].Cells[3].Text;
                IdtxtDtp.Text = DateTime.Parse(grvStudent.Rows[index].Cells[4].Text).ToString("yyyy-MM-dd");
            }
            if (e.CommandName == "DeleteStudent")
            {

              bool isDeleted=  Delete(Convert.ToInt32(hdID.Value));
                if (isDeleted)
                {
                    lblMessage.Text = "Data Deleted Sucessfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Data Not Deleted.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public bool Delete(int ID)
        {
            int isDeleted = 0;
            if (ID != 0)
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connctionString))
                {
                    string cmdText = "DELETE FROM TblStudent WHERE ID=@id";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@id", ID);

                    xSqlConnection.Open();
                    isDeleted = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                }
            }
            return isDeleted>0;
        }
    }
}
