using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtisticNook
{
    public partial class viewprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user_id parameter is in the query string
                if (!string.IsNullOrEmpty(Request.QueryString["user_id"]))
                {

                    int userIdToView = Convert.ToInt32(Request.QueryString["user_id"]);
                    if (int.TryParse(Request.QueryString["user_id"], out userIdToView))
                    {
                        GetUserProfileData(userIdToView); // Load the user's profile
                        LoadUserPosts(userIdToView); // Load the user's posts
                    }
                }
            }
        }

        void GetUserProfileData(int userIdToView)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table WHERE id = @UserIdToView", con);
                cmd.Parameters.AddWithValue("@UserIdToView", userIdToView);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    // Bind data to labels and set the account status label's class
                    Label2.Text = dt.Rows[0]["full_name"].ToString();
                    Label3.Text = dt.Rows[0]["date_of_birth"].ToString();
                    Label5.Text = dt.Rows[0]["email"].ToString();
                    Label6.Text = dt.Rows[0]["state"].ToString().Trim();
                    Label7.Text = dt.Rows[0]["city"].ToString();
                    Label8.Text = dt.Rows[0]["zip_code"].ToString();
                    Label9.Text = "User Profile for " + dt.Rows[0]["username"].ToString();

                    Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                    if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-success");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-warning text-dark");
                    }
                    else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-danger");
                    }
                    else
                    {
                        Label1.Attributes.Add("class", "badge rounded-pill bg-info");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
            }
        }

        void LoadUserPosts(int userIdToView)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // Modify your SQL query to load posts for the specific user
                string query = "SELECT * FROM addpost_master_table WHERE userid = @UserIdToView";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserIdToView", userIdToView);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                // Bind the user's posts to the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
            }
        }
    }
}
