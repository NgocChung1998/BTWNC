using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Session["name"].Equals(""))
                {
                   Response.Redirect("ThongTinCaNhan.aspx");
                }
                txtUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangNhap.ClientID + "')");
                txtPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangNhap.ClientID + "')");
               
            } 
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.ToString();
            string password = txtPassword.Text.ToString();

            if (username == "" || password == "")
            {
                Response.Write("<script>alert('lỗi đường truyền');</script>");
               
            }
            else {
                ketnoi kn = new ketnoi();
                DataTable dt = kn.ExecuteQuery("XacThucDangNhap", new object[] { username, password }, new List<string> { "@sUserName", "@sPass" });
                if (dt!=null && dt.Rows.Count > 0)
                {
                    Session["name"] = username;
                    HttpCookie cookie = new HttpCookie("LoginInf");
                    cookie.Value = Session["name"].ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("TrangChu.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu');</script>");
                    txtPassword.Text = "";
                }
            }
        }

    }
}