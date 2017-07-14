<%@ Page Title="Dostępne aukcje" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Auctions.aspx.cs" Inherits="Portal_aukcyjny.Auctions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListView ID="AuctionsList" runat="server" GroupItemCount="5" GroupPlaceholderID="GroupPlaceHolder" ItemPlaceholderID="ItemPlaceHolder" DataSourceID="EntityDataSource1">
        <LayoutTemplate>
            <table>
                <asp:PlaceHolder ID="GroupPlaceHolder" runat="server" />
            </table>

        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td>
                <table style="width: 250px; height: 300px;">
                    <tr>
                        <td>
                            <asp:HyperLink ID="HPL" runat="server" NavigateUrl='<%#"SingleAuction.aspx?url=" +Eval("PhotoPath") + "&AuctionId=" +Eval("Id")%>'>
                                <asp:Image ID="Photo" runat="server"  ImageUrl='<%#Eval("PhotoPath")%>' Width="200px" Height="200px" />
                            </asp:HyperLink>
                            <br />
                                 <asp:Label ID="ModelLabel" runat="server" Text='<%#Eval("Brand") + " " +  Eval("Model") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
           
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                Brak dostępnych aukcji
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=PortalAukcyjnyCZEntities" DefaultContainerName="PortalAukcyjnyCZEntities" EnableFlattening="False" EntitySetName="AspNetAuctions" Select="it.[PhotoPath], it.[Model], it.[Brand], it.[Id]">
    </asp:EntityDataSource>
</asp:Content>
