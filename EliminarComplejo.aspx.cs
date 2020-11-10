﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class EliminarComplejo : System.Web.UI.Page
    {
        public Complejo Aux { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComplejoNegocio negocio= new ComplejoNegocio();

            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);

            List<Complejo> listaAux = new List<Complejo>();
            listaAux = (List<Complejo>)Session["listaComplejos"];
            Aux = listaAux.Find(i => i.ID == idaux);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            if(check_eliminar.Checked)
            {
                ComplejoNegocio auxNeg = new ComplejoNegocio();
                auxNeg.EliminarComplejoPorId(Aux.ID);
                
                List<Complejo> listaAuxComplejos = new List<Complejo>();
                listaAuxComplejos = (List<Complejo>)Session["listaComplejos"];
                listaAuxComplejos.RemoveAll(i => i.ID == Aux.ID);
                Session["listaComplejos"] = listaAuxComplejos;

                List<Cabaña> listaAuxCabañas = new List<Cabaña>();
                listaAuxCabañas = (List<Cabaña>)Session["listaCabañas"];
                listaAuxCabañas.RemoveAll(i => i.complejo.ID == Aux.ID);
                Session["listaCabañas"] = listaAuxCabañas;

                Response.Redirect("Complejos.aspx");
            }
            else
            {
                if(check_eliminar.ForeColor== System.Drawing.Color.Red)
                {
                    check_eliminar.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    check_eliminar.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}