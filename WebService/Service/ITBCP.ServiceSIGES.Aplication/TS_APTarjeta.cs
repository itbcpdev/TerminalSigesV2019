using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APTarjeta: ITS_AITarjeta
    {
        private readonly ITS_DOTarjeta  _ITS_DOTarjeta;
        private readonly ITS_AICliente _ITS_AICliente;
        public TS_APTarjeta(ITS_DOTarjeta ITS_DOTarjeta, ITS_AICliente ITS_AICliente)
        {
            _ITS_DOTarjeta = ITS_DOTarjeta;
            _ITS_AICliente = ITS_AICliente;
        }
        public List<TS_BETarjeta> Obtener_Tarjetas()
        {
            List<TS_BETarjeta> output = new List<TS_BETarjeta>();
            try
            {
                output = _ITS_DOTarjeta.Obtener_Tarjetas();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BETarjeta ObtenerTarjeta(TS_BETarjeta input)
        {
            TS_BETarjeta output = new TS_BETarjeta();
            try
            {
                output = _ITS_DOTarjeta.ObtenerTarjeta(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BERespuestaCanje VALIDAR_CANJE(List<TS_BEDetalleInput> cDetalle, TS_BEClienteInput cCliente)
        {
            if (String.IsNullOrEmpty(cCliente.tarjAfiliacion))
            {
                return new TS_BERespuestaCanje("El uso de una tarjeta de fidelización es obligatoria para este proceso",false);
            }

            List<TS_BEPTarjeta> prefijos = _ITS_AICliente.LISTA_TARJETA_PREFIJOS();
            TS_BEClienteOutput cClienteAfiliacion = null;

            if (prefijos.Count > 0)
            {
                int validate = 0;
                foreach (TS_BEPTarjeta prefijo in prefijos)
                {
                    if (cCliente.tarjAfiliacion.Length > prefijo.prefijo.Length)
                    {
                        if (cCliente.tarjAfiliacion.Substring(0, prefijo.prefijo.Length).Equals((prefijo.prefijo ?? "").Trim()))
                        {
                            cClienteAfiliacion = _ITS_AICliente.ObtenerClientebyTarjeta(new TS_BEClienteSearch() { NroTarjeta = cCliente.tarjAfiliacion });
                            if (cClienteAfiliacion.Ok == false)
                            {
                                return new TS_BERespuestaCanje(cClienteAfiliacion.Mensaje, false);
                            }
                            if (cClienteAfiliacion.baja)
                            {
                                return new TS_BERespuestaCanje("No se pueden procesar las ventas debido a que la tarjeta de acumulación de puntos esta dada de baja, por favor intente nuevamente realizar la venta sin la tarjeta asignada",false);
                                

                            }
                            if (cClienteAfiliacion.bloqueado)
                            {
                                return new TS_BERespuestaCanje("No se pueden procesar las ventas debido a que la tarjeta de acumulación de puntos esta bloqueada, por favor intente nuevamente realizar la venta sin la tarjeta asignada",false);
                            }
                            validate++;
                        }
                    }
                }
                if (validate == 0)
                {
                    return new TS_BERespuestaCanje("Se ha indicado un numero de tarjeta con un prefijo que no esta configurado actualmente, revise la configuración de los prefijos asignados", false);
                }
            }
            else if(prefijos.Count <= 0)
            {
                return new TS_BERespuestaCanje("Se ha indicado una tarjeta bonus en la transacción, pero debido a que no cuenta con prefijos no se puede procesar dicha venta, intente nuevamente la venta sin enviar la tarjeta bonus", false);
            }

            List<TS_BEArticulo> Articulos = new List<TS_BEArticulo>();

            foreach(TS_BEArticulo Item in _ITS_DOTarjeta.LISTAR_ARTICULOS_CANJE(tarjeta: (cClienteAfiliacion.tarjafiliacion ?? "").Trim()))
            {
                foreach(TS_BEDetalleInput Articulo in cDetalle)
                {
                    if((Item.cdarticulo ?? "").Trim().Equals((Articulo.cdarticulo ?? "").Trim()))
                    {
                        Item.cantidad = Articulo.cantidad;
                        Articulo.config = Item.config;
                        Articulo.valor_acumulado = Item.valor_acumulado;
                        Articulo.valor_puntos = Item.valor_puntos;
                        Articulos.Add(Item);
                    }
                }
            }

            if(Articulos.Count != cDetalle.Count)
            {
                return new TS_BERespuestaCanje("Los articulos expresados en el detalle no son válidos para realizar un canje", false);
            }

            decimal Puntos = 0;
            decimal ValorAcumulado = 0;

            foreach(TS_BEArticulo Item in Articulos)
            {
                Puntos += (Item.valor_puntos * Item.cantidad);
                ValorAcumulado += (Item.valor_acumulado * Item.cantidad); 
            }
            if(cClienteAfiliacion.puntos < Puntos)
            {
                return new TS_BERespuestaCanje("Para procesar el canje se necesitan : " + Puntos + " puntos\nY el cliente cuenta con: " + cClienteAfiliacion.puntos+" puntos",false);
            }
            if (cClienteAfiliacion.valoracumula < ValorAcumulado)
            {
                return new TS_BERespuestaCanje("Para procesar el canje se necesitan : " + ValorAcumulado + " acumulados\nY el cliente cuenta con: " + cClienteAfiliacion.valoracumula + " acumulados", false);
            }

            return new TS_BERespuestaCanje() { Mensaje = new TS_BEMensaje("",true), Puntos = Puntos, ValorAcumulado = ValorAcumulado};
        }

        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo)
        {
            if (String.IsNullOrEmpty(prefijo))
            {
                return new TS_BEArticuloOutput() { Mensaje = "El prefijo es obligatorio", Ok = false };
            }
            return _ITS_DOTarjeta.OBTENER_ARTICULOS_POR_PREFIJO(prefijo: prefijo);
        }

        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_TARJETA(string tarjeta)
        {
            if (String.IsNullOrEmpty(tarjeta))
            {
                return new TS_BEArticuloOutput() { Mensaje = "El prefijo es obligatorio", Ok = false };
            }
            return _ITS_DOTarjeta.OBTENER_ARTICULOS_POR_TARJETA(tarjeta: tarjeta);
        }

    }
}
