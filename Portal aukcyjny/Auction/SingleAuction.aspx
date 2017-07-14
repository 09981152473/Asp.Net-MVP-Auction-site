<%@ Page Title="Aukcja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingleAuction.aspx.cs" Inherits="Portal_aukcyjny.SingleAuction" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ListView ID="Auction" runat="server" DataSourceID="AuctionEntity" OnItemDataBound="Auction_ItemDataBound">
        <ItemTemplate>
            <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server"  ID="BrandLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server"  ID="BrandName" CssClass="col-md-2 control-label"><%# Eval ("Brand") %></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server"   ID="ModelLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server"   ID="ModeName" CssClass="col-md-2 control-label"><%# Eval ("Model") %></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server"  ID="MileageLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server"  ID="MileageName" CssClass="col-md-2 control-label"><%# Eval ("Mileage") %></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server"  Id="ProductionYearLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server"  ID="ProductionYearName" CssClass="col-md-2 control-label"><%# Eval ("ProductionYear") %></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server"  ID="FuelLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server"  ID="FuelName" CssClass="col-md-2 control-label"><%# Eval ("Fuel") %></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="PriceLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server" ID="PriceName" CssClass="col-md-2 control-label"><%# Eval ("Price") %></asp:Label>
                    </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="EurLbl" CssClass="col-md-2 control-label"></asp:Label>
                    <asp:Label runat="server" ID="EurName" CssClass="col-md-2 control-label"></asp:Label>
                </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="SellerLbl" CssClass="col-md-2 control-label"></asp:Label>
                        <asp:Label runat="server" ID="SellerName" CssClass="col-md-2 control-label"><%# Eval ("AspNetUsers.UserName") %></asp:Label>
                    </div>
                    </div>
        </ItemTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="AuctionEntity" runat="server" ConnectionString="name=PortalAukcyjnyCZEntities" DefaultContainerName="PortalAukcyjnyCZEntities" EnableFlattening="False" Include="AspNetUsers" EnableInsert="True" EnableUpdate="True" EntitySetName="AspNetAuctions">
    </asp:EntityDataSource>
    <br />
    <br />
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" ID="NameLbl" CssClass="col-md-2 control-label"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="txtName" ErrorMessage="Podaj nazwę" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="EmailLbl" CssClass="col-md-2 control-label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Podaj adres e-mail" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Adres e-mail jest nieprawidłowy" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="CommentLbl" CssClass="col-md-2 control-label"></asp:Label>
            <asp:TextBox ID="txtComment" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVComment" runat="server" ControlToValidate="txtComment" ErrorMessage="Napisz komentarz" ForeColor="#CC0000">*</asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="PostBtn" runat="server" Text="Skomentuj" OnClick="btn_Submit_Click" CssClass="buttonSubmit"/>
    </div>
    <asp:Label runat="server" ID="CommentsHeader" Font-Size="Large" Font-Bold="true"></asp:Label>
    <hr />              
        <asp:Repeater ID="CommentRepeater" runat="server" DataSourceID="CommentsEntity">
            <ItemTemplate>
                <div class="commentbox">
                    <b>
                        <asp:Label ID="NameLbl" runat="server" Text='<%#Eval("Name") %>'>'></asp:Label>
                        </b>&nbsp;(<asp:Label ID="EmailLbl" runat="server" Text='<%#Eval("Email") %>'>'></asp:Label>):<br />
                        <asp:Label ID="CommentLbl" runat="server" Text='<%#Eval("Comment") %>'></asp:Label><br />
                 </div>
            </ItemTemplate>
       </asp:Repeater>
    <asp:EntityDataSource ID="CommentsEntity" runat="server" ConnectionString="name=PortalAukcyjnyCZEntities" DefaultContainerName="PortalAukcyjnyCZEntities" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="AspNetComments">
    </asp:EntityDataSource>
    </asp:Content>
