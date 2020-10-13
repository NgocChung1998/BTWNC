using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.MasterPage
{
    public partial class client : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //chào khách
                if (Session["name"].ToString().Equals(""))
                {
                    lblHelloSession.Text = "Chào khách";
                    btnLogout.Visible = false;
                }
                else
                {
                    ketnoi kn = new ketnoi();
                    using (DataTable dt = kn.laybang("	SELECT dbo.tblUser.sTenKH FROM dbo.tblUser WHERE sUsername ='" + Session["name"] + "'"))
                    {
                        if (dt != null) { lblHelloSession.Text = "Chào: " + dt.Rows[0][0]; }
                        else
                        { lblHelloSession.Text = "Chào: " + Session["name"]; }

                    }
                }
                //tìm kiếm
                TextBox1.Attributes.Add("onkeypress", "return clickButton(event,'" + ImageButton1.ClientID + "')");
                TextBox2.Attributes.Add("onkeypress", "return clickButton(event,'" + ImageButton1.ClientID + "')");

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (TextBox1.Text != null)
            { Response.Redirect("TimKiem.aspx?value=" + TextBox1.Text); }
            else
            {
                if (TextBox2.Text != null)
                { Response.Redirect("TimKiem.aspx?value=" + TextBox2.Text); }
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
            Session["name"] = "";
            Response.Redirect("TrangChu.aspx");
        }
    }
}