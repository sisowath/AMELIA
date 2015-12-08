<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="achat.aspx.cs" Inherits="WebApplication1.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="bootstrapMessage" runat="server">
    
    </asp:PlaceHolder>
    <asp:Image ID="Image1" runat="server" 
        ImageUrl="~/images/visa-_mastercard.png" />
    <asp:Image ID="Image2" runat="server" Height="154px" 
        ImageUrl="~/images/paypal.png" />
    <asp:Image ID="Image3" runat="server" Height="151px" 
        ImageUrl="~/images/american_express.png" Width="166px" />
    <hr />
    <h1>Achat de « Like »<asp:RegularExpressionValidator 
            ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="Erreur ! Le numéro de carte de crédit est invalide..." 
            Font-Bold="True" ForeColor="Red" 
            ControlToValidate="txtNumeroDeCarteDeCredit" 
            ValidationExpression="\d{4}-\d{4}-\d{4}-\d{4}" Font-Size="X-Large" 
            Display="Dynamic" Font-Names="Century"></asp:RegularExpressionValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txtNumberOfLikes" 
            ErrorMessage="Erreur ! Veuillez saisir un nombre entier." Font-Bold="True" 
            Font-Names="Century" Font-Size="X-Large" ForeColor="Red" 
            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
    </h1>
    <table class="table table-striped table-bordered" ng-app="" ng-init="nombreDeLike=1">
        <tr>
            <td class="style1">Nombre de Like </td>
            <td>
                <asp:TextBox ID="txtNumberOfLikes" runat="server" class="form-control" ng-model="nombreDeLike"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">Total </td>
            <td><input type="text" name="total" class="form-control" readonly="readonly" value="{{ (nombreDeLike * 0.25) }} $"/></td>
        </tr>
        <tr>
            <td class="style1">Numéro de carte de crédit</td>
            <td>
                <asp:TextBox ID="txtNumeroDeCarteDeCredit" runat="server" class="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">date d'expiration </td>
            <td><input type="date" name="dateExpiration" class="form-control"/></td>
        </tr>
        <tr>
            <td class="style2"></td>
            <td><asp:Button ID="btnCommander" Text="Commander" runat="server" 
                    onclick="btnCommander_Click" class="btn btn-success btn-lg btn-block"/></td>
        </tr>
    </table>
    <div id="card_form">
    <h1 align="center">Credit Card Protection</h1>
<table>
  <tbody><tr>
    <td class="style1"><label for="card_number">Credit card number</label></td>
    <td>
      <input class="style1" type="text" name="card_number" id="card_number" size="25" pattern=".{12}|.{16}" required title="Either 12 OR 16 numbers" autocomplete="off"/>
    </td>
  </tr>
  <tr>
    <td class="style1"><label for="card_name">Name on credit card</label></td>
    <td>
      <input class="style1" type="text" name="card_name" id="card_name" size="25" maxlength="40" placeholder="Louis-Etienne Lemire" required autocomplete="off"/>
    </td>
  </tr>
  <tr>
    <td class="style1">Expiration Date</td>
    <td>
      <select class="style1" name="month" title="Month" id="card_month" required>
        <option value="01" selected="selected">
          01
        </option>
        <option value="02">
          02
        </option>
        <option value="03">
          03
        </option>
        <option value="04">
          04
        </option>
        <option value="05">
          05
        </option>
        <option value="06">
          06
        </option>
        <option value="07">
          07
        </option>
        <option value="08">
          08
        </option>
        <option value="09">
          09
        </option>
        <option value="10">
          10
        </option>
        <option value="11">
          11
        </option>
        <option value="12">
          12
        </option>
      </select>&nbsp;/&nbsp;<select class="style1" name="card_year" title="Year" id="card_year" required>
        <option value="2015" selected="selected">
          2015
        </option>
        <option value="2016">
          2016
        </option>
        <option value="2017">
          2017
        </option>
        <option value="2018">
          2018
        </option>
        <option value="2019">
          2019
        </option>
        <option value="2020">
          2020
        </option>
        <option value="2021">
          2021
        </option>
        <option value="2022">
          2022
        </option>
        <option value="2023">
          2023
        </option>
        <option value="2024">
          2024
        </option>
        <option value="2025">
          2025
        </option>
      </select>
    </td>
  </tr>
</tbody></table>
<!-- Start form here so credit card details aren't submitted. -->
  <input class="style1" type="hidden" value="Check if my credit card is stolen" name="chkBut">

    <asp:Button class="style1" ID="chkBut" runat="server" 
            Text="Check if my credit card is stolen" onclick="chkBut_Click" />

</div>
    <style type="text/css">
        .footer 
        {
            position : relative;
        }
        .questions 
        {
            text-align:left;
            text-transform : capitalize;
            letter-spacing: 5px;
            font-family : Century;
            font-size : large;            
        }
        .style1
        {
            text-align: left;
            text-transform : capitalize;
            letter-spacing: 5px;
            font-family : Century;
            font-size : large;
            width: 460px;
        }
        .style2
        {
            width: 460px;
        }
    </style>
</asp:Content>
