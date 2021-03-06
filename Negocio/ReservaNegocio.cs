﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;

namespace Negocio
{
    public class ReservaNegocio
    {
        //InsertarNuevaReserva(servaVieja, reservaNueva); // en modificar reserva sería InsertarNuevaReserva(servaVieja, reservaNueva) esto no cambia
        public bool InsertarReserva(Reserva reserva)
        {
            AccessDB access = new AccessDB();
            bool retorno = true;
            try
            {
                access.AgregarParametroSP("@IdCabaña", reserva.Cabaña.Id, SqlDbType.BigInt);
                access.AgregarParametroSP("@IdUsuario", reserva.Cliente.Id, SqlDbType.BigInt);
                access.AgregarParametroSP("@FechaIngreso", reserva.FechaIngreso.ToShortDateString(), SqlDbType.Date);
                access.AgregarParametroSP("@FechaEgreso", reserva.FechaEgreso.ToShortDateString(), SqlDbType.Date);
                access.AgregarParametroSP("@CantPersonas", reserva.CantPersonas, SqlDbType.TinyInt);
                access.AgregarParametroSP("@FechaReserva", reserva.FechaCreacionReserva.ToShortDateString(), SqlDbType.Date); // esto no cambia nunca
                access.AgregarParametroSP("@Importe", reserva.Importe, SqlDbType.Money);
                access.AgregarParametroSP("@Estado", reserva.Estado, SqlDbType.TinyInt);
                access.AgregarParametroSP("@IdReservaOriginal", reserva.IdReservaOriginal, SqlDbType.BigInt);
                if (access.EjecutarStoredProcedureIntReturn("spAgregarReserva") == 0)
                {
                    retorno = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return retorno;

        }

        public List<Reserva> ListarReservasVigentesPorUsuario(long idUsuario, byte Estado)
        {
            List<Reserva> listaVigentesUsuario = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaingreso>=getdate() and " +
                    "idusuario=" + idUsuario + "and estado=" + Estado);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        ID = (long)access.Lector["ID"],
                        Cliente = usuarioNegocio.ListarUsuarioPorId((long)access.Lector["idUsuario"]),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };

                    listaVigentesUsuario.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaVigentesUsuario;
        }


        public List<Reserva> ListarReservasCaducasPorUsuario(long idUsuario, byte Estado)
        {
            List<Reserva> listaCaducasUsuario = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaingreso<=getdate() and idusuario=" + idUsuario + " and estado=" + Estado);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        ID = (long)access.Lector["ID"],
                        Cliente = usuarioNegocio.ListarUsuarioPorId((long)access.Lector["idUsuario"]),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };
                    listaCaducasUsuario.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaCaducasUsuario;
        }

        public List<Reserva> ListarReservasVigentesPorEstado(byte estado)
        {
            List<Reserva> listaReservasVigentes = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaingreso>=getdate() and estado=" + estado);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        ID = (long)access.Lector["ID"],
                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };
                    listaReservasVigentes.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaReservasVigentes;
        }

        public List<Reserva> ListarReservasCaducasPorEstado(byte estado)
        {
            List<Reserva> listaReservasCaducas = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaingreso<=getdate() and estado=" + estado);
                access.EjecutarLector();

                while (access.Lector.Read())
                {

                    Reserva aux = new Reserva
                    {
                        ID = (long)access.Lector["ID"],
                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };
                    listaReservasCaducas.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaReservasCaducas;
        }

        public void ResolverReserva(long idReserva, byte nuevoEstado)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update reservas set estado=@estado where id=" + idReserva);
                access.AgregarParametro("@estado", nuevoEstado);
                access.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
        }

        public Reserva ListarReservaPorId(long idReserva)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            CabañaNegocio cabañaNegocio = new CabañaNegocio();
            AccessDB access = new AccessDB();
            Reserva reserva = new Reserva();
            try
            {
                access.SetearQuery("select * from reservas where Id=" + idReserva);
                access.EjecutarLector();
                access.Lector.Read();

                reserva.ID = (long)access.Lector["ID"];
                reserva.Cliente = usuarioNegocio.ListarUsuarioPorId((long)access.Lector["idUsuario"]); //Capaz convenga agregar el atributo Id a la clase Reserva
                reserva.Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]);
                reserva.FechaIngreso = (DateTime)access.Lector["fechaIngreso"];
                reserva.FechaEgreso = (DateTime)access.Lector["fechaEgreso"];
                reserva.CantPersonas = (byte)access.Lector["cantidadPersonas"];
                reserva.FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"];
                reserva.Importe = (decimal)access.Lector["importe"];
                reserva.Estado = (byte)access.Lector["estado"];
                reserva.IdReservaOriginal = Convert.ToInt64(access.Lector["IDReservaOriginal"]);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return reserva;
        }

        public void ModificarEstadoReserva(Reserva reserva)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update Reservas set estado=@estado where Id=" + reserva.ID);
                access.AgregarParametro("@estado", reserva.Estado);
                access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
        }

        public void ModificarReserva(Reserva reserva)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update Reservas set fechaIngreso=@fechaIngreso, fechaEgreso=@fechaEgreso, cantidadPersonas=@cantidadPersonas, " +
                    "fechaReserva=@fechaReserva, importe=@importe, estado=@estado, IdReservaOriginal=@IdReservaOriginal where Id=@Id");
                access.AgregarParametro("@fechaIngreso", reserva.FechaIngreso);
                access.AgregarParametro("@fechaEgreso", reserva.FechaEgreso);
                access.AgregarParametro("@cantidadPersonas", reserva.CantPersonas);
                access.AgregarParametro("@fechaReserva", reserva.FechaCreacionReserva);
                access.AgregarParametro("@importe", reserva.Importe);
                access.AgregarParametro("@estado", reserva.Estado);
                access.AgregarParametro("@IdReservaOriginal", reserva.IdReservaOriginal);
                access.AgregarParametro("@Id", reserva.ID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
        }

    }
}


