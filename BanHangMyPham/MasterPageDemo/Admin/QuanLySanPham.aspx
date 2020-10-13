<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage/admin.Master" AutoEventWireup="true" CodeBehind="QuanLySanPham.aspx.cs" Inherits="MasterPageDemo.Admin.QuanLySanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #QLSP{
            color: deepskyblue;
        }
        #aQLSP{
            font-weight:bold;
        }

    </style>
<link href="Style/QuanLy.css" rel="stylesheet" />
    <script src="Script/script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 style="text-align: center; line-height:50px">[Quản lý Sản Phẩm]</h3>
    <div id="FormNhapSanPham" runat="server" class="FormNhap">
        <table>
            <tr>
                <td>
                    <span>ID</span><asp:Label ID="lblID" runat="server" Text=""></asp:Label><br />
                    <span>Tên mỹ phẩm</span><asp:TextBox ID="txtTenMyPham" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenMyPham" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <span>Giá</span><asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGia" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <span>Loại mỹ phẩm</span><asp:DropDownList ID="ddLoaiMyPham" runat="server"></asp:DropDownList><br />
                    <span>Hãng mỹ phẩm</span><asp:DropDownList ID="ddHangMyPham" runat="server"></asp:DropDownList><br />
                    <span>GioiTinh</span><asp:DropDownList ID="ddGioiTinh" runat="server">
                        <asp:ListItem Value="True">Nam</asp:ListItem>
                        <asp:ListItem Value="False">Nữ</asp:ListItem>
                    </asp:DropDownList><br />
                    <span>Mô tả</span><asp:TextBox ID="txtMoTa" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMoTa" Display="Dynamic" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
                <td>
                    <span>Ảnh</span><br/><asp:Image ID="ImgSP" runat="server" /><br/>
                    
                    <asp:FileUpload ID="imgUpload" runat="server" />
                    
                 </td>
            </tr>
            <tr>
                <td colspan="2" id="tdBtn" runat="server" >
                    <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" />
                    <asp:Button ID="btnSuaSoLuong" runat="server" Text="Cập nhật số lượng" OnClick="btnSuaSoLuong_Click" CausesValidation="false" />
                    <asp:Button ID="btnThemOK" runat="server" Text="Thêm Sản Phẩm" OnClick="btnThemOK_Click" />
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" CausesValidation="false" />
                </td>
            </tr>
            <tr id="SoLuong" class="SoLuong" runat="server">
                <td colspan="2">
                    <span>360</span><asp:TextBox ID="txtSoLuong360" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong36"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong36" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    <br/>
                    <span>370</span><asp:TextBox ID="txtSoLuong370" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong37"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong37" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>380</span><asp:TextBox ID="txtSoLuong380" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong38"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong38" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>390</span><asp:TextBox ID="txtSoLuong390" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong39"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong39" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>400</span><asp:TextBox ID="txtSoLuong400" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong40"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong41" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>410</span><asp:TextBox ID="txtSoLuong410" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong41"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong41" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>420</span><asp:TextBox ID="txtSoLuong420" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong42"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator7" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong42" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>430</span><asp:TextBox ID="txtSoLuong430" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong43"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong43" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <span>440</span><asp:TextBox ID="txtSoLuong440" runat="server" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSoLuong44"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="Giá trị phải lớn hơn 0" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSoLuong44" MaximumValue="1000000" MinimumValue="0" Type="Integer"></asp:RangeValidator><br/>
                    <asp:Button ID="btnUpdateSoLuong" runat="server" Text="Cập nhật" OnClick="btnUpdateSoLuong_Click" />
                    <asp:Button ID="btnHuySoLuong" runat="server" Text="Hủy" OnClick="btnHuySoLuong_Click"/>
                </td>
            </tr>
        </table>
    </div>

    <asp:Button ID="btnThem" runat="server" Text="Thêm Sản Phẩm" OnClick="btnThem_Click" CssClass="btn"/>
    <asp:GridView ID="grv1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="grv1_SelectedIndexChanged" CssClass="tableGridView">
    </asp:GridView>
</asp:Content>
