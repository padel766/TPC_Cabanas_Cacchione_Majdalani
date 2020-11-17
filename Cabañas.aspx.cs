﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Cabañas : System.Web.UI.Page
    {
        public List<Cabaña> ListaCabañasLocal { get; set; }

        public Int64 IDcabaña { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IDcabaña = Convert.ToInt64(Request.QueryString["idComplejo"]);

            CabañaNegocio negocio = new CabañaNegocio();
            ListaCabañasLocal = (List<Cabaña>)(Session["listaCabañas"]);
            if (ListaCabañasLocal == null)
            {
                ListaCabañasLocal = negocio.listarCabañas();
                Session.Add("listaCabañas", ListaCabañasLocal);
            }
            
            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);
            if (idaux != 0)
            {
                List<Cabaña> listaAux = new List<Cabaña>();
                foreach (Dominio.Cabaña item in ListaCabañasLocal)
                { 
                 if(item.complejo.ID==idaux)
                    {
                        listaAux.Add(item);
                    }
                }
                ListaCabañasLocal = listaAux;
            }


            
          
        }
    }
}