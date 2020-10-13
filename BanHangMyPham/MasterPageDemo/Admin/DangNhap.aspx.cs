using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Session["admin"].Equals(""))
                {
                    Response.Redirect("QuanLySanPham.aspx");
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
            else
            {
                ketnoi kn = new ketnoi();
                DataTable dt = kn.ExecuteQuery("XacThucAdmin", new object[] { username, password }, new List<string> { "@sUserName", "@sPassword" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["admin"] = username;
                    HttpCookie admin = new HttpCookie("AdminInf");
                    admin.Value = Session["admin"].ToString();
                    admin.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(admin);
                    Response.Redirect("QuanLySanPham.aspx");
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