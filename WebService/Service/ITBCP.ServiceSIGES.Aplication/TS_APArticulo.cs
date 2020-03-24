using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APArticulo: ITS_AIArticulo
    {
        private readonly ITS_DOArticulo _ITS_DOArticulo;

        public TS_APArticulo(ITS_DOArticulo ITS_DOArticulo)
        {
            _ITS_DOArticulo = ITS_DOArticulo;
        }

        public List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE(string cdgrupo02)
        {
            List<TS_BEArticulo> output = new List<TS_BEArticulo>();
            try
            {
                output = _ITS_DOArticulo.SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE(cdgrupo02);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEArticulo ObtenerArticulByCodigo(string cdarticulo)
        {
            TS_BEArticulo output = new TS_BEArticulo();
            try            {
                output = _ITS_DOArticulo.ObtenerArticulByCodigo(cdarticulo);
                if(string.IsNullOrEmpty(output.cdarticulo))
                {
                    output.Ok = false;
                    output.Mensaje = "Articulo no se encuentra en la base de datos";
                    
                }
                else{
                    output.Ok = true;
                    output.Mensaje = "Articulo recuperado correctamente";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
       
        public TS_BEArticuloOutput SP_ITBCP_LISTAR_ARTICULO(string cdgrupo02)
        {
            TS_BEArticuloOutput output = new TS_BEArticuloOutput();
            try
            {
                if (string.IsNullOrEmpty(cdgrupo02))
                {
                    output.Ok = false;
                    output.Mensaje = "El grupo de articulos no puede ser vacio";
                    return output;
                }

                output.Articulos = _ITS_DOArticulo.SP_ITBCP_LISTAR_ARTICULO(cdgrupo02);
                if (output.Articulos.Count > 0)
                {
                    output.Ok = false;
                    output.Mensaje = "No Existe Articulos para Tienda";
                    
                }
                else
                {
                    output.Ok = true;
                    output.Mensaje = "Articulo recuperado correctamente";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
        
        public TS_BEArticuloOutput SP_ITBCP_LISTAR_ARTICULOS(string cdgrupo02)
        {
            TS_BEArticuloOutput output = new TS_BEArticuloOutput();
            try
            {
                if (string.IsNullOrEmpty(cdgrupo02))
                {
                    output.Ok = false;
                    output.Mensaje = "El grupo de articulos no puede ser vacio";
                    return output;
                }

                output.Articulos = _ITS_DOArticulo.SP_ITBCP_LISTAR_ARTICULOS(cdgrupo02);
                if (output.Articulos.Count <= 0)
                {
                    output.Ok = false;
                    output.Mensaje = "No Existe Articulos para Tienda";

                }
                else
                {
                    output.Ok = true;
                    output.Mensaje = "Articulo recuperado correctamente";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BEArticuloOutput ListarArticuloPrecios(string glosa)
        {
            TS_BEArticuloOutput output = new TS_BEArticuloOutput();
            try
            {
                output.Articulos = _ITS_DOArticulo.ListarArticuloPrecios(glosa);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

    }
}
