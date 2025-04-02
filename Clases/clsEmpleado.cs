using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace proyecto.Clases
{
	public class clsEmpleado
	{
		private DBSuperEntities2 dbSuper = new DBSuperEntities2(); // Es el atributo (propiedad) para gestionar la conexion a la base de datos

		public EMPLeado empleado { get; set; } //Propiedad para manipular la informacion en la base de datos: Permite agregar, modificar o eliminar
		public string Insertar()
		{
			try

			{
				dbSuper.EMPLeadoes.Add(empleado); //Agrega el objeto empleado a la lista de "empleadoes". Todavia no se agrega a la base de datos. Se debe invocar el metodo savechange
				dbSuper.SaveChanges(); //Guardar los cambios en la base de datos
				return "Empleado insertado correctamente";
			}
			catch(Exception ex)
			{
				return "Error al insertar el empleado: " + ex.Message;
			}
		}
		public string Actualizar()
		{
			try
			{
                //Antes de actualizar un elemento, se debe consultar para verificar que exista, y ahi si poderlo actualizar
                EMPLeado empl = Consultar(empleado.Documento);
                if (empl == null)
                {
                    return "El empleado con el documento ingresado no existe";
                }
                //El empleado existe lo podemos actualizar
                dbSuper.EMPLeadoes.AddOrUpdate(empleado); //Actualizar el objeto empleado en la lista de "empleadoes". Todavia no se actualiza en la base de datos.
                dbSuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se actualizo el empleado correctamente";
            }
			catch(Exception ex)
			{
				return "No se pudo actualizar el empleado";
			}
			
		}
		public List<EMPLeado> ConsultarTodos()
        {
            return dbSuper.EMPLeadoes
				.OrderBy(e => e.PrimerApellido)//Ordenar la lista de empleados por el primer apellido
                .ToList(); //Convertir la lista de empleados a una lista
        }
        public EMPLeado Consultar(string Documento)
		{
			//Expresiones lambda. => permite definir funciones anonimas o instancias de objetos, sin la creacion formal, dependiendo de la lista a la cual se hace referencia
			//FirsOrDefault. Es una funcion que permite consultar el primer elemento de una lista que cumple las condiciones solicitadas.
			return dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == Documento);

		}
		public string Eliminar()
		{
			try
			{
                //Antes de eliminar se debe verificar si el empleado existe
                EMPLeado empl = Consultar(empleado.Documento);
                if (empl == null)
                {
                    return "El empleado no existe";
                }
                //El empleado existe lo podemos eliminar. Se elimina el objeto empleado que se busca, no el que se envia como parametro.
                dbSuper.EMPLeadoes.Remove(empl); //Eliminar el objeto empleado de la lista de "empleadoes." Todavia no se elimina de la base de datos. 
                dbSuper.SaveChanges(); //Guardar los cambios en la base de datos.
                return "Se elimino el empleado correctamente";
            }
			catch (Exception ex)
			{
                return "No se pudo eliminar el empleado";
            }

        }

		public string Eliminar(string Documento)
		{
            try
            {
                //Antes de eliminar se debe verificar si el empleado existe
                EMPLeado empl = Consultar(Documento);
                if (empl == null)
                {
                    return "El empleado no existe";
                }
                //El empleado existe lo podemos eliminar. Se elimina el objeto empleado que se busca, no el que se envia como parametro.
                dbSuper.EMPLeadoes.Remove(empl); //Eliminar el objeto empleado de la lista de "empleadoes." Todavia no se elimina de la base de datos. 
                dbSuper.SaveChanges(); //Guardar los cambios en la base de datos.
                return "Se elimino el empleado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el empleado";
            }
        }

	}
}