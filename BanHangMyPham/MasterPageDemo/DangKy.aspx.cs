using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangKy.ClientID + "')");
                txtPassword.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangKy.ClientID + "')");
                txtHoTen.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangKy.ClientID + "')");
                txtDiaChi.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangKy.ClientID + "')");
                txtSDT.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangKy.ClientID + "')");
            }
        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == null || txtPassword.Text == null || txtHoTen.Text == null || txtDiaChi.Text == null || txtSDT.Text == null)
            {
                Response.Write("<script>alert('lỗi đường truyền');</script>");
            }
            else
            {
                ketnoi kn = new ketnoi();
                object[] para = new object[] { txtUsername.Text, txtPassword.Text, txtHoTen.Text, txtDiaChi.Text, txtSDT.Text };
                List<string> paraName = new List<string> { "@sUserName", "@sPass", "@sTenKH", "@sDiaChi", "@sSDT" };
                int kq = kn.ExecuteNonQuery("DangKyUser", para, paraName);

                if (kq != 0)
                {


                    //lấy id khách hàng từ username
                    DataTable dt = kn.laybang("SELECT iID FROM dbo.tblUser WHERE sUsername =N'" + txtUsername.Text+"'");
                    string iMaKH = dt.Rows[0][0].ToString();
                    //thêm bảng giỏ hàng
                    object[] para1 = new object[] { iMaKH };
                    List<string> paraName1 = new List<string> { "@iMaKH" };
                    kn.ExecuteNonQuery("sp_ThemGioHang", para1, paraName1);
                    Response.Write("<script>alert('Đăng ký thành công');</script>");
                    Response.Redirect("DangNhap.aspx?");
                }
                else
                {
                    Response.Write("<script>alert('Username trùng, mời nhập giá trị khác');</script>");
                    txtUsername.Focus();
                }
            }


        }
    }
}

