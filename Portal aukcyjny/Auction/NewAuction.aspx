<%@ Page Title="Wystaw samochód" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewAuction.aspx.cs" Inherits="Portal_aukcyjny.NewAuction" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <asp:Label runat="server" ID="TitleLbl"></asp:Label>
    
    <div class="form-horizontal">
        
        <div class="form-group">
            <asp:Label runat="server" ID="BrandLbl" AssociatedControlID="ModelBrand" CssClass="col-md-2 control-label">Marka</asp:Label>
          <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ModelBrand" Width="280px" AutoPostBack="true" OnSelectedIndexChanged="Brand_SelectedIndexChanged">
                    <asp:ListItem Text="Fiat" Value="Fiat"></asp:ListItem>
                    <asp:ListItem Text="Renault" Value="Renault"></asp:ListItem>
                    <asp:ListItem Text="Volkswagen" Value="Volkswagen"></asp:ListItem>
                </asp:DropDownList>
           </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="ModelLbl" AssociatedControlID="Model" CssClass="col-md-2 control-label">Model</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Model" Width="280px" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="Model" DataValueField="Id">
                    
                </asp:DropDownList>
                <asp:EntityDataSource ID="ModelEntity" runat="server" ConnectionString="name=PortalAukcyjnyCZEntities" DefaultContainerName="PortalAukcyjnyCZEntities" EnableFlattening="False" EntitySetName="AspNetModels" EnableUpdate="True">
                </asp:EntityDataSource>
           </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" ID="MileageLbl" AssociatedControlID="Mileage" CssClass="col-md-2 control-label">Przebieg</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Mileage" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Mileage"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Podaj przebieg samochodu" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Mileage" ValidationExpression="^(0|[1-9][0-9]*)$"
                    CssClass="text-danger" ErrorMessage="Podaj prawidłowy przebieg"/>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" ID="ProductionYearLbl" AssociatedControlID="ProductionYear" CssClass="col-md-2 control-label">Rok produkcji</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ProductionYear" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProductionYear"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Podaj rok produkcji samochodu" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="ProductionYear" ValidationExpression="^\d{4}$"
                    CssClass="text-danger" ErrorMessage="Podaj prawidłowy rok produkcji"/>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="FuelLbl" AssociatedControlID="Fuel" CssClass="col-md-2 control-label">Rodzaj paliwa</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Fuel" Width="280px" AutoPostBack="true">
                    <asp:ListItem Text="Benzyna" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Diesel" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Gaz" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" ID="PriceLbl" AssociatedControlID="Price" CssClass="col-md-2 control-label">Cena</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Price"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Podaj cenę samochodu" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Price" ValidationExpression="^(0|[1-9][0-9]*)$"
                    CssClass="text-danger" ErrorMessage="Podaj prawidłową cenę"/>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" ID="PictureLbl" AssociatedControlID="Picture" CssClass="col-md-2 control-label">Zdjęcie</asp:Label>
            <div class="col-md-10">
                <asp:FileUpload runat="server" ID="Picture" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Picture"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Wyślij zdjęcie samochodu" />
            </div>
        </div>

         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="PostBtn" OnClick="CreateAuction_Click" Text="Wystaw" CssClass="btn btn-default" />
            </div>
        </div>

    </div>
    </asp:Content>