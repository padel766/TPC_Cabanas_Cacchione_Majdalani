﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuario = new Usuario();

                long id = Convert.ToInt64(Request.QueryString["idUsuario"]);
                if (id != 0)
                {

                    usuario = (Usuario)Session[Session.SessionID + "userSession"];
                    CargarInputsUsuarios();

                }
            }

        }

        private void CargarInputsUsuarios()
        {

            NombreUsuario.Value = usuario.NombreUsuario;
            Contraseña.Value = usuario.Contraseña;
            DDLEstado.SelectedValue = usuario.Estado.ToString();
            DDLNivelAcceso.SelectedValue = usuario.NivelAcceso.ToString();
            Nombre.Value = usuario.DatosPersonales.Nombre;
            Apellido.Value = usuario.DatosPersonales.Apellido;
            Telefono.Value = usuario.DatosPersonales.Telefono;
            Domicilio.Value = usuario.DatosPersonales.Domicilio;
            DNI.Value = usuario.DatosPersonales.DNI;
            Email.Value = usuario.DatosPersonales.Email;
            DDLGenero.SelectedValue = usuario.DatosPersonales.Genero;
            UrlImagen.Value = usuario.DatosPersonales.UrlImagen;
            DDLPaises.SelectedValue = usuario.DatosPersonales.PaisOrigen;

        }
        private void GuardarInputsUsuarios()
        {

            usuario.NombreUsuario = NombreUsuario.Value;
            usuario.Contraseña = Contraseña.Value;
            usuario.Estado = Convert.ToBoolean(DDLEstado.SelectedValue);
            usuario.NivelAcceso = Convert.ToByte(DDLNivelAcceso.SelectedValue);
            usuario.DatosPersonales.Nombre = Nombre.Value;
            usuario.DatosPersonales.Apellido = Apellido.Value;
            usuario.DatosPersonales.Telefono = Telefono.Value;
            usuario.DatosPersonales.Domicilio = Domicilio.Value;
            usuario.DatosPersonales.DNI = DNI.Value;
            usuario.DatosPersonales.Email = Email.Value;
            usuario.DatosPersonales.Genero = DDLGenero.SelectedValue;
            usuario.DatosPersonales.UrlImagen = UrlImagen.Value;
            usuario.DatosPersonales.PaisOrigen = DDLPaises.SelectedValue;

        }
        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            UsuarioNegocio Negocio = new UsuarioNegocio();
            GuardarInputsUsuarios();
            Negocio.ActualizarUsuario(usuario);
        }
    }
}