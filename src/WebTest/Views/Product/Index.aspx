<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebTest.Models.Product>" %>
<%@ Import Namespace="HtmlTags.Adapter"%>
<%@ Import Namespace="HtmlTags.UI.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Product Details</h2>

	<h3>With the standard LabelFor, InputFor, and DisplayFor helpers:</h3>
    
	<p><%= Html.LabelFor(x => x.Id) %>: <%= Html.InputFor(x => x.Id) %> Value: <%= Html.DisplayFor(x => x.Id) %></p>
	<p><%= Html.LabelFor(x => x.Name) %>: <%= Html.InputFor(x => x.Name) %> Value: <%= Html.DisplayFor(x => x.Name) %></p>
	<p><%= Html.LabelFor(x => x.Created) %>: <%= Html.InputFor(x => x.Created)%> Value: <%= Html.DisplayFor(x => x.Created)%></p>
	<p><%= Html.LabelFor(x => x.InStock) %>: <%= Html.InputFor(x => x.InStock)%> Value: <%= Html.DisplayFor(x => x.InStock)%></p>

	<h3>With the EditorForTemplate helper:</h3>

	<%= Html.EditTemplateFor(x => x.Id) %>
	<%= Html.EditTemplateFor(x => x.Name) %>
	<%= Html.EditTemplateFor(x => x.Created) %>
	<%= Html.EditTemplateFor(x => x.InStock) %>

	<h3>With the DisplayForTemplate helper:</h3>

	<%= Html.DisplayTemplateFor(x => x.Id) %>
	<%= Html.DisplayTemplateFor(x => x.Name)%>
	<%= Html.DisplayTemplateFor(x => x.Created)%>
	<%= Html.DisplayTemplateFor(x => x.InStock)%>

</asp:Content>
