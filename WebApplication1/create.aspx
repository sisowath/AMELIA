<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="WebApplication1.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblMessage" runat="server">
    
        </asp:Label>
        <asp:PlaceHolder ID="bootstrapMessage" runat="server">
        
        </asp:PlaceHolder>
        <table border="1px soldi black" class="table table-striped table-bordered">
            <tr>
                <th colspan="2">Création d'un profile</th>
            </tr>
            <tr>
                <td>Nom d'utilisateur : </td>
                <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Mot de passe : </td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>confirmer mot de passe : </td>
                <td><asp:TextBox ID="txtPasswordC" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="txtPassword" ControlToValidate="txtPasswordC" 
                        ErrorMessage="Erreur ! Le mot de passe ne correspond pas." Font-Bold="True" 
                        ForeColor="#FF3300"></asp:CompareValidator>
                </td>    
            </tr>
            <tr>
                <td>Adresse courriel : </td>
                <td><asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" 
                        ErrorMessage="Erreur ! Le format de l'adresse courriel est invalide." 
                        Font-Bold="True" ForeColor="#FF3300" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>    
            </tr>
            <tr>
                <td>Creer</td>
                <td>
                    <asp:Button ID="btnCreate" runat="server" Text="Creer" Width="127px" onclick="btnCreate_Click" />
                </td>
            </tr>
        </table>
        <table class="table table-bordered">
            <tr>
                <th>Téléverser votre image</th>
                <td>
                    <asp:FileUpload id="FileUploadControl" runat="server" />
                </td>
                <td>
                    <asp:Button runat="server" id="UploadBtnC" text="Upload" Height="22px" Width="55px" onclick="UploadBtn_Click" />
                    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
                </td>
            </tr>
        </table>
        <br />
    </div>
    <style type="text/css">
        .footer {
            position : absolute;
        }
    </style>
    <!--<table border="1px solid black">
        <tr>
            <th colspan="2">Mes champs d'intérêts</th>
        </tr>
        <tr>
            <td>Style de musique</td>
            <td>
                <asp:PlaceHolder ID="musicGenres" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Style de livre</td>
            <td>
                <asp:PlaceHolder ID="bookGenres" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Type de film</td>
            <td>
                <asp:PlaceHolder ID="movieGenres" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Marque </td>
            <td>
                <asp:PlaceHolder ID="brands" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Loisir</td>
            <td>
                <asp:PlaceHolder ID="hobbies" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
        <tr>
            <td>Sports</td>
            <td>
                <asp:PlaceHolder ID="sports" runat="server">
                
                </asp:PlaceHolder>
            </td>
        </tr>
    </table> -->
</asp:Content>