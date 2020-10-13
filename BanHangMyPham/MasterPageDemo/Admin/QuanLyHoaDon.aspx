<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLyHoaDon.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLyHoaDon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
       #QLHD{
            color: deepskyblue;
       }
              #header1{
           display:none;
       }
       .imgSP{
             width: 100px;
       }


        .FormNhapHD {
        border: 1px solid;
        width: 90%;
        margin: 1em auto;
        padding: 1em;
        }

        .FormNhapHD span, .FormNhapHD input, .FormNhapHD select {
            margin: 10px;
            padding: 3px;
        }

        .FormNhapHD span {
            width: 150px;
            display: inline-block;
        }

       .tableGridViewHD {
        width: 80%;
        margin: 2em auto 2em auto;
        }

        .tableGridViewHD tr th {
            padding: 15px;
            background-color: whitesmoke;
        }

        .tableGridViewHD tr td {
            padding: 10px;
        }

       .tableGridViewHD tr td img {
                width: 120px;
       }

    </style> 
        <link href="Style/QuanLy.css" rel="stylesheet" />
     <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 style="text-align: center; line-height:50px">[Quản lý Hóa đơn]</h3>
    
    <div id="FormNhapHoaDon" runat="server" class="FormNhapHD">
        <span>Mã hóa đơn: </span>
        <asp:Label ID="lblID" runat="server" Text=""></asp:Label><br />
        <span>Địa chỉ nhận hàng: </span>
        <asp:TextBox ID="txtDiaChi" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDiaChi" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />

        <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" />

        <asp:GridView ID="grvCTHD" runat="server" CssClass="tableGridViewHD" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="iMaHD" HeaderText="Mã HD" />
                <asp:BoundField DataField="iID" HeaderText="Mã MH" />
                <asp:BoundField DataField="sTenMyPham" HeaderText="Tên sản phẩm" />
                <asp:BoundField DataField="iSize" HeaderText="Size" />
                <asp:BoundField DataField="fGia" HeaderText="Đơn giá" />
                <asp:BoundField DataField="iSoLuong" HeaderText="Số lượng" />
                <asp:ImageField DataImageUrlField="sLinkImg" DataImageUrlFormatString="../img/SanPham/{0}" HeaderText="Ảnh" >
                </asp:ImageField>
            </Columns>
        </asp:GridView>

    </div>

    <asp:GridView ID="grvHoaDon" runat="server" AutoGenerateColumns="False" CssClass="tableGridView" DataKeyNames="iMaHD" OnSelectedIndexChanged="grvHoaDon_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="iMaHD" HeaderText="Mã hóa đơn" />
            <asp:BoundField DataField="dNgayBan" HeaderText="Ngày bán" />
            <asp:BoundField DataField="sTenKH" HeaderText="Tên khách hàng" />
            <asp:BoundField DataField="iThanhTien" HeaderText="Thành Tiền" />
            <asp:BoundField DataField="sDiaChi" HeaderText="Địa chỉ" />
            <asp:CommandField ButtonType="Button" SelectText="Sửa" ShowSelectButton="True" />
        </Columns>

    </asp:GridView>
</asp:Content>
