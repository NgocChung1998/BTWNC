using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLyLoaiGiay : System.Web.UI.Page
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
                    FormNhapLoaiMyPham.Visible = false;
                    LoadGridView();
                }
            }
        }

        void LoadGridView() {
            DataTable dt = new DataTable();
            dt = kn.ExecuteQuery("GetLoaiMyPhamAdmin", null, null);
            if (dt != null)
            {
                grvLoaiMyPham.DataSource = dt;
                grvLoaiMyPham.DataBind();
            }
        }

        protected void grvLoaiMyPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemOK.Enabled = false;
            btnThemOK.Visible = false;

            btnOK.Enabled = true;
            btnOK.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            FormNhapLoaiMyPham.Visible = true;

            string id = grvLoaiMyPham.SelectedDataKey.Value.ToString();
            DataTable dt = kn.ExecuteQuery("GetLoaiMyPhamAdmin", new object[] { id }, new List<string> {"@iMaLoaiMyPham" });
            if (dt != null)
            {
                txtLoaiMyPham.Text = dt.Rows[0]["sTenLoaiMyPham"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("UpdateLoaiMyPhamAdmin", new object[] { grvLoaiMyPham.SelectedDataKey.Value, txtLoaiMyPham.Text }, new List<string> {"@iMaLoaiMyPham", "@sTenLoaiMyPham" });
            if (kq != 0)
            {
                Response.Write("<script>alert('Cập nhật thành công');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('Lỗi');</script>");
            }
        }

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            int kq = kn.ExecuteNonQuery("InsertLoaiMyPhamAdmin", new object[] { txtLoaiMyPham.Text }, new List<string> {"@sTenLoaiMyPham" });
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
            FormNhapLoaiMyPham.Visible = false;

            btnThem.Visible = true;
            btnThem.Enabled = true;

            txtLoaiMyPham.Text = string.Empty;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            FormNhapLoaiMyPham.Visible = true;

            btnThem.Enabled = false;
            btnThem.Visible = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;
        }
    }
}