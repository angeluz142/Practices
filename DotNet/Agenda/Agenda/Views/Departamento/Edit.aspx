<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Agenda.Models.Deparment>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" col-md-6 col-md-offset-3">
        <div class="text-center">
            <h3>Editar Departamento</h3>
        </div>
        

        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <%: Html.HiddenFor(model => model.Id) %>

        <div class="form-inline">



            <div class="form-group">
                <%: Html.LabelFor(model => model.Name) %>
                <%: Html.TextBoxFor(model => model.Name, new { @class="form-control" })%>
                <%: Html.ValidationMessageFor(model => model.Name) %>
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
            <p>
            </p>
        </div>
    </div>
    <% } %>

    <div>
        <%: Html.ActionLink("Regresar", "Index") %>
    </div>

</asp:Content>
