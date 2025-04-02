using Antlr.Runtime.Tree;
using proyecto.Clases;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace proyecto.Controllers
{
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PRODucto> ConsultarTodos()
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]

        public PRODucto Consultar(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(Codigo);
        }

        [HttpGet]
        [Route("ConsultarXTipoProducto")]
        public List<PRODucto> ConsultarXTipoProducto(int TipoProducto)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarXTipoProducto(TipoProducto);
        }

        [HttpPost]
        [Route("Insertar")] //Es el nombre del metodo que se va a invocar

        public string insertar([FromBody] PRODucto producto)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsProducto Producto = new clsProducto();
            //Se pasa la propiead Empleado al objeto de la clase clsEmpleado
            Producto.producto= producto;
            //Se omvpca el metodo insertar
            return Producto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();

        }
        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar(int Codigo)
        { 
            clsProducto Producto = new clsProducto();
            return Producto.ModificarEstado(Codigo, false);
        }
        [HttpPut]
        [Route("Activar")]
        public string Activar(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ModificarEstado(Codigo, true);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXCodigo")]
        public string EliminarXCodigo(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Eliminar(Codigo);
        }

    }
}