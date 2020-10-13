<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyKhachHang.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyKhachHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
       #QLKH{
            color: deepskyblue;
       }
       #header1{
           display:none;
       }

    </style> 
    <link href="Style/QLSanPham.css" rel="stylesheet"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[DANH SÁCH KHÁCH HÀNG]</h3>
    <asp:GridView ID="grvUser" runat="server" AutoGenerateColumns="False" CssClass="tableGridView">
        <Columns>
            <asp:BoundField DataField="iID" HeaderText="ID" />
            <asp:BoundField DataField="sUsername" HeaderText="Username" />
            <asp:BoundField DataField="sTenKH" HeaderText="Họ Tên" />
            <asp:BoundField DataField="sDiaChi" HeaderText="Địa Chỉ" />
        </Columns>
    </asp:GridView>
</asp:Content>
