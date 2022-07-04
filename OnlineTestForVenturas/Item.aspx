<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="OnlineTestForVenturas.Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <br />
        Choose Category
        <asp:DropDownList ID="ddlItems" runat="server">
        </asp:DropDownList>
        Item Name
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <asp:HiddenField ID="hdnItemId" runat="server" Value="" />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Udpate" />
        <br />
        <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" OnRowCommand="gvItems_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Category Name" DataField="CategoryName"/>
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="select" Text="Select" CommandArgument='<%# Eval("ItemId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
