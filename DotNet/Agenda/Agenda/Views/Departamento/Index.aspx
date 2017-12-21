<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Agenda.Models.Deparment>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class=" col-md-6 col-md-offset-3">
        <div class="text-center">
            <h2>Listado de Departamentos</h2>
        </div>

        <div class="form-group">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>
                            <%: Html.DisplayNameFor(model => model.Name) %>
                        </th>
                        <th>Operar</th>
                    </tr>
                </thead>
                <tbody>
                    <% foreach (var item in Model)
                       { %>
                    <tr>
                        <td>
                            <%: Html.DisplayFor(modelItem => item.Name) %>
                        </td>
                        <td>
                            <%: Html.ActionLink("Editar", "Edit", new { id=item.Id }) %> |
            <%: Html.ActionLink("Detalle", "Details", new { id=item.Id }) %> |
            <%: Html.ActionLink("Eliminar", "Delete", new { id=item.Id }) %>
                        </td>
                    </tr>
                </tbody>
                <% } %>
            </table>
        </div>
        <div>
            <p class="text-right">
                <a href="<%: Url.Action("Create","Departamento") %>" class="btn btn-primary">Nuevo</a>

            </p>
        </div>

    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
