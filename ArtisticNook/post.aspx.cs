using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;

namespace ArtisticNook
{
    public partial class post : System.Web.UI.Page
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
                    DisplayLikeCount(postId);
                    DisplayComments(postId);
                }
            }
        }

        private void PopulatePostDetails(int postId, string postImageUrl)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT a.*, m.username FROM addpost_master_table a " +
                               "INNER JOIN member_master_table m ON a.userid = m.id " +
                               "WHERE a.id = @postId"; 

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Label1.Text = reader["title"].ToString();
                            Label2.Text = reader["description"].ToString();
                            Label3.Text = reader["category"].ToString();
                            Label4.Text = reader["style"].ToString();
                            Label5.Text = reader["subject_matter"].ToString();
                            Label6.Text = "Artist: " + reader["username"].ToString();
                            PostImage.ImageUrl = reader["post_img_link"].ToString();
                        }
                    }
                }
            }
        }
        private void DisplayLikeCount(int postId)
        {

            int likeCount = GetLikeCount(postId);
            LikeCountLabel.Text = likeCount.ToString();
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {

            int postId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = GetCurrentUserId();

            bool hasLiked = CheckIfUserHasLiked(postId, userId);

            if (hasLiked)
            {
                RemoveLike(postId, userId);
            }
            else
            {
                AddLike(postId, userId);
            }

            DisplayLikeCount(postId);
        }


        int GetCurrentUserId()
        {
            if (Session["userId"] != null)
            {
                return Convert.ToInt32(Session["userId"]);
            }
            else
            {
                Response.Redirect("userlogin.aspx");
                return -1;
            }

        }
        private bool CheckIfUserHasLiked(int postId, int userId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM like_table WHERE post_id = @postId AND user_id = @userId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int likeCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return likeCount > 0;
                }
            }
        }

        private void AddLike(int postId, int userId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "INSERT INTO like_table (post_id, user_id) VALUES (@postId, @userId)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void RemoveLike(int postId, int userId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "DELETE FROM like_table WHERE post_id = @postId AND user_id = @userId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private int GetLikeCount(int postId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM like_table WHERE post_id = @postId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        
        protected void PostCommentButton_Click(object sender, EventArgs e)
        {
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            int userId = GetCurrentUserId();
            string commentText = CommentTextBox.Text.Trim(); 

            if (!string.IsNullOrEmpty(commentText))
            {
                SaveComment(postId, userId, commentText);
                CommentTextBox.Text = ""; 
                DisplayComments(postId); 
            }
        }

        private void DisplayComments(int postId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT c.id, c.comment_text, c.user_id, m.username, c.comment_date " +
                               "FROM comments_table c " +
                               "INNER JOIN member_master_table m ON c.user_id = m.id " +
                               "WHERE c.post_id = @postId " +
                               "ORDER BY c.comment_date DESC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        CommentRepeater.DataSource = dt;
                        CommentRepeater.DataBind();
                    }
                }
            }
        }
        private void SaveComment(int postId, int userId, string commentText)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "INSERT INTO comments_table (user_id, post_id, comment_text, comment_date) " +
                               "VALUES (@userId, @postId, @commentText, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@postId", postId);
                    cmd.Parameters.AddWithValue("@commentText", commentText);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        protected void CommentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = e.Item.DataItem as DataRowView;
                int commentUserId = Convert.ToInt32(row["user_id"]);
                Button deleteButton = e.Item.FindControl("DeleteCommentButton") as Button;

                if (Session["role"].Equals("admin"))
                {
                    deleteButton.Visible = true;
                }
                else
                {
                    deleteButton.Visible = false;
                }
            }
        }
        protected void DeleteCommentButton_Click(object sender, EventArgs e)
        {
            int commentId = Convert.ToInt32(((Button)sender).CommandArgument);
            



            DeleteComment(commentId);


            int postId = Convert.ToInt32(Request.QueryString["id"]);
            DisplayComments(postId);
        }

        private bool IsCommentAuthor(int commentId, int userId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT user_id FROM comments_table WHERE id = @commentId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@commentId", commentId);
                    int authorId = Convert.ToInt32(cmd.ExecuteScalar());
                    return authorId == userId;
                }
            }
        }

        private void DeleteComment(int commentId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "DELETE FROM comments_table WHERE id = @commentId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@commentId", commentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
       
    }
}