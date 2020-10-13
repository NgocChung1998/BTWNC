<%@ Page Title="GIAYTOT.VN" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="MasterPageDemo.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Style/StyleGioHang.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grv1" runat="server" CssClass="tblGioHang" AutoGenerateColumns="false" OnRowDataBound="grv1_DataBound" OnRowDeleting="grv1_RowDeleting">
        <Columns>

            <asp:TemplateField HeaderText="STT">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblindex" runat="server" Text=""></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Hình ảnh">
                <ItemTemplate>
                    <div>
                        <img alt="" src="img/SanPham/<%#Eval("sLinkImg") %>" style="width: 100px; height: 100px;" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tên Sản Phẩm">
                <ItemTemplate>
                    <div>
                        <%# Eval("sTenMyPham")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size">
                <ItemTemplate>
                    <div>
                       <asp:Label ID="lblsize" runat="server" Text=""></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Giá Sản Phẩm">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblGia" runat="server" Text=""></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Số Lượng">
                <ItemTemplate>
                    <div style="text-align: center;">

                        <asp:RangeValidator ID="CheckSoLuong" runat="server" ControlToValidate="soluong_giohang" Display="Dynamic" ErrorMessage="Số lượng mua không hợp lệ" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <br></br>
                        <div style="margin: 0px auto;">
                            <asp:TextBox ID="soluong_giohang" runat="server" Height="24px" TextMode="Number" Width="72px" Font-Size="Medium" AutoPostBack="true"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="CheckNhapsoluong" runat="server" ControlToValidate="soluong_giohang" ErrorMessage="Vui lòng nhập số lượng mua" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br>
                        <asp:RegularExpressionValidator ID="CheckSoLuong_10" runat="server" ControlToValidate="soluong_giohang" ErrorMessage="số lượng cần lớn hơn 0" ForeColor="Red" ValidationExpression="^[1-9]+[0-9]*$"></asp:RegularExpressionValidator>
                    </div>
                </ItemTemplate>

            </asp:TemplateField>



            <asp:TemplateField HeaderText="Xóa">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Xóa" />
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblIDMyPham" runat="server" Text=""></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>

    </asp:GridView>
    <div style="text-align:center; margin-bottom: 1em;">
        Tổng Tiền:
         <asp:Label ID="lblTongTien" runat="server" Text="0"></asp:Label>&nbsp VNĐ<br />
    </div>
        <asp:Button ID="Button1" runat="server" Text="THANH TOÁN" OnClick="Button1_Click"  CssClass="btn"/>

</asp:Content>
