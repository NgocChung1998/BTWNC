using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Session["name"].Equals(""))
                {
                    ketnoi kn = new ketnoi();

                    //lấy id khách hàng từ username
                    DataTable dt = kn.laybang("SELECT iID FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
                    int iMaKH = int.Parse(dt.Rows[0][0].ToString());
                    //lấy mã giỏ hàng từ id khách hàng
                    dt = kn.laybang("SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH =" + iMaKH);
                    int iMaGH = int.Parse(dt.Rows[0][0].ToString());
                    grv1.DataSource = kn.laybang("sp_XemChiTietGioHang " + iMaGH);
                    grv1.DataBind();
                }
                else
                {
                    Response.Redirect("DangNhap.aspx");
                }
            }
            else
            {
                lblTongTien.Text = "0";
                foreach (GridViewRow row in grv1.Rows)
                {
                    TextBox soluong = (TextBox)row.FindControl("soluong_giohang");
                    Label lblGia = (Label)row.FindControl("lblGia");
                    lblTongTien.Text = (int.Parse(lblTongTien.Text) + (int.Parse(soluong.Text) * int.Parse(lblGia.Text))).ToString();
                }
            }

        }
        protected void grv1_DataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ketnoi kn = new ketnoi();
                int idmypham = Convert.ToInt32(
                DataBinder.Eval(e.Row.DataItem, "iID"));
                int MaGH = Convert.ToInt32(
                DataBinder.Eval(e.Row.DataItem, "iMaGH"));
                int size = Convert.ToInt32(
                DataBinder.Eval(e.Row.DataItem, "iSize"));
                TextBox ltr = (TextBox)e.Row.FindControl("soluong_giohang");
                Label lbl = (Label)e.Row.FindControl("lblindex");
                Label lblGia = (Label)e.Row.FindControl("lblGia");
                Label lblsize = (Label)e.Row.FindControl("lblsize");
                Label lblIDMyPham = (Label)e.Row.FindControl("lblIDMyPham");

                RangeValidator CheckSoLuong = (RangeValidator)e.Row.FindControl("CheckSoLuong");

                if (CheckSoLuong != null)
                {
                    DataTable dt;
                    dt = kn.laybang("Select * from tblMyPham_ChiTiet where iID ='" + idmypham + "'");
                    CheckSoLuong.Type = ValidationDataType.Integer;
                    CheckSoLuong.MinimumValue = "0";
                    CheckSoLuong.MaximumValue = dt.Rows[0][3].ToString();
                }
                else
                {
                    CheckSoLuong.Type = ValidationDataType.Integer;
                    CheckSoLuong.MinimumValue = "0";
                    CheckSoLuong.MaximumValue = "0";
                }
                if (lbl != null)
                {
                    lbl.Text = (e.Row.RowIndex + 1).ToString();
                }
                if (lblGia != null)
                {
                    lblGia.Text = DataBinder.Eval(e.Row.DataItem, "fGia").ToString();
                }
                if (lblsize != null)
                {
                    lblsize.Text = DataBinder.Eval(e.Row.DataItem, "iSize").ToString();
                }
                if (lblIDMyPham!=null)
                {
                    lblIDMyPham.Text = idmypham.ToString();
                }
                if (ltr != null)
                {
                    ltr.Text = DataBinder.Eval(e.Row.DataItem, "iSoLuong").ToString();
                    lblTongTien.Text = (int.Parse(lblTongTien.Text) + (int.Parse(ltr.Text) * int.Parse(lblGia.Text))).ToString();
                
                }



            }

        }

        protected void grv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!Session["name"].Equals(""))
            {
                ketnoi kn = new ketnoi();

                //lấy id khách hàng từ username
                DataTable dt = kn.laybang("SELECT iID FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
                int iMaKH = int.Parse(dt.Rows[0][0].ToString());
                //lấy mã giỏ hàng từ id khách hàng
                dt = kn.laybang("SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH =" + iMaKH);
                int iMaGH = int.Parse(dt.Rows[0][0].ToString());

                //lấy 3 khóa chính của bảng CTGH để xóa
                dt = kn.laybang("sp_XemChiTietGioHang " + iMaGH);
                string temp1 = dt.Rows[e.RowIndex]["iMaGH"].ToString();
                string temp2 = dt.Rows[e.RowIndex]["iID"].ToString();
                string temp3 = dt.Rows[e.RowIndex]["iSize"].ToString();
                //sql xóa do lười viết proc hihi
                string sql = ("DELETE FROM dbo.tblChiTietGioHang WHERE iMaGH = " + temp1 + " AND iID = " + temp2 + " AND iSize = " + temp3);

                /*Cập nhật giá tiền khi xóa*/
                string slg = dt.Rows[e.RowIndex]["iSoLuong"].ToString();
                string gia = dt.Rows[e.RowIndex]["fGia"].ToString();
                lblTongTien.Text = (int.Parse(lblTongTien.Text) - (int.Parse(slg) * int.Parse(gia))).ToString();


                if (kn.xulydulieu(sql) != 0)
                {
                    grv1.DataSource = kn.laybang("sp_XemChiTietGioHang " + iMaGH);
                    grv1.DataBind();
                }
            }
            else
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ketnoi kn = new ketnoi();

            //lấy id khách hàng từ username
            DataTable dt = kn.laybang("SELECT iID FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
            int iMaKH = int.Parse(dt.Rows[0][0].ToString());
            //lấy mã giỏ hàng từ id khách hàng
            dt = kn.laybang("SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH =" + iMaKH);
            int iMaGH = int.Parse(dt.Rows[0][0].ToString());
            foreach (GridViewRow row in grv1.Rows)
            {
                TextBox soluong = (TextBox)row.FindControl("soluong_giohang");
                Label lblsize = (Label)row.FindControl("lblsize");
                Label lblIDGiay = (Label)row.FindControl("lblIDMyPham");
                Response.Write(lblIDGiay.Text);
                //set lại số lượng tốn công vc
                kn.xulydulieu("UPDATE dbo.tblChiTietGioHang SET iSoLuong =" + soluong.Text + "WHERE iMaGH ="+ iMaGH +"AND iID ="+lblIDGiay.Text+" AND iSize ="+lblsize.Text);
            }
           Response.Redirect("ThanhToan.aspx");
        }


    }
}