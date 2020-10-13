using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class Nu : System.Web.UI.Page
    {
        ketnoi kn = new ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dta = kn.ExecuteQuery("GetLoaiMyPham", new object[] { 0 }, new List<string> { "@bGioiTinh" });
            ListViewLoaiMyPhamNu.DataSource = dta;
            ListViewLoaiMyPhamNu.DataBind();

            string type = Request.QueryString["type"];
            string min = Request.QueryString["min"];
            string max = Request.QueryString["max"];


            LayMyPhamTheoDieuKien(type, min, max);
        }

        private void LayMyPhamTheoDieuKien(string type, string min, string max)
        {
            if (type == null)
            {
                if (min != null)
                {
                    object[] para = new object[] { 0, min, max };
                    List<string> paraName = new List<string> { "@bGioiTinh", "@min", "@max" };
                    using (DataTable dt = kn.ExecuteQuery("GetSanPham", para, paraName))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ListViewMyPhamNu.DataSource = dt;
                            ListViewMyPhamNu.DataBind();
                        }
                        else
                        {
                            ThongBao.Style.Remove("display");
                        }
                    }
                }
                else if (min == null && max != null)
                {
                    Response.Redirect("Nu.aspx");
                }
                else
                {
                    ListViewMyPhamNu.DataSource = kn.ExecuteQuery("GetSanPham", new object[] { 0 }, new List<string> { "@bGioiTinh" });
                    ListViewMyPhamNu.DataBind();
                }
            }
            else
            {
                using (DataTable dt = kn.ExecuteQuery("GetSanPham", new object[] { 0, type }, new List<string> { "@bGioiTinh", "@iMaLoaiMyPham" }))
                {
                    if (dt != null)
                    {
                        Response.Write("<title>" + kn.lay1giatri("Select sTenLoaiMyPham from tblLoaiMyPham where iMaLoaiMyPham='" + type + "'") + " - MYPHAM.VN</title>");
                        ListViewMyPhamNu.DataSource = dt;
                        ListViewMyPhamNu.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Nu.aspx");
                    }
                }
            }
        }


    }
}