<%@ Page Title="GIAYTOT.VN" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="MasterPageDemo.GioHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/StyleGioHang.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grv1" runat="server" CssClass="tblGioHang"></asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="thanh toán em ey" />
</asp:Content>
