<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="MasterPageDemo.TrangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SHOPPET.VN </title>
    <link rel="stylesheet" href="Style/StyleItemMyPham.css" />
    <style>

        @media screen and (min-width : 768px){
            .banner{
                width: 100%;
                margin:-1em auto 1em auto;
            }
            .banner img{
                width: 100%;
            }
            .divListViewMyPhamTrangChu{
                width: 90%;
                margin: 1em auto 5em auto;
            }
        }
        @media screen and (max-width : 768px){
            banner{
                width: 100%;
                margin:0 auto 1em auto;
            }
            .banner img{
                width: 100%;
            }
            .divListViewMyPhamTrangChu{
                width: 90%;
                margin: 1em auto 5em auto;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
    <img src="img/bannerNam.png"/>
    <h3 style="background-color: #fc9059; text-align:center; line-height:50px; margin-top:-5px">MỸ PHẨM NAM</h3>
    </div>
    <div class="divListViewMyPhamTrangChu">
    <asp:ListView ID="ListViewMyPhamNam" runat="server">
        <ItemTemplate>
            <div id="itemMyPham">
            <a href="ThongTinSanPham.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemMyPhamImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemMyPhamImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenMyPham") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
</div>


    <div class="banner">
        <img src="img/bannerNu.png"/>
            <h3 style="background-color: #fc9059; text-align:center; line-height:50px; margin-top:-5px">MỸ PHẨM NỮ</h3>
    </div>


    <div class="divListViewMyPhamTrangChu">
    <asp:ListView ID="ListViewMyPhamNu" runat="server">
        <ItemTemplate>
            <div id="itemMyPham">
            <a href="ThongTinSanPham.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemMyPhamImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemMyPhamImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenMyPham") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
</div>
&nbsp;
</asp:Content>
