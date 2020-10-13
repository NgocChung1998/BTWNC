using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin.MasterPage
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"].ToString().Equals(""))
                {
                    lblHelloSession.Text = "Hello, How are you?";
                    btnLogout.Enabled = false;
                    btnLogout.Visible = false;
                }
                else
                {
                    ketnoi kn = new ketnoi();
                    using (DataTable dt = kn.laybang("SELECT dbo.tblAdmin.sTenAdmin FROM dbo.tblAdmin WHERE sUsername ='" + Session["admin"] + "'"))
                    {
                        if (dt != null) {
                            lblHelloSession.Text = "Chào: " + dt.Rows[0][0];
                        }
                        else
                        {
                            lblHelloSession.Text = "Hello " + Session["admin"];
                        }

                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Session.Contents.RemoveAll();
            Session.Abandon();
            string[] cookies = Request.Cookies.AllKeys;
            foreach (string ck in cookies)
            {
                Response.Cookies[ck].Expires = DateTime.Now.AddDays(-1);
            }
            Session["admin"] = "";
            Response.Redirect("DangNhap.aspx");
        }

    }
}