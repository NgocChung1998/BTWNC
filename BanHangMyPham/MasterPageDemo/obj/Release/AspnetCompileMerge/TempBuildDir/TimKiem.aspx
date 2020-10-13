<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="MasterPageDemo.TimKiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GIAYTOT.VN - Nơi bàn chân thăng hoa :3</title>
    <link rel="stylesheet" href="Style/StyleItemGiay.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divListViewGiay">
    <asp:ListView ID="ListViewGiay" runat="server">
        <ItemTemplate>
            <div id="itemGiay">
               <div id="divItemGiayImg"><a href="ThongTinSanPham.aspx?ID=<%# Eval("iID")%>"> <img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemGiayImg" align="top"/> </a></div><br/>
            <p><%#Eval("sTenGiay") %></p>
            <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <p><%#Eval("sMoTa") %></p>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
&nbsp;
</asp:Content>
