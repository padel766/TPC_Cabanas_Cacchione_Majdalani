﻿<%@ Page Title="Complejos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complejos.aspx.cs" Inherits="TPC_CacchioneMajdalani.Complejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <hr />
    
    <div>
    <h2><%: Title %>.</h2>
    <asp:TextBox ID="TxtBuscarComplejo" CssClass="d-inline-flex, border-light" MaxLength="120" runat="server"></asp:TextBox>
    <asp:Button Class="btn btn-primary mr-auto ml-auto" OnClick="BtnBuscarComplejo_Click" ID="BtnBuscarComplejo" runat="server" Text="Buscar" />
    <a href="AgregarModificarComplejo.aspx" class="btn btn-success mr-auto ml-auto">Agregar</a>
    </div>
    
       
         <%--  <div class="row align-content-md-between">
           <%foreach (Dominio.Complejo item in ListaComplejosLocal)
               {%>
                    <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=item.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body" style="background-color:#6E9038;">
                          
                                <ul>
                                    <li><h5 class="card-title"><%=item.Nombre%></h5></li> 
                                    <li><h5 class="card-title"><%=item.Ubicacion%></h5></li>
                                </ul>
                                
                                
                                
                                <a href="DetalleComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle</a>
                                <a href="Cabañas.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Cabañas</a>
                                <a href="AgregarModificarComplejo.aspx?IdComplejo=<%=item.ID.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                                <a href="EliminarComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
                        <%--    </div>
                        </div>
                    </div>    --%>    
      <%--          <%
               }%>  
        </div>--%>
   
      <%foreach (Dominio.Complejo item in ListaComplejosLocal)
        {%>

    <table class="table">
        <tr>
            <td><img src="<%=item.Imagen%>" class="card-img-top" alt="..." style="width:300px;"></td>
            <td><%=item.Nombre%></td> 
            <td><%=item.Ubicacion%> </td>
            <td><a href="DetalleComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle</a></td>
            <td><a href="Cabañas.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Cabañas</a></td>
            <td><a href="AgregarModificarComplejo.aspx?IdComplejo=<%=item.ID.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a></td>
            <td><a href="EliminarComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a></td>
        </tr>
    </table>
    <%}
    %>




</asp:Content>
