<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Agenda.Models.PhoneExt>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class=" col-md-8 col-md-offset-2">
        <div class="text-center">
            <h2>Listado de Extensiones</h2>
        </div>

        <div class="from-group">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>
                            <%: Html.DisplayNameFor(model => model.Deparment.Name) %>
                        </th>
                        <th>
                            <%: Html.DisplayNameFor(model => model.Nombre) %>
                        </th>
                        <th>
                            <%: Html.DisplayNameFor(model => model.Ext) %>
                        </th>
                        <th>Operar</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in Model)
                       { %>
                    <tr>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.Deparment.Name) %>
                        </td>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.Nombre) %>
                        </td>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.Ext) %>
                        </td>
                        <td>
                            <%: Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Details", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id=item.Id }) %>
                        </td>
                    </tr>
                </tbody>
                <% } %>
            </table>
        </div>
        <div>
            <p class="text-right">
                <a href="<%: Url.Action("Create","Extension") %>" class="btn btn-primary">Nuevo</a>

            </p>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
