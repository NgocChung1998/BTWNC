using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterPageDemo
{
    public partial class TimKiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["value"]!=null)
            {
                string value = Request.QueryString["value"];
                ketnoi kn = new ketnoi();
                DataTable dt = kn.ExecuteQuery("sp_TimKiem", new object[] { value }, new List<string> { "@value" });
                if(dt==null)
                {
                    Response.Write("Không tìm thấy sản phẩm");
                }
                else
                {
                    ListViewMyPham.DataSource = dt;
                    ListViewMyPham.DataBind();
                }
            }
            else
            {
                Response.Write("lỗi đường truyền");
            }
        }
    }
}