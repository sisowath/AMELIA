<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="WebApplication1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (Session["isConnected"] != null)
        {
            Session.RemoveAll();            
        }
        Response.Redirect("login.aspx");
    %>
</asp:Content>
