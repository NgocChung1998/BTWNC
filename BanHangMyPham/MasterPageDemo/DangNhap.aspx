<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="MasterPageDemo.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Đăng nhập - MYPHAMTOT.VN</title>
    <link href="Style/StyleDangNhap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <table>
            <tbody runat ="server" id="deptrai"></tbody>
        </table>

        <table class="tblForm">
            <tr>
                <td class="auto-style5">Tên đăng nhập</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtUsername" runat="server"  CssClass="input" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="<br/>Vui lòng điền vào trường này" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="<br/>Tên đăng nhập có phân biệt chữ hoa chữ thường(6-15 ký tự)" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Mật khẩu</td>
                <td class="auto-style3"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input" Width="180px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="<br/>Vui lòng điền vào trường này" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="<br/>*" ForeColor="Red" ValidationExpression="^[0-9a-zA-z-_]{6,15}$"></asp:RegularExpressionValidator>
                </td>
                </tr>
            <tr>
                <td colspan="2"><asp:Button ID="btnDangNhap" runat="server" OnClick="btnDangNhap_Click" Text="Đăng Nhập" CssClass="btnDangNhap"/></td>
            </tr>
        </table>
        <div id="divDangKy">
             <p>BẠN CHƯA CÓ TÀI KHOẢN??</p>
             <div id="btnDangKy">
                 <a href="DangKy.aspx" >Đăng Ký</a>
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
    </div>
</asp:Content>
