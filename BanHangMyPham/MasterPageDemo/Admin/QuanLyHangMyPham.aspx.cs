using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyHangGiay : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"].ToString().Equals(""))
                {
                    Response.Redirect("DangNhap.aspx");
                }
                else
                {
                    FormNhapHangMyPham.Visible = false;
                    LoadGridView();
                }
            }
        }
        void LoadGridView()
        {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetHangMyPhamAdmin", null, null);
            if (dt != null)
            {
                grvHangMyPham.DataSource = dt;
                grvHangMyPham.DataBind();
            }
        }

        protected void grvHangMyPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemOK.Enabled = false;
            btnThemOK.Visible = false;

            btnOK.Enabled = true;
            btnOK.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            FormNhapHangMyPham.Visible = true;

            string id = grvHangMyPham.SelectedDataKey.Value.ToString();
            DataTable dt = kn.ExecuteQuery("GetHangMyPhamAdmin", new object[] { id }, new List<string> { "@iHangMyPham" });
            if (dt != null)
            {
                txtHang.Text = dt.Rows[0]["sTenHang"].ToString();
                txtDiaChi.Text = dt.Rows[0]["sDiaChi"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateHangMyPhamAdmin", new object[] { grvHangMyPham.SelectedDataKey.Value, txtHang.Text, txtDiaChi.Text }, new List<string> { "@iHangMyPham", "@sTenHang", "@sDiaChi" });
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

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("InsertHangMyPhamAdmin", new object[] { txtHang.Text, txtDiaChi.Text }, new List<string> { "@sTenHang", "@sDiaChi" });
            if (kq != 0)
            {
                Response.Write("<script>alert('Thêm thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            FormNhapHangMyPham.Visible = false;

            btnThem.Visible = true;
            btnThem.Enabled = true;

            txtHang.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            FormNhapHangMyPham.Visible = true;
            btnThem.Enabled = false;
            btnThem.Visible = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;
        }


    }
}