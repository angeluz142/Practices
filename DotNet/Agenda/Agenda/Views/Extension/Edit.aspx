<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Agenda.Models.PhoneExt>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" col-md-6 col-md-offset-3">
        <div class="text-center">
            <h3>Editar Exensión</h3>
        </div>

        <% using (Html.BeginForm())
           { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <div class="col-md-12">

            <%: Html.HiddenFor(model => model.Id) %>

            <div class="form-group">
                <%: Html.LabelFor(model => model.Department, "Deparment") %>
                <%: Html.DropDownListFor(model => model.Department,ViewBag.Deparment as SelectList,new { @class="form-control" }) %>
                <%: Html.ValidationMessageFor(model => model.Department) %>
            </div>

            <div class="form-group">
                <%: Html.LabelFor(model => model.Nombre) %>
                <%: Html.TextBoxFor(model => model.Nombre, new { @class="form-control" }) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>

            <div class="form-group">
                <%: Html.LabelFor(model => model.Ext) %>
                <%: Html.TextBoxFor(model => model.Ext, new { @class="form-control" }) %>
                <%: Html.ValidationMessageFor(model => model.Ext) %>
            </div>

            <div class="form-group">
                <%: Html.LabelFor(model => model.Status) %>
                <%: Html.TextBoxFor(model => model.Status, new { @class="form-control" }) %>
                <%: Html.ValidationMessageFor(model => model.Status) %>
            </div>

            <div class="text-right">
                <p>
                    <input type="submit" value="Aceptar" class="btn btn-primary" />
                </p>
            </div>
        </div>
        <% } %>

        <div>
            <%: Html.ActionLink("Back to List", "Index") %>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
