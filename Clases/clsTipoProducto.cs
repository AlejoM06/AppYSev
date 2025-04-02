using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto.Clases
{
	public class clsTipoProducto
	{
		private DBSuperEntities2 dbSuper = new DBSuperEntities2(); // Es el atributo (propiedad) para gestionar la conexion a la base de datos
		public TIpoPRoducto tipoProducto { get; set; } //Propiedad para manipular la informacion en la base de datos: Permite agregar, modificar o eliminar
		public List<TIpoPRoducto> ConsultarTodos()
		{
			return dbSuper.TIpoPRoductoes.ToList();
        }
		public TIpoPRoducto Consultar(int Codigo)
		{
            return dbSuper.TIpoPRoductoes.Where(x => x.Codigo == Codigo).FirstOrDefault();
        }
        public string Insertar()
		{
            try
            {
                dbSuper.TIpoPRoductoes.Add(tipoProducto); //Agrega el objeto tipoProducto a la lista de "tipoProductos". Todavia no se agrega a la base de datos. Se debe invocar el metodo savechange
                dbSuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Tipo de producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el tipo de producto: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                TIpoPRoducto tipoProd = Consultar(tipoProducto.Codigo);
                if (tipoProd == null)
                {
                    return "El tipo de producto con el codigo ingresado no existe";
                }
                tipoProd.Nombre = tipoProducto.Nombre;
                tipoProd.Activo = tipoProducto.Activo;
                dbSuper.SaveChanges();
                return "Tipo de producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el tipo de producto";
            }
        }
        public string ModificarActivo (int Codigo, bool Activo) {
            try
            {
                TIpoPRoducto tipoProd = Consultar(tipoProducto.Codigo);
                if (tipoProd == null)
                {
                    return "El tipo de producto con el codigo ingresado no existe";
                }
                tipoProd.Activo = tipoProducto.Activo;
                dbSuper.SaveChanges();
                if (Activo)
                {
                    return "Se activo el tipo de producto";
                }
                else
                {
                    return "Se desactivo el tipo de producto";
                }
                
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el tipo de producto";
            }

        }
    }
}