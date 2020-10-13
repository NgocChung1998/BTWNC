<%@ Page Title="GIAYTOT.VN" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="MasterPageDemo.ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="Style/StyleThanhToan.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="FormNhap">
          <h3 style="text-align:center; line-height: 50px;">Thông tin nhận hàng</h3> 
   <span>Tên: </span><asp:TextBox ID="txtten" runat="server"></asp:TextBox>
          <br />
   <span>Địa Chỉ: </span><asp:TextBox ID="txtdiachi" runat="server"></asp:TextBox>
          <br />
   <span>Số Điện Thoại: </span><asp:TextBox ID="txtsdt" runat="server"></asp:TextBox>
          <br />
       <p>Phương thức thanh toán: Thanh Toán Khi Nhận Hàng</p>
    </div>
   <asp:GridView ID="grv1" runat="server" CssClass="tblGioHang" AutoGenerateColumns="false" OnRowDataBound="grv1_DataBound"  >
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
                    <div>
                    <asp:Label ID="soluong_giohang" runat="server" Text=""></asp:Label>
                    </div>
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
    <div id="spanTongTien">
        <span>Tổng tiền: </span><asp:Label ID="lblTongtien" runat="server" Text="0"></asp:Label><span>đ</span>
    </div>
    <asp:Button ID="btnXacNhanthanhtoan" runat="server" Text="THANH TOÁN" OnClick="btnXacNhanthanhtoan_Click" CssClass="btn"/>
</asp:Content>
