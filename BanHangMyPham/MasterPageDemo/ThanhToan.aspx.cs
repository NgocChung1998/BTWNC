using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!Session["name"].Equals(""))
                {
                    ketnoi kn = new ketnoi();

                    //lấy id khách hàng từ username
                    DataTable dt = kn.laybang("SELECT * FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
                    int iMaKH = int.Parse(dt.Rows[0]["iID"].ToString());
                    //gán info khách vào txt
                    txtten.Text = dt.Rows[0]["sTenKH"].ToString();
                    txtdiachi.Text = dt.Rows[0]["sDiaChi"].ToString();
                    txtsdt.Text = dt.Rows[0]["sSDT"].ToString();
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
            else {
                if (Session["name"].Equals(""))
                { Response.Redirect("DangNhap.aspx"); }
            }
        }
        protected void grv1_DataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ketnoi kn = new ketnoi();

                int soluong = Convert.ToInt32(
               DataBinder.Eval(e.Row.DataItem, "iSoLuong"));

                int gia = Convert.ToInt32(
               DataBinder.Eval(e.Row.DataItem, "fGia"));

                Label lbl = (Label)e.Row.FindControl("lblindex");
                Label lblsize = (Label)e.Row.FindControl("lblsize");
                Label lblGia = (Label)e.Row.FindControl("lblGia");
                Label soluong_giohang = (Label)e.Row.FindControl("soluong_giohang");
                Label lblIDMyPham = (Label)e.Row.FindControl("lblIDMyPham");

                if (lbl != null)
                {
                    lbl.Text = (e.Row.RowIndex + 1).ToString();
                }
                if (lblsize != null)
                {
                    lblsize.Text = DataBinder.Eval(e.Row.DataItem, "iSize").ToString();
                }
                if (lblGia != null)
                {
                    lblGia.Text = gia.ToString();
                }
                if (soluong_giohang != null)
                {
                    soluong_giohang.Text = soluong.ToString();
                }
                if (lblIDMyPham != null)
                {
                    lblIDMyPham.Text = DataBinder.Eval(e.Row.DataItem, "iID").ToString();
                }


                lblTongtien.Text = (int.Parse(lblTongtien.Text) + (soluong * gia)).ToString();


            }

        }

        protected void btnXacNhanthanhtoan_Click(object sender, EventArgs e)
        {
            if (!Session["name"].Equals(""))
            {
                ketnoi kn = new ketnoi();

                //lấy id khách hàng từ username
                DataTable dt = kn.laybang("SELECT * FROM dbo.tblUser WHERE sUsername =N'" + Session["name"].ToString() + "'");
                int iMaKH = int.Parse(dt.Rows[0]["iID"].ToString());
                //thêm dữ liệu bảng hóa đơn
                kn.xulydulieu(" INSERT INTO dbo.tblHoaDon(dNgayBan, iMaKH, iThanhTien, sDiaChi )VALUES  (GETDATE()," + iMaKH + "," + lblTongtien.Text +",'"+ txtdiachi.Text + "')");


                //lấy mã HD mới tạo
                dt = kn.laybang("SELECT top 1 iMaHD FROM dbo.tblHoaDon WHERE iMaKH = " + iMaKH + " order by dNgayBan DESC ");
                int iMaHD = int.Parse(dt.Rows[0][0].ToString());

                foreach (GridViewRow row in grv1.Rows)
                {
                    Label lblIDMyPham = (Label)row.FindControl("lblIDMyPham");
                    Label lblsize = (Label)row.FindControl("lblsize");
                    Label soluong_giohang = (Label)row.FindControl("soluong_giohang");
                    Label lblGia = (Label)row.FindControl("lblGia");
                    kn.xulydulieu("INSERT INTO dbo.tblChiTietHoaDon( iMaHD, iID, iSize, iSoLuong, fGia )VALUES  ( " + iMaHD + ", " + lblIDMyPham.Text + "," + lblsize.Text + "," + soluong_giohang.Text + ", " + lblGia.Text + " )");
                }

                //lấy mã giỏ hàng rồi xóa giỏ hàng sau khi đã lên hóa đơn
                dt = kn.laybang("SELECT iMaGH FROM dbo.tblGioHang WHERE iMaKH =" + iMaKH);
                int iMaGH = int.Parse(dt.Rows[0][0].ToString());
                kn.xulydulieu("DELETE dbo.tblChiTietGioHang WHERE iMaGH =" + iMaGH);

                Response.Write("<script>alert('Cảm ơn quý khách đã mua hàng');</script>");
                Response.AddHeader("REFRESH", "0.1;URL=" +"TrangChu.aspx");
            }
            else
            {
                 Response.Redirect("DangNhap.aspx");
            }
         
        }
    }
}