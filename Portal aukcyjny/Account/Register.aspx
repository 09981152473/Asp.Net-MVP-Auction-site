<%@ Page Title="Rejestracja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Portal_aukcyjny.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hr />
    <asp:Label runat="server" ID="RegisterLbl"></asp:Label>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Wypełnij pole" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    CssClass="text-danger" ErrorMessage="Podany adres e-mail jest nieprawidłowy" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="PasswordLbl" AssociatedControlID="Password" CssClass="col-md-2 control-label">Hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Wypełnij pole" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Password" ValidationExpression="^[\s\S]{6,16}$"
                    CssClass="text-danger" ErrorMessage="Twoje hasło musi mieć od 6 do 16 znaków"/>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="ConfirmLbl" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="form-control" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Wypełnij pole" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Hasła się nie zgadzają" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="RegisterBtn" OnClick="CreateUser_Click" Text="Zarejestruj się" CssClass="btn btn-default" />
            </div>
        </div>

    </div>
</asp:Content>
