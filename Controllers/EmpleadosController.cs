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
    [RoutePrefix("api/Empleados")]
    public class EmpleadosController : ApiController
    {
        //GET: Se utiliza para consultar informaciion, no se debe modificar en la base de datos
        //POST: Se utiliza para insertar informacion en la base de datos
        //PUT: Se utiliza para actualizar informacion en la base de datos
        //DELETE: Se utiliza para eliminar informacion en la base de datos
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<EMPLeado> ConsultarTodos()
        {
            //Se crea una instancia de la clase clsEmpleado
            clsEmpleado Empleado = new clsEmpleado();
            //Se invoca el metodo ConsultarTodos de la clase clsEmpleado
            return Empleado.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXDocumento")] //Es el nombre del metodo que se va a invocar
        public EMPLeado ConsultarXDocumento(string Documento)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsEmpleado Empleado = new clsEmpleado();
            //Se invoca el metodo Consultar de la clase clsEmpleado
            return Empleado.Consultar(Documento);
        }
        [HttpPost]
        [Route("Insertar")] //Es el nombre del metodo que se va a invocar

        public string insertar([FromBody] EMPLeado empleado)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsEmpleado Empleado = new clsEmpleado();
            //Se pasa la propiead Empleado al objeto de la clase clsEmpleado
            Empleado.empleado = empleado;
            //Se omvpca el metodo insertar
            return Empleado.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EMPLeado empleado)
        {
            //Se crea una instancia de la clase clsEmpleado
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Actualizar();

        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado();
            Empleado.empleado = empleado;
            return Empleado.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(string Documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Eliminar(Documento);
        }
    }
}