<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Agenda.Models.PhoneExt>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>PhoneExt</legend>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Deparment.Name) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Deparment.Name) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Nombre) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nombre) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Ext) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Ext) %>
    </div>

    <div class="display-label">
        <%: Html.DisplayNameFor(model => model.Status) %>
    </div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Status) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <%: Html.AntiForgeryToken() %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
