<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication1.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <br />
    <asp:Label ID="lblMessage" runat="server">
    
    </asp:Label>
    <asp:PlaceHolder ID="bootstrapMessage" runat="server">
    
    </asp:PlaceHolder>
    <table border="1px solid black">
        <tr>
            <td><asp:Image ID="pbxImage" runat="server" Height="150px" Width="250px" class="img-circle"/></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnLike" runat="server" Text="Like" width="100%" 
                    BackColor="#66FFFF" Font-Names="Century" ForeColor="Black" 
                    onclick="btnLike_Click"/></td>
        </tr>
    </table>
    <table border="1px soldi black" style="float:left" class="table table-striped table-condensed table-hover" >
        <tr>
            <th colspan="2">Mon profile</th>
        </tr>
        <tr>
            <td class="question">ID : </td>
            <td><asp:TextBox ID="txtId" runat="server" ReadOnly="True" class="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="question">Nom d'utilisateur : </td>
            <td><asp:TextBox ID="txtUsername" runat="server" class="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="question">Mot de passe : </td>
            <td><asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="question">Adresse courriel : </td>
            <td><asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox></td>    
        </tr>
        <tr>
            <td class="question">Nombre de Likes : </td>
            <td><asp:TextBox ID="txtNumberOfLikes" runat="server" ReadOnly="True" class="form-control"></asp:TextBox></td>    
        </tr>
        <tr>
            <td class="question">Mettre à jour</td>
            <td>
                <asp:Button ID="btnMAJInformations" runat="server" Text="Mettre à jour mes informations" 
                    onclick="btnMAJ_Click" class="btn btn-primary btn-block btn-lg"/>
            </td>
        </tr>
    </table>
    <asp:FileUpload id="FileUploadControl" runat="server" />
    <asp:Button runat="server" id="UploadBtn" text="Upload" 
         Height="22px" Width="55px" onclick="UploadBtn_Click" />
         <!-- http://asp.net-tutorials.com/controls/file-upload-control/ -->
    <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
    <br />
    <form action="profile.aspx" method="post">
    <table border="1px solid black" class="table table-striped table-bordered table-hover">
        <tr>
            <th colspan="2">Mes champs d'intérêts</th>
        </tr>
        <tr>
            <td class="question">Style de musique</td>
            <td>
                <asp:DropDownList ID="ddlMusic" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Style de livre</td>
            <td>
                <asp:DropDownList ID="ddlBooks" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Type de film</td>
            <td>
                <asp:DropDownList ID="ddlMovies" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Marque </td>
            <td>
                <asp:DropDownList ID="ddlBrands" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Loisir</td>
            <td>
                <asp:DropDownList ID="ddlHobbies" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Sports</td>
            <td>
                <asp:DropDownList ID="ddlSports" runat="server" class="form-control">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="question">Mettre à jour mes intérêts</td>
            <td>
                <asp:Button ID="btnMAJinterests" runat="server" onclick="btnMAJinterests_Click" 
                    Text="Metttre à jour mes intérêts" class="btn btn-warning btn-lg btn-block"/>
            </td>                
        </tr>
    </table>
    </form>
    <style type="text/css">
        .question 
        {
            text-align:left;
            text-transform : capitalize;
            letter-spacing: 5px;
            font-family : Century;
            font-size : large; 
        }
    </style>
</asp:Content>