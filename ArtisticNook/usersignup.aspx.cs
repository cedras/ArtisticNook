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
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfExists())
            {
                Response.Write("<script>alert('Username already taken, please try some other username');</script>");
            }
            else
            {
                if (IsDateOfBirthValid(TextBox3.Text))
                {
                    signUp();
                }
                else
                {
                    Response.Write("<script>alert('You must be at least 12 years old');</script>");
                }
            }
        }



        bool checkIfExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_table WHERE username='" + TextBox5.Text.Trim()+"';", con);
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

        void signUp()
        {
            //Response.Write("<script>alert('Testing');</script>");

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_table(full_name,date_of_birth,phone_number,email,state,city,zip_code,username,password,account_status) VALUES(@full_name,@date_of_birth,@phone_number,@email,@state,@city,@zip_code,@username,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@date_of_birth", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@phone_number", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@zip_code", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            Response.Redirect("userlogin.aspx");
        }
        private bool IsDateOfBirthValid(string dob)
        {
            if (DateTime.TryParse(dob, out DateTime dateOfBirth))
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;

                if (age >= 12)
                {
                    return true;
                }
            }
            return false;
        }
    }

}