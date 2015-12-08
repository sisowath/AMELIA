<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        if (Session["isConnected"] != null)
            Response.Redirect("accueil.aspx");        
     %>
     <asp:Label ID="lblMessage" runat="server">
     
     </asp:Label>
     <div class="row">
        <div class="col-md-6 col-md-offset-3">            
            <h1 class="panel panel-collapse">Authentification</h1>
            <h3>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" 
                    ErrorMessage="Vous avez oublié de saisir votre nom d'utilisateur" 
                    ControlToValidate="txtUsername" Display="Dynamic" ForeColor="#FF9933"></asp:RequiredFieldValidator>
    
            </h3>
            <h3>    
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" 
                    ErrorMessage="Vous avez oublié de saisir votre mot de passe." 
                    ControlToValidate="txtPassword" Display="Dynamic" ForeColor="#FF9933"></asp:RequiredFieldValidator>
            </h3>
            <table border="1px solid black">
                <tr>
                    <td>Nom d'utilisateur : </td>            
                    <td><asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Nom d'utilisteur"></asp:TextBox></td>            
                </tr>
                <tr>
                    <td>Mot de passe : </td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" required="required"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button ID="btnMeConnecter" Text="Me Connecter" runat="server" 
                            width="100%" onclick="btnMeConnecter_Click" class="btn btn-lg btn-primary btn-block"/></td>            
                </tr>
            </table>
        </div>
    </div>
    <style type="text/css">
        #formulaireInscription {
            margin : 0 auto;
        }
        .footer {
            position : absolute;
        }
    </style>
</asp:Content>