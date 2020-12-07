﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministradoresDeComplejos.aspx.cs" Inherits="TPC_CacchioneMajdalani.AdministradoresDeComplejos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col" style="width: 120px">Imagen de Perfil</th>
                            <th scope="col" style="width: 100px">Nombre de usuario</th>
                            <th scope="col" style="width: 100px">Nombre</th>
                            <th scope="col" style="width: 100px">Apellido</th>
                            <th scope="col" style="width: 100px">Complejo que Administra</th>
                            <th scope="col" style="width: 60px">Email</th>
                            <th scope="col" style="width: 60px">Nivel de permisos (de 20 a 29) </th>
                            <th scope="col" style="width: 60px">Email Complejo</th>
                        </tr>
                    </thead>
                    <%foreach (Dominio.Usuario item in ListaAdministradores)
                        { %>
                    <tr>
                        <td style="width: 140px">
                            <img src="<% = item.DatosPersonales.UrlImagen %>" style="width: 100px; height: inherit;" alt="No posee imagen cargada">

                            <th scope="row" style="width: 120px"><% = item.NombreUsuario %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Nombre %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Apellido %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Email %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Telefono %></th>

                            <th scope="row" style="width: 60px"><% = item.NivelAcceso %></th>

                            <th scope="row" style="width: 60px"><% = item.Estado %></th>

                            <%if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso > item.NivelAcceso)
                                { %>
                            <th scope="row"><a class="btn btn-secondary" href="ModificarUsuario.aspx?idUsuario=<% = item.Id.ToString() %>">Modificar</a></th>
                            <% } %> 

                        </td>
                    </tr>

                    <% } %>
                </table>
            </div>
        </div>
    </div>







</asp:Content>
