<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Agenda.Models.PhoneExt>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" col-md-6 col-md-offset-3">
        <div class="text-center">
            <h3>Detalles de la  Extensión</h3>
        </div>

        <div class="list-group">
            <p class="list-group-item active">Datos</p>

            <div class="list-group-item form form-inline">
                <b><%: Html.DisplayNameFor(model => model.Deparment.Name) %>:</b>
                <%: Html.DisplayFor(model => model.Deparment.Name) %>
            </div>


            <div class="list-group-item">
                <b> <%: Html.DisplayNameFor(model => model.Nombre) %>:</b>
                <%: Html.DisplayFor(model => model.Nombre) %>
            </div>

            <div class="list-group-item">
                <b> <%: Html.DisplayNameFor(model => model.Ext) %>:</b>
                <%: Html.DisplayFor(model => model.Ext) %>
            </div>

            <div class="list-group-item">
                <b> <%: Html.DisplayNameFor(model => model.Status) %>:</b>
                <%: Html.DisplayFor(model => model.Status) %>
            </div>
        </div>

        <div class="text-right">
            <p>
                <%--<input type="submit" value="Guardar" class="btn btn-primary" />--%>
                

                <%--<a href="<%: Url.Action("Edit","Extension") %>" ></a>--%>
            </p>
        </div>
        <p>

            <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id, @class="btn btn-primary" }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
