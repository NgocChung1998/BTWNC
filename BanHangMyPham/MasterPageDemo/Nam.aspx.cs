using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class Nam : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Lấy danh sách loại giày là nam
            DataTable dta = kn.ExecuteQuery("GetLoaiMyPham", new object[] { 1 }, new List<string> { "@bGioiTinh" });
            ListViewLoaiMyPhamNam.DataSource = dta;
            ListViewLoaiMyPhamNam.DataBind();

            //lấy QueryString để lọc theo loại giày
            string type = Request.QueryString["type"];
            //lấy QueryString để lọc theo giá
            string min = Request.QueryString["min"];
            string max = Request.QueryString["max"];

            
            LayMyPhamTheoDieuKien(type, min, max);


        }



        private void LayMyPhamTheoDieuKien(string type, string min, string max)
        {
            //nếu như loại giày không được truyền vào
            if (type == null)
            {
                //nếu như giá min được truyền vào
                if (min != null)
                {
                    object[] para = new object[] { 1, min, max };
                    List<string> paraName = new List<string> { "@bGioiTinh", "@min", "@max" };
                    using (DataTable dt = kn.ExecuteQuery("GetSanPham", para, paraName))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ListViewMyPhamNam.DataSource = dt;
                            ListViewMyPhamNam.DataBind();
                        }
                        else
                        {
                            ThongBao.Style.Remove("display");
                        }
                    }
                }
                //nếu như giá trị min không được truyền vào
                else
                {
                    //nếu như giá trị min không được truyền vào và max được truyền vào thì load lại trang (đây là lỗi truy vấn)
                    if (min == null && max != null)
                    {
                        Response.Redirect("Nam.aspx");
                    }
                    //nếu min và max đều không được truyền vào thì lấy toàn bộ mỹ phẩm có giới tính là nam
                    else
                    {
                        ListViewMyPhamNam.DataSource = kn.ExecuteQuery("GetSanPham", new object[] { 1 }, new List<string> { "@bGioiTinh" });
                        ListViewMyPhamNam.DataBind();
                    }
                }
            }
            //nếu loại giày được truyền vào thì lọc theo loại mỹ phẩm
            else
            {
                using (DataTable dt = kn.ExecuteQuery("GetSanPham", new object[] { 1, type }, new List<string> { "@bGioiTinh", "@iMaLoaiMyPham" }))
                {
                    if (dt != null)
                    {
                        //thay đổi title cho giống loại mỹ phẩm được chọn
                        Response.Write("<title>" + kn.lay1giatri("Select sTenLoaiMyPham from tblLoaiMyPham where iMaLoaiMyPham='" + type + "'") + " - MYPHAMTOT.VN</title>");
                        ListViewMyPhamNam.DataSource = dt;
                        ListViewMyPhamNam.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Nam.aspx");
                    }
                }
            }
        }




    }
}