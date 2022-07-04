<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OutPut.aspx.cs" Inherits="OnlineTestForVenturas.OutPut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:Button ID="btnShow" runat="server" Text="Show Output" OnClick="btnShow_Click" />
        <asp:GridView ID="gvOutput" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
