﻿<%@ Page Title="Mis Cabañas Favoritas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CabañasFavoritas.aspx.cs" Inherits="TPC_CacchioneMajdalani.CabañasFavoritas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding:2% 0 0 0">
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Complejo</th>
                            <th scope="col">Imagen Cabaña</th>
                            <th scope="col">Precio Diario</th>
                            <th scope="col">Capacidad</th>
                            <th scope="col">¿Qué querés hacer?</th>
                        </tr>
                    </thead>
                    <%foreach (Dominio.Cabaña item in ListaFavoritas)
                        { %>
                    <tr>
                        <th scope="row"><% = item.complejo.Nombre %> 
                            
                        </th>
                        <td>
                            <img src="<% = item.Imagen %>" style="width: 200px; height: inherit;" alt="...">

                            <th scope="row">$<% = item.PrecioDiario %></th>

                            <th scope="row"><% = item.Capacidad %> personas</th>

                            <th scope="row">
                                <a class="btn btn-danger mr-auto ml-auto" href="CabañasFavoritas.aspx?idQuitar=<% = item.Id.ToString() %>">Eliminar</a>
                                <a href="Reservas.aspx?idCabaña=<%=item.Id.ToString() %>" class="btn btn-success mr-auto ml-auto">Reservar</a>
                            </th>

                        </td>
                    </tr>

                    <% } %>
                    <tr>
                        <td>
                            <button type="button" class="btn btn-primary">
                                Cantidad de favoritas <span class="badge badge-light"> <%=ContarFavoritas() %> </span>
                            </button>
                        </td>
                    </tr>

                </table>
                <div class="container" style="padding:0% 2% 0 1.5%">
                    <td><a href="Cabañas.aspx" class="btn btn-secondary" role="button">Ir a la lista de Cabañas</a></td>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
