using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo.Admin
{
    public partial class QuanLySanPham : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            if (Session["admin"].ToString().Equals(""))
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                FormNhapSanPham.Visible = false;
                    SoLuong.Visible = false;
                    LoadGridView();
            }
        }
        }

        void LoadGridView()
        {
         
                BoundField ID = new BoundField();
                ID.HeaderText = "ID";
                ID.DataField = "iID";

                BoundField TenSP = new BoundField();
                TenSP.HeaderText = "Tên sản phẩm";
                TenSP.DataField = "sTenMyPham";

                BoundField Gia = new BoundField();
                Gia.HeaderText = "Giá";
                Gia.DataField = "fGia";

                BoundField LoaiMyPham = new BoundField();
                LoaiMyPham.HeaderText = "Loại Mỹ Phẩm";
                LoaiMyPham.DataField = "sTenLoaiMyPham";

                BoundField HangMyPham = new BoundField();
                HangMyPham.HeaderText = "Hãng mỹ phẩm";
                HangMyPham.DataField = "sTenHang";

                BoundField GioiTinh = new BoundField();
                GioiTinh.HeaderText = "Giới tính";
                GioiTinh.DataField = "bGioiTinh";
                    

                //BoundField sMoTa = new BoundField();
                //ID.HeaderText = "Mô tả";
                //ID.DataField = "sMoTa";

                ImageField Img = new ImageField();
                Img.HeaderText = "Ảnh SP";
                Img.DataImageUrlField = "sLinkImg";
                Img.DataImageUrlFormatString = "../../img/SanPham/{0}";

                CommandField Sua = new CommandField();
                Sua.ButtonType = ButtonType.Button;
                Sua.SelectText = "Sửa";
                Sua.ShowSelectButton = true;

                grv1.Columns.Add(ID);
                grv1.Columns.Add(TenSP);
                grv1.Columns.Add(Gia);
                grv1.Columns.Add(LoaiMyPham);
                grv1.Columns.Add(HangMyPham);
                grv1.Columns.Add(GioiTinh);
                grv1.Columns.Add(Img);
                grv1.Columns.Add(Sua);

                grv1.DataKeyNames = new string[] { "iID" };
                grv1.DataSource = kn.ExecuteQuery("GetSanPhamAdmin", null, null);
                grv1.DataBind();
        }


        protected void grv1_SelectedIndexChanged(object sender, EventArgs e)
        {

                //Khi bấm sửa, tắt nút theemm, xác nhận thêm
                //enable nút ok

                btnThemOK.Enabled = false;
                btnThemOK.Visible = false;
                btnThem.Enabled = false;
                btnThem.Visible = false;

                btnOK.Enabled = true;
                btnOK.Visible = true;

                FormNhapSanPham.Visible = true;
                SoLuong.Visible = false;

                DataTable dt = new DataTable();
                dt.Clear();
                dt = kn.ExecuteQuery("XemTTMyPham", new object[] { grv1.SelectedDataKey.Value },new List<string> { "@id"});

                lblID.Text = dt.Rows[0][0].ToString();
                txtTenMyPham.Text = dt.Rows[0][1].ToString();
                txtGia.Text = dt.Rows[0][2].ToString();

                ddLoaiMyPham.ClearSelection();
                ddLoaiMyPham.DataSource = kn.laybang("Select * from tblLoaiMyPham");
                ddLoaiMyPham.DataTextField = "sTenLoaiMyPham";
                ddLoaiMyPham.DataValueField = "iMaLoaiMyPham";
                ddLoaiMyPham.DataBind();
                ddLoaiMyPham.Items.FindByText(dt.Rows[0][3].ToString()).Selected = true;
                //dlTest.Items.FindByValue(string val).Selected = true;


                ddGioiTinh.ClearSelection();      
                ddHangMyPham.DataSource = kn.laybang("Select * from tblHangMyPham");
                ddHangMyPham.DataTextField = "sTenHang";
                ddHangMyPham.DataValueField = "iHangMyPham";
                ddHangMyPham.DataBind();
                ddHangMyPham.Items.FindByText(dt.Rows[0][4].ToString()).Selected = true;

                ddGioiTinh.ClearSelection();
                ddGioiTinh.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;

                txtMoTa.Text = dt.Rows[0][6].ToString();
                ImgSP.ImageUrl = "../../img/SanPham/"+dt.Rows[0][7].ToString();
                ImgSP.Width = 350;

                dt.Dispose();
         }
        

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);

                if (allowEx.Contains(extension))
                {
                    string filePath = Server.MapPath("../img/SanPham/" + imgUpload.FileName);
                    imgUpload.SaveAs(filePath);

                    object[] param = new object[] { grv1.SelectedDataKey.Value, txtTenMyPham.Text, txtGia.Text, ddLoaiMyPham.SelectedValue, ddHangMyPham.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, imgUpload.FileName };
                    List<string> paramList = new List<string> { "@iID", "@sTenMyPham", "@fGia", "@iMaLoaiMyPham", "@iHangMyPham", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                    int kq = kn.ExecuteNonQuery("UpdateSanPhamAdmin", param, paramList);
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
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }
            else
            {
                string sLinkImg = kn.lay1giatri("Select sLinkImg from tblMyPham where iID ='" + grv1.SelectedDataKey.Value + "'");
                object[] param = new object[] { grv1.SelectedDataKey.Value, txtTenMyPham.Text, txtGia.Text, ddLoaiMyPham.SelectedValue, ddHangMyPham.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, sLinkImg };
                List<string> paramList = new List<string> { "@iID", "@sTenMyPham", "@fGia", "@iMaLoaiMyPham", "@iHangMyPham", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                int kq = kn.ExecuteNonQuery("UpdateSanPhamAdmin", param, paramList);
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
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //Khi bấm thêm SP, tắt nút ok của cập nhật đi, 
            //Enable cái form nhập
            //Enable nút xác nhận thêm]

            FormNhapSanPham.Visible = true;

            btnThem.Visible = false;
            btnThem.Enabled = false;

            btnOK.Enabled = false;
            btnOK.Visible = false;

            btnThemOK.Enabled = true;
            btnThemOK.Visible = true;

            btnSuaSoLuong.Visible = false;
            btnSuaSoLuong.Enabled = false;
            SoLuong.Visible = false;

            ddLoaiMyPham.ClearSelection();
            ddLoaiMyPham.DataSource = kn.laybang("Select * from tblLoaiMyPham");
            ddLoaiMyPham.DataTextField = "sTenLoaiMyPham";
            ddLoaiMyPham.DataValueField = "iMaLoaiMyPham";
            ddLoaiMyPham.DataBind();

            ddGioiTinh.ClearSelection();
            ddHangMyPham.DataSource = kn.laybang("Select * from tblHangMyPham");
            ddHangMyPham.DataTextField = "sTenHang";
            ddHangMyPham.DataValueField = "iHangMyPham";
            ddHangMyPham.DataBind();

            ddGioiTinh.ClearSelection();

        }

        protected void btnThemOK_Click(object sender, EventArgs e)
        {
            if (imgUpload.HasFile)
            {
                string allowEx = ".jpg .png .gif .tiff .bmp";
                string extension = Path.GetExtension(imgUpload.FileName);

                if (allowEx.Contains(extension))
                {
                    string filePath = Server.MapPath("../img/SanPham/" + imgUpload.FileName);
                    imgUpload.SaveAs(filePath);

                    object[] param = new object[] { txtTenMyPham.Text, txtGia.Text, ddLoaiMyPham.SelectedValue, ddHangMyPham.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, imgUpload.FileName };
                    List<string> paramList = new List<string> { "@sTenMyPham", "@fGia", "@iMaLoaiMyPham", "@iHangMyPham", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                    int kq = kn.ExecuteNonQuery("InsertSanPhamAdmin", param, paramList);
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
                else
                {
                    Response.Write("<script>alert('Mởi bạn tải lên file ảnh *.jpg, png, gif, tiff, bmp');</script>");
                }
            }
            else
            {
                object[] param = new object[] { txtTenMyPham.Text, txtGia.Text, ddLoaiMyPham.SelectedValue, ddHangMyPham.SelectedValue, ddGioiTinh.SelectedValue, txtMoTa.Text, "0.jpg" };
                List<string> paramList = new List<string> { "@sTenMyPham", "@fGia", "@iMaLoaiMyPham", "@iHangMyPham", "@bGioiTinh", "@sMoTa", "@sLinkImg" };
                int kq = kn.ExecuteNonQuery("InsertSanPhamAdmin", param, paramList);
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

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            FormNhapSanPham.Visible = false;
            btnThem.Visible = true;
            btnThem.Enabled = true;

            lblID.Text = "";
            txtTenMyPham.Text = "";
            txtMoTa.Text = "";
            txtGia.Text = "";
            ImgSP.ImageUrl = "";
        }

        protected void btnSuaSoLuong_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = kn.laybang("Select * from tblMyPham_ChiTiet where iID ='"+grv1.SelectedDataKey.Value+"'");
            if (dt != null && dt.Rows.Count == 9)
            {
                btnSuaSoLuong.Visible = false;
                btnSuaSoLuong.Enabled = false;
                SoLuong.Visible = true;
                txtSoLuong360.Text = dt.Rows[0]["iSoLuong"].ToString();
                txtSoLuong370.Text = dt.Rows[1]["iSoLuong"].ToString();
                txtSoLuong380.Text = dt.Rows[2]["iSoLuong"].ToString();
                txtSoLuong390.Text = dt.Rows[3]["iSoLuong"].ToString();
                txtSoLuong400.Text = dt.Rows[4]["iSoLuong"].ToString();
                txtSoLuong410.Text = dt.Rows[5]["iSoLuong"].ToString();
                txtSoLuong420.Text = dt.Rows[6]["iSoLuong"].ToString();
                txtSoLuong430.Text = dt.Rows[7]["iSoLuong"].ToString();
                txtSoLuong440.Text = dt.Rows[8]["iSoLuong"].ToString();
            }
            else
            {
                Response.Write("<script>alert('Lỗi đường truyền');</script>");
            }
        }

        protected void btnUpdateSoLuong_Click(object sender, EventArgs e)
        {
            object[] param = new object[] { grv1.SelectedDataKey.Value, txtSoLuong360.Text, txtSoLuong370.Text, txtSoLuong380.Text, txtSoLuong390.Text,
            txtSoLuong400.Text,txtSoLuong410.Text,txtSoLuong420.Text,txtSoLuong430.Text,txtSoLuong440.Text};

            List<string> paramList = new List<string> {"@iID", "@iSoLuong360", "@iSoLuong370", "@iSoLuong380", "@iSoLuong390", "@iSoLuong400", "@iSoLuong410",
                "@iSoLuong420", "@iSoLuong430", "@iSoLuong440" };
            kn.ExecuteNonQuery("SuaSoLuongSanPhamAdmin", param, paramList);



            Response.Write("<script>alert('Thêm thành công');</script>");
            Response.AddHeader("REFRESH", "0.1;URL=" + Request.RawUrl);
        }


        protected void btnHuySoLuong_Click(object sender, EventArgs e)
        {
            SoLuong.Visible = false;
            btnSuaSoLuong.Visible = true;
            btnSuaSoLuong.Enabled = true;
        }
    }
}
