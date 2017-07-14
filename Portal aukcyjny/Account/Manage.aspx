<%@ Page Title="Zarządzanie kontem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Portal_aukcyjny.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <asp:Label runat="server" ID="msg" Text="Zmień ustawienia konta"></asp:Label>
                <hr /> 
                <dl class="dl-horizontal">
                    <asp:Label runat="server" ID="Pswd" Text="Hasło: "></asp:Label>
                    <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Zmień]" Visible="true" ID="ChangePassword" runat="server" />
                </dl>
            </div>
        </div>
    </div>

</asp:Content>
