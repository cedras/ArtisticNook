using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtisticNook
{
    public partial class MainSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false;
                    LinkButton10.Visible = false;
                    LinkButton4.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton10.Visible = false;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = true;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton10.Visible = true;
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello Admin";
                    LinkButton4.Visible = true;
                }
            }
            catch(Exception ex)
            { 
            
            }
            
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            LinkButton1.Visible = true;
            LinkButton2.Visible = true;
            LinkButton3.Visible = false;
            LinkButton7.Visible = false;
            LinkButton10.Visible = false;
            LinkButton4.Visible = false;
            Response.Redirect("homepage.aspx");

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("posts.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}