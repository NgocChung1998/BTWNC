<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyLoaiGiay.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyLoaiGiay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #QLSP{
            color: deepskyblue;
        }
        #aQLLG{
            font-weight:bold;
        }

    </style>
    <link href="Style/QLSanPham.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[Quản lý Loại Giày]</h3>
    <div id="FormNhapLoaiGiay" runat="server" class="LoaiGiay">
        <span>Tên loại giày: </span>
        <asp:TextBox ID="txtLoaiGiay" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoaiGiay" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnThemOK" runat="server" Text="Thêm" OnClick="btnThemOK_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn"/>
    <asp:GridView ID="grvLoaiGiay" runat="server" CssClass="tableGridView" AutoGenerateColumns="False" OnSelectedIndexChanged="grvLoaiGiay_SelectedIndexChanged" DataKeyNames="iMaLoaiGiay">
        <Columns>
            <asp:BoundField DataField="iMaLoaiGiay" HeaderText="ID" />
            <asp:BoundField DataField="sTenLoaiGiay" HeaderText="Tên loại giày" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
