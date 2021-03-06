﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="Nu.aspx.cs" Inherits="MasterPageDemo.Nu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Mỹ Phẩm Nữ</title>
    <link rel="stylesheet" href="Style/StyleItemMyPham.css" />
    <link rel="stylesheet" href="Style/StyleItemLoaiMyPham.css" />
        <style>
        #nu{
            color:deepskyblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">
    <div id="divListViewLoaiMyPham">
        <p>LOẠI MỸ PHẨM</p>
        <asp:ListView ID="ListViewLoaiMyPhamNu" runat="server" ClientIDMode="Static" >
                <ItemTemplate>
                    <div id="ItemLoaiMyPham">
                        <a href="Nu.aspx?type=<%# Eval("iMaLoaiMyPham")%>"><%#Eval("sTenLoaiMyPham") %></a>
                    </div>
                </ItemTemplate>
        </asp:ListView>
    </div>
        <div id="divLocTheoGia">
                <p>GIÁ TIỀN</p>
                <a href="Nu.aspx?min=0&max=200000">Dưới 200k</a>
                <a href="Nu.aspx?min=200000&max=500000">Từ 200k - 500k</a>
                <a href="Nu.aspx?min=500000&max=1000000">Từ 500k - 1 triệu</a>
                <a href="Nu.aspx?min=1000000&max=3000000">Từ 1 triệu - 3 triệu</></a>
                <a href="Nu.aspx?min=3000000">Trên 3 triệu</a>
        </div>
    </div>
    <div id="divListViewMyPham">
        <h1 id="ThongBao" runat="server" style="color:red; display:none; text-align: center;">KHÔNG CÓ DỮ LIỆU PHÙ HỢP</h1>
        <asp:ListView ID="ListViewMyPhamNu" runat="server">
         <ItemTemplate>
            <div id="itemMyPham">
            <a href="ThongTinSanPham.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemMyPhamImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemMyPhamImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenMyPham") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
    </div>
</asp:Content>


