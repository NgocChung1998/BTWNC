<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="MasterPageDemo.Admin.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Style/DangNhap.css" rel="stylesheet"/>
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Content">
    <h1>[ĐĂNG NHẬP]</h1>
    <h3>[Sử dụng tài khoản nội bộ để đăng nhập]</h3><br />
        <p>[Tài khoản]</p>
            <asp:TextBox ID="txtUsername" runat="server"  CssClass="input" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="<br/>Vui lòng điền vào trường này" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="<br/>Tên đăng nhập có phân biệt chữ hoa chữ thường(6-15 ký tự)" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$"></asp:RegularExpressionValidator>
        <p>[Mật khẩu]</p>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="<br/>Vui lòng điền vào trường này" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="<br/>*" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$"></asp:RegularExpressionValidator>
        <br/>    <asp:Button ID="btnDangNhap" runat="server" Text="[ Đăng Nhập ]" CssClass="btnDangNhap" OnClick="btnDangNhap_Click"/>
        </div>
</asp:Content>
