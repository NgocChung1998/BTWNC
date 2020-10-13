<%@ Page Title="Đăng Ký - GIAYTOT.VN" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="MasterPageDemo.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/StyleDangKy.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="all">
    <h2 style="text-align: center"><b>ĐĂNG KÝ TÀI KHOẢN</b></h2>
    <table id="tblForm">
        <tr>
            <td><p>Username</p></td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="<br/>Vui lòng điền vào trường này" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="<br/>Tên đăng nhập có phân biệt chữ hoa chữ thường(6-15 ký tự)" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><p>Mật khẩu</p></td>
            <td><asp:TextBox ID="txtPassword" runat="server"  CssClass="txtInput" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td><p>Nhập lại mật khẩu</p></td>
            <td><asp:TextBox ID="txtPassword_ReEnter" runat="server"  CssClass="txtInput" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword_ReEnter" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="<br/>Không khớp" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td><p>Họ và tên</p></td>
            <td><asp:TextBox ID="txtHoTen" runat="server"  CssClass="txtInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHoTen" Display="Dynamic" ErrorMessage="<br/>Vui lòng điền vào trường này" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><p>Địa chỉ</p></td>
            <td><asp:TextBox ID="txtDiaChi" runat="server"  CssClass="txtInput"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="<br/>Vui lòng điền vào trường này" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><p>Số điện thoại</p></td>
            <td><asp:TextBox ID="txtSDT" runat="server"  CssClass="txtInput" TextMode="Phone"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSDT" Display="Dynamic" ErrorMessage="<br/>Vui lòng điền vào trường này" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" ErrorMessage="<br/>*" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$" Display="Dynamic"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
    <div class="btn">
        <asp:Button ID="btnDangKy" runat="server" Text="Đăng Ký" CssClass="btnDangKy" OnClick="btnDangKy_Click"/>
    </div>
    </div>
            <script type="text/javascript">

            function clickButton(e, buttonid) {
                var evt = e ? e : window.event;
                var bt = document.getElementById(buttonid);

                if (bt) {
                    if (evt.keyCode == 13) {
                        bt.click();
                        return false;
                    }
                }
            }
        </script>
</asp:Content>
