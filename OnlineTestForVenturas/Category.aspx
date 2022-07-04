<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="OnlineTestForVenturas.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="categoryNameLabel" runat="server" Text="Category Name"></asp:Label>
    <asp:TextBox ID="categoryTextBox" runat="server"></asp:TextBox> 
    <asp:Label ID="descLabel" runat="server" Text="Category Description"></asp:Label>
    <asp:TextBox ID="descTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:HiddenField runat="server" ID="categoryIdHdn" Value="" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

    <asp:GridView ID="categoriesGv" runat="server" AutoGenerateColumns="False" OnRowCommand="categoriesGv_RowCommand">
        <Columns>
            <asp:BoundField DataField="CategoryId" HeaderText="Id" />
            <asp:BoundField DataField="CategoryName" HeaderText="Name" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" CommandName="select" Text="Select" CommandArgument='<%# Eval("CategoryId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
