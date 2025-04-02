using proyecto.Clases;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace proyecto.Controllers
{
	[RoutePrefix("api/TipoProductos")]
    public class TipoProductosController
	{
		[HttpGet]
        [Route("ConsultarTodos")]
        public List<TIpoPRoducto> ConsultarTodos()
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            return clsTipoProducto.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public TIpoPRoducto Consultar(int Codigo)
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            return clsTipoProducto.Consultar(Codigo);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar(TIpoPRoducto tipoProducto)
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            clsTipoProducto.tipoProducto = tipoProducto;
            return clsTipoProducto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(TIpoPRoducto tipoProducto)
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            clsTipoProducto.tipoProducto = tipoProducto;
            return clsTipoProducto.Actualizar();
        }
        [HttpPut]
        [Route("Activar")]

        public string Activar(int Codigo)
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            return clsTipoProducto.ModificarActivo(Codigo, true);
        }
        [HttpPut]
        [Route("Desactivar")]

        public string Desactivar(int Codigo)
        {
            clsTipoProducto clsTipoProducto = new clsTipoProducto();
            return clsTipoProducto.ModificarActivo(Codigo, false);
        }

    }
}