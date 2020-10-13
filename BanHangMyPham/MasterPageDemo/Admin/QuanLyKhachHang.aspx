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
    <link href="Style/QuanLy.css" rel="stylesheet"/>
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[DANH SÁCH KHÁCH HÀNG]</h3>
    <div id="FormNhapKhachHang" class="FormNhap" runat="server">
        <span>Username</span><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <span>Ho ten</span><asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtHoTen" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <span>Dia Chr</span><asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtDiaChi" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <span>SĐT</span><asp:TextBox ID="txtSDT" runat="server" TextMode="Phone"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="txtSDT" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <br/>
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
        <asp:Button ID="btnHuy" runat="server" Text="Huy" />
    </div>
    <asp:GridView ID="grvUser" runat="server" AutoGenerateColumns="False" CssClass="tableGridView" OnSelectedIndexChanged="grvUser_SelectedIndexChanged" DataKeyNames="iID">
        <Columns>
            <asp:BoundField DataField="iID" HeaderText="ID" />
            <asp:BoundField DataField="sUsername" HeaderText="Username" />
            <asp:BoundField DataField="sTenKH" HeaderText="Họ Tên" />
            <asp:BoundField DataField="sDiaChi" HeaderText="Địa Chỉ" />
            <asp:BoundField DataField="sSDT" HeaderText="SĐT" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
