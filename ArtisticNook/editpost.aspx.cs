using System;
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
    public partial class editpost : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int postId = Convert.ToInt32(Request.QueryString["id"]);
                    string postImageUrl = Request.QueryString["img"];
                    PopulatePostDetails(postId, postImageUrl);
                    
                }
            }
        }

        

        private void PopulatePostDetails(int postId, string postImageUrl)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT a.*, m.username FROM addpost_master_table a " +
               "INNER JOIN member_master_table m ON a.userid = m.id " +
               "WHERE a.id = @postId", con);
                cmd.Parameters.AddWithValue("@postId", postId);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                

                TextBox1.Text = dt.Rows[0]["title"].ToString();
                TextBox2.Text = dt.Rows[0]["description"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["category"].ToString();
                DropDownList2.SelectedValue = dt.Rows[0]["style"].ToString();
                ListBox1.SelectedValue = dt.Rows[0]["subject_matter"].ToString();
                PostImage.ImageUrl = dt.Rows[0]["post_img_link"].ToString();
               
            }
            catch (Exception ex) 
            {
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            string postImageUrl = Request.QueryString["img"];
            updatePost(postId, postImageUrl);
            Response.Redirect("userprofile.aspx");
        }

        void updatePost(int postId, string postImageUrl)
        {
            try
            {
                string subject_matters = string.Join(",", ListBox1.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value));

                string filepath = postImageUrl; 

                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("post_images/" + filename));
                    filepath = "~/post_images/" + filename; 
                }

                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    string query = "UPDATE addpost_master_table " +
                                   "SET title = @title, description = @description, category = @category, " +
                                   "style = @style, subject_matter = @subjectMatter, post_img_link = @postImgLink, date = @date " +
                                   "WHERE id = @postId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@postId", postId);
                        cmd.Parameters.AddWithValue("@title", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", DropDownList1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@style", DropDownList2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@subjectMatter", subject_matters);
                        cmd.Parameters.AddWithValue("@postImgLink", filepath);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                            PopulatePostDetails(postId, filepath);
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid entry');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            deletePost(postId);
            Response.Redirect("userprofile.aspx");
        }

        void deletePost(int postId)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM addpost_master_table WHERE id = @postId", con);
                cmd.Parameters.AddWithValue("@postId", postId);

                int result = cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {
                    Response.Write("<script>alert('Post Deleted Successfully');</script>");                  
                }
                else
                {
                    Response.Write("<script>alert('Failed to delete the post');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}