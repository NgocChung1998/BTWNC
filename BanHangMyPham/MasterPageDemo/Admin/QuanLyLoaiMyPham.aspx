<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyLoaiMyPham.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyLoaiGiay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #QLSP{
            color: deepskyblue;
        }
        #aQLLG{
            font-weight:bold;
        }

    </style>
    <link href="Style/QuanLy.css" rel="stylesheet" />
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[Quản lý Loại Mỹ Phẩm]</h3>
    <div id="FormNhapLoaiMyPham" runat="server" class="FormNhap">
        <span>Tên loại mỹ phẩm: </span>
        <asp:TextBox ID="txtLoaiMyPham" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoaiMyPham" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnThemOK" runat="server" Text="Thêm" OnClick="btnThemOK_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />
    </div>
    <asp:Button ID="btnThem" runat="server" Text="Thêm mới" OnClick="btnThem_Click" CssClass="btn"/>
    <asp:GridView ID="grvLoaiMyPham" runat="server" CssClass="tableGridView" AutoGenerateColumns="False" OnSelectedIndexChanged="grvLoaiMyPham_SelectedIndexChanged" DataKeyNames="iMaLoaiMyPham">
        <Columns>
            <asp:BoundField DataField="iMaLoaiMyPham" HeaderText="ID" />
            <asp:BoundField DataField="sTenLoaiMyPham" HeaderText="Tên loại mỹ phẩm" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
