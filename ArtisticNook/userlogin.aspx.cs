﻿using System;
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
    public partial class loginpage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_table where username='" + TextBox1.Text.Trim() + "' AND password='"+ TextBox2.Text.Trim() + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows) 
                {
                    while(reader.Read()) 
                    {
                        Response.Write("<script>alert('" + reader.GetValue(8).ToString() + "');</script>");
                        Session["username"] = reader.GetValue(8).ToString();
                        Session["fullname"] = reader.GetValue(1).ToString();
                        Session["role"] = "user";
                        Session["status"] = reader.GetValue(10).ToString();
                        Session["userid"] = reader.GetValue(0).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }
            }
            catch (Exception ex) 
            {
                
            }

        }
    }
}