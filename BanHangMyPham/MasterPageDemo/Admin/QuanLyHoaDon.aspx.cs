using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyHoaDon : System.Web.UI.Page
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
                //Response.Write("Đăng nhập thành công");
                LoadGridView();
                txtDiaChi.Attributes.Add("onkeypress", "return clickButton(event,'" + btnOK.ClientID + "')");
                FormNhapHoaDon.Visible = false;   
            }
        }

        void LoadGridView()
        {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetHoaDonAdmin", null, null);
            if (dt != null)
            {
                grvHoaDon.DataSource = dt;
                grvHoaDon.DataBind();
            }
        }

        protected void grvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormNhapHoaDon.Visible = true;
            string id = grvHoaDon.SelectedDataKey.Value.ToString();
            lblID.Text = id;
            DataTable dt = kn.ExecuteQuery("GetHoaDonAdmin", new object[] { id }, new List<string> { "@iMaHD" });
            if (dt != null)
            {
                txtDiaChi.Text = dt.Rows[0]["sDiaChi"].ToString();
                grvCTHD.DataSource = kn.ExecuteQuery("GetCTHDAdmin", new object[] { id }, new List<string> { "@iMaHD" });
                grvCTHD.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateHoaDonAdmin", new object[] { grvHoaDon.SelectedDataKey.Value, txtDiaChi.Text}, new List<string> { "@iMaHD", "@sDiaChi"});
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
            FormNhapHoaDon.Visible = false;
            lblID.Text = "";
            txtDiaChi.Text = string.Empty;
        }

    }
}