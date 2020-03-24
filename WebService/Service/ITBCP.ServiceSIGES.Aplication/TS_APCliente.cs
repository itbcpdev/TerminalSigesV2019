using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APCliente : ITS_AICliente
    {
        private readonly ITS_DOCliente _ITS_DOCliente;
        private readonly ITS_AIUtilities _ITS_AIUtilities;
        public TS_APCliente(ITS_DOCliente ITS_DOCliente, ITS_AIUtilities ITS_AIUtilities)
        {
            _ITS_DOCliente = ITS_DOCliente;
            _ITS_AIUtilities = ITS_AIUtilities;
        }
        public List<TS_BEClienteOutput> ListarClienteByCodigo(TS_BEClienteSearch input)
        {
            List<TS_BEClienteOutput> output = new List<TS_BEClienteOutput>();
            try
            {
                output = _ITS_DOCliente.ListarClienteByCodigo(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public  TS_BESaldoclic ObtenerSaldoClientebyCodigo(TS_BEClienteSearch input)
        {
            TS_BESaldoclic output = new TS_BESaldoclic();
            try
            {
                output = _ITS_DOCliente.ObtenerSaldoClientebyCodigo(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BESaldoclid> ListarSaldoClientTarjeta(TS_BEClienteSearch input)
        {
            List<TS_BESaldoclid> output = new List<TS_BESaldoclid>();
            try
            {
                output = _ITS_DOCliente.ListarSaldoClientTarjeta(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEClienteOutput ObtenerClienteByCodigo(TS_BEClienteSearch input)
        {
            
            TS_BEClienteOutput output = new TS_BEClienteOutput();
            try
            {   if (string.IsNullOrEmpty(input.Codigo))
                {
                    output.Ok = false;
                    output.Mensaje = "Codigo de no puede ser vacio";
                    return output;

                }

                List<TS_BEClienteOutput>  query = _ITS_DOCliente.ListarClienteByCodigo(input);
                if (query.Count > 0)
                {
                    output = query[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEClienteOutput ObtenerClientebyTarjeta(TS_BEClienteSearch input)
        {
            TS_BEClienteOutput output = new TS_BEClienteOutput();
            try
            {
                if (string.IsNullOrEmpty(input.NroTarjeta))
                {
                    output.Ok = false;
                    output.Mensaje = "Tarjeta no encontrada";
                    return output;

                }

                return _ITS_DOCliente.ObtenerClienteByTarjeta(input);
                
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BEClienteLista> ListarClientes()
        {
            List<TS_BEClienteLista> query = new List<TS_BEClienteLista>();
            TS_BEClienteLista output = new TS_BEClienteLista();
            try
            {
                query = _ITS_DOCliente.ListarClientes();

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return query;
        }

        public TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input)
        {

            TS_BESaldoclid output = new TS_BESaldoclid();
            try
            {
                 output = _ITS_DOCliente.ObtenerSaldoClientTarjeta(input);
               
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEGestionFlotaC ObtenerGestionFlotaC(TS_BEGestionFlotaC input)
        {
            TS_BEGestionFlotaC output = new TS_BEGestionFlotaC();
            try
            {
                output = _ITS_DOCliente.ObtenerGestionFlotaC(input);

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEGestionFlotaD ObtenerGestionFlotaD(TS_BEGestionFlotaD input)
        {
            TS_BEGestionFlotaD output = new TS_BEGestionFlotaD();
            try
            {
                output = _ITS_DOCliente.ObtenerGestionFlotaD(input);

            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEDepartamento> ListarDepartamentos()
        {
            List<TS_BEDepartamento> query = new List<TS_BEDepartamento>();
            TS_BEDepartamento output = new TS_BEDepartamento();
            try
            {
                query = _ITS_DOCliente.ListarDepartamentos();
           
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return query;
        }
        public TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO(TS_BEParametro parametro,string nrotarjeta)
        {
            if (String.IsNullOrEmpty(nrotarjeta))
            {
                return new TS_BEClienteCreditoOutput() { Mensaje = new TS_BEMensaje("La tarjeta del cliente no puede estar vacio", false) };
            }
            nrotarjeta = nrotarjeta.Trim();

            string creditoLocal = (parametro.prefcredlocal ?? "").Trim();
            string creditoCoorporativo = (parametro.prefcredcorp ?? "").Trim();

            if (nrotarjeta.Length > 2)
            {
                if (nrotarjeta.Substring(0, creditoLocal.Length).Equals(creditoLocal))
                {
                    return _ITS_DOCliente.OBTENER_CLIENTE_CREDITO_LOCAL(nrotarjeta);
                }
                if (nrotarjeta.Substring(0, creditoCoorporativo.Length).Equals(creditoCoorporativo))
                {
                    return _ITS_AIUtilities.OBTENER_CLIENTE_CREDITO_COORPORATIVO_WS(nrotarjeta);
                }
                else
                {
                    return new TS_BEClienteCreditoOutput() { Mensaje = new TS_BEMensaje("El prefijo no existe", false) };
                }
            }
            else
            {
                return new TS_BEClienteCreditoOutput() { Mensaje = new TS_BEMensaje("El codigo de el cliente es muy corto", false) };
            }
        }

        public List<TS_BEPTarjeta> LISTA_TARJETA_PREFIJOS()
        {
            try
            {
                return _ITS_DOCliente.LISTA_TARJETA_PREFIJOS();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BEClienteLista> ListarClientesByName(string rscliente)
        {
            if (String.IsNullOrEmpty(rscliente))
            {
                return new List<TS_BEClienteLista>();
            }
            try
            {
                return _ITS_DOCliente.ListarClientesByName(rscliente);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }
        public List<TS_BEClienteLista> ListarClientesByPlaca(string placa)
        {
            if (String.IsNullOrEmpty(placa))
            {
                return new List<TS_BEClienteLista>();
            }
            try
            {
                return _ITS_DOCliente.ListarClientesByPlaca(placa);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }
    }
}

