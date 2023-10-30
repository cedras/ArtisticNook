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
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getUserByID();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateStatus("active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateStatus("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateStatus("deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_table where username='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void getUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_table where username='" + TextBox1.Text.Trim() +  "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TextBox2.Text = reader.GetValue(1).ToString();
                        TextBox7.Text = reader.GetValue(10).ToString();
                        TextBox8.Text = reader.GetValue(2).ToString();
                        TextBox3.Text = reader.GetValue(3).ToString();
                        TextBox4.Text = reader.GetValue(4).ToString();
                        TextBox9.Text = reader.GetValue(5).ToString();
                        TextBox10.Text = reader.GetValue(6).ToString();
                        TextBox11.Text = reader.GetValue(7).ToString();

                        
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('username does not exist');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }

        void updateStatus(string status)
        {
            if(checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_table SET account_status='" + status + "' WHERE  username='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    TextBox7.Text = status;
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Response.Write("<script>alert('username does not exist');</script>");
            }
            
        }

        void deleteUser()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_table WHERE username='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Successfully');</script>");
                    clearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('username does not exist');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            
        }
    }
}