using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtisticNook
{
    public partial class addpost : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            addPost();
        }

        void addPost()
        {
            try
            {


                if (!UserAccountIsActive())
                {
                    Response.Write("<script>alert('Your account is not active. You cannot post at the moment.');</script>");
                    return;
                }

                string subject_matters = "";
                foreach (int i in ListBox1.GetSelectedIndices()) 
                {
                    subject_matters = subject_matters + ListBox1.Items[i] + ",";
                }
                subject_matters = subject_matters.Remove(subject_matters.Length - 1);

                string filepath = "~/post_images/digital-drawing.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("post_images/" + filename));
                filepath = "~/post_images/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO addpost_master_table(userid,title,description,category,style,subject_matter,post_img_link,date) " +
                    "values(@userid,@title,@description,@category,@style,@subject_matter,@post_img_link,@date)", con);

                cmd.Parameters.AddWithValue("@userid", Session["userid"]);
                cmd.Parameters.AddWithValue("@title", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@category", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@style", DropDownList2.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@subject_matter", subject_matters);
                cmd.Parameters.AddWithValue("@post_img_link", filepath);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Post added successfully');</script>");
                
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        private bool UserAccountIsActive()
        {
            // Implement the logic to check the user's account status.
            // You should fetch the account status from your database based on the user's Session["userid"].

            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT account_status FROM member_master_table WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@id", Session["userid"]);

            string accountStatus = cmd.ExecuteScalar() as string;

            con.Close();

            // Check the account status here, and return true if the account is active, otherwise, return false.
            return (accountStatus == "active");
        }


    }
}