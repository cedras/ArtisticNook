using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtisticNook
{
    public partial class posts : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPosts();
            }
        }

        private void BindPosts()
        {
            string categoryFilter = ddlCategoryFilter.SelectedValue;
            string artStyleFilter = ddlArtStyleFilter.SelectedValue;
            string subjectMatterFilter = ddlSubjectMatterFilter.SelectedValue;

            string filterValue = ddlFilter.SelectedValue;

            string query = "SELECT a.*, m.username, " +
                           "(SELECT COUNT(*) FROM like_table l WHERE l.post_id = a.id) AS like_count " +
                           "FROM addpost_master_table a " +
                           "INNER JOIN member_master_table m ON a.userid = m.id " +
                           "WHERE 1 = 1";

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                query += " AND a.category = @categoryFilter";
            }

            if (!string.IsNullOrEmpty(artStyleFilter))
            {
                query += " AND a.style = @artStyleFilter";
            }

            if (!string.IsNullOrEmpty(subjectMatterFilter))
            {
                query += " AND a.subject_matter LIKE @subjectMatterFilter";
            }

            if (filterValue == "newest")
            {
                query += " ORDER BY a.date DESC";
            }
            else if (filterValue == "mostliked")
            {
                query += " ORDER BY like_count DESC";
            }

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(categoryFilter))
                    {
                        cmd.Parameters.AddWithValue("@categoryFilter", categoryFilter);
                    }

                    if (!string.IsNullOrEmpty(artStyleFilter))
                    {
                        cmd.Parameters.AddWithValue("@artStyleFilter", artStyleFilter);
                    }

                    if (!string.IsNullOrEmpty(subjectMatterFilter))
                    {
                        cmd.Parameters.AddWithValue("@subjectMatterFilter", "%" + subjectMatterFilter + "%");
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        PostRepeater.DataSource = dt;
                        PostRepeater.DataBind();
                    }
                }
            }
        }

        private DataTable GetPostsFromDatabase(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        protected void btnApplyFilter_Click(object sender, EventArgs e)
        {
            BindPosts();
        }
    }
}