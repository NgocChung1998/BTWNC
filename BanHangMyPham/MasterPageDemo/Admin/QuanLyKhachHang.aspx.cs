using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyKhachHang : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                FormNhapKhachHang.Visible = false;
                LoadGridView();
                txtUsername.Attributes.Add("onkeypress", "return clickButton(event,'" + btnOK.ClientID + "')");
                txtHoTen.Attributes.Add("onkeypress", "return clickButton(event,'" + btnOK.ClientID + "')");
                txtDiaChi.Attributes.Add("onkeypress", "return clickButton(event,'" + btnOK.ClientID + "')");
                txtSDT.Attributes.Add("onkeypress", "return clickButton(event,'" + btnOK.ClientID + "')");
            }
        }
        void LoadGridView()
        {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetKhachHangAdmin", null, null);
            if (dt != null)
            {
                grvUser.DataSource = dt;
                grvUser.DataBind();
            }
        }

        protected void grvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormNhapKhachHang.Visible = true;

            string id = grvUser.SelectedDataKey.Value.ToString();
            DataTable dt = kn.ExecuteQuery("GetKhachHangAdmin", new object[] { id }, new List<string> { "@iID" });
            if (dt != null)
            {
                txtUsername.Text = dt.Rows[0]["sUsername"].ToString();
                txtHoTen.Text = dt.Rows[0]["sTenKH"].ToString();
                txtDiaChi.Text = dt.Rows[0]["sDiaChi"].ToString();
                txtSDT.Text = dt.Rows[0]["sSDT"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateKhachHangAdmin", new object[] { grvUser.SelectedDataKey.Value, txtUsername.Text, txtHoTen.Text, txtDiaChi.Text, txtSDT.Text }, new List<string> { "@iID", "@sUsername", "@sTenKH", "@sDiaChi", "@sSDT" });
            if (kq != 0)
            {
                Response.Write("<script>alert('Update thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            FormNhapKhachHang.Visible = false;

            txtUsername.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
        }
    }
}