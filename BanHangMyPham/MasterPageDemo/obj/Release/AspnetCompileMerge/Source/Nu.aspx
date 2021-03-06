﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/client.Master" AutoEventWireup="true" CodeBehind="Nu.aspx.cs" Inherits="MasterPageDemo.Nu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Giày nữ - GIAYTOT.VN</title>
    <link rel="stylesheet" href="Style/StyleItemGiay.css" />
    <link rel="stylesheet" href="Style/StyleItemLoaiGiay.css" />
        <style>
        #nu{
            color:deepskyblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">
    <div id="divListViewLoaiGiay">
        <p>LOẠI GIÀY</p>
        <asp:ListView ID="ListViewLoaiGiayNu" runat="server" ClientIDMode="Static" >
                <ItemTemplate>
                    <div id="ItemLoaiGiay">
                        <a href="Nu.aspx?type=<%# Eval("iMaLoaiGiay")%>"><%#Eval("sTenLoaiGiay") %></a>
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
    <div id="divListViewGiay">
        <h1 id="ThongBao" runat="server" style="color:red; display:none; text-align: center;">KHÔNG CÓ DỮ LIỆU PHÙ HỢP</h1>
        <asp:ListView ID="ListViewGiayNu" runat="server">
         <ItemTemplate>
            <div id="itemGiay">
            <a href="ThongTinSanPham.aspx?ID=<%# Eval("iID")%>"> 
               <div id="divItemGiayImg"><img src="img/SanPham/<%# Eval("sLinkImg") %>" id="itemGiayImg" align="top"/> </div><br/>
                 <p><%#Eval("sTenGiay") %></p>
                 <p id="gia"><b><%# string.Format("{0:n0}", Eval("fGia")) %>₫</b></p> 
            <%--<p><small><%#Eval("sMoTa") %></small></p>--%>
           </a>
           </div>
        </ItemTemplate>
    </asp:ListView>
    </div>
</asp:Content>


