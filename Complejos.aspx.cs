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
    public partial class Complejos : System.Web.UI.Page
    {
        public List<Complejo> ListaComplejosLocal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComplejoNegocio negocio = new ComplejoNegocio();

            try
            {
                ListaComplejosLocal = (List<Complejo>)(Session["listaComplejos"]);
                if (ListaComplejosLocal == null)
                {
                    ListaComplejosLocal = negocio.listarComplejos();
                    Session.Add("listaComplejos", ListaComplejosLocal);
                }
            }
        
            catch (Exception ex)
            {
                 Session.Add("Cualquier nombre", ex.ToString());
                 Response.Redirect("Error.aspx");
            }
        }
    }
}
