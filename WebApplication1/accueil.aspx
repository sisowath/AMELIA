<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="accueil.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server">
    
    </asp:Label>
    <div class="container">
        <asp:Label ID="lblMessageDeBienvenue" runat="server">
    
        </asp:Label>
        <asp:PlaceHolder ID="leaderboard" runat="server">
    
        </asp:PlaceHolder>    
        <div class="panel panel-primary" style="float:left; margin-left:100px">
            <h2>Message des développeurs</h2>        
            <div class="panel-heading">
                Kismony
            </div>
            <div class="panel-body">
                ASP est intéressant mais il n'utilise pas de MVC(nous sommes maintenant habitué à travailler avec MVC)
            </div>
            <div class="panel-heading">
                Samnang
            </div>
            <div class="panel-body">
                J'ai adoré sortir de ma zone de confort en apprenant ASP NET Web Forms !!
            </div>
        </div>
    </div>
    <style>
        .footer {
            position : absolute;
        }
        th, td {
            padding : 10px;
        }
    </style>
</asp:Content>
