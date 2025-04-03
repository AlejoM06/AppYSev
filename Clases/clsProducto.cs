using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace proyecto.Clases
{
	public class clsProducto
	{

		private DBSuperEntities2 dbSuper = new DBSuperEntities2(); // Es el atributo (propiedad) para gestionar la conexion a la base de datos
		public PRODucto producto { get; set; } //Propiedad para manipular la informacion en la base de datos: Permite agregar, modificar o eliminar
		
		public string Insertar()
        {
            try
            {
                dbSuper.PRODuctoes.Add(producto); //Agrega el objeto producto a la lista de "productos". Todavia no se agrega a la base de datos. Se debe invocar el metodo savechange
                dbSuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe";
                }
                dbSuper.PRODuctoes.AddOrUpdate(producto);
                dbSuper.SaveChanges();
                return "Producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el producto";
            }   

        }
        public PRODucto Consultar(int Codigo)
        {
            return dbSuper.PRODuctoes.FirstOrDefault(p => p.Codigo == Codigo);
        }
        public List<PRODucto> ConsultarTodos()
        {
            return dbSuper.PRODuctoes
                .OrderBy(p => p.Nombre)
                .ToList();
        }
        public List<PRODucto> ConsultarXTipoProducto(int CodTipoProducto)
        { 
        return dbSuper.PRODuctoes
            .Where(p => p.CodigoTipoProducto == CodTipoProducto)
            .OrderBy(p => p.Nombre)
            .ToList();
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar se debe verificar si el empleado existe
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El empleado no existe";
                }
                dbSuper.PRODuctoes.Remove(prod); 
                dbSuper.SaveChanges(); 
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el producto";
            }

        }
        public string Eliminar(int Codigo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El producto con el codigo ingresado no existe";
                }
                dbSuper.PRODuctoes.Remove(prod);
                dbSuper.SaveChanges();
                return "Producto eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el producto";
            }
        }


        public string ModificarEstado(int Codigo, bool Activo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El código del producto no existe en la Base de Datos";
                }
                prod.Activo = Activo;
                dbSuper.SaveChanges();
                if (Activo)
                {
                return "se activó correctamente el producto";
                }
                else
                {
                    return "se inactivó correctamente el producto";
                }
            }
            catch (Exception ex)
                {
                return "Hubo un error al modificar el estado del producto: + ex.Message";
                }
		}
        public string GrabarImagenProducto(int idProducto, List<string> Imagenes)
        {
            try
            {
                foreach (string imagen in Imagenes)
                {
                    ImagenesProducto imagenProducto = new ImagenesProducto();
                    imagenProducto.idProducto = idProducto;
                    imagenProducto.NombreImagen = imagen;
                    dbSuper.ImagenesProductoes.Add(imagenProducto);
                }
                dbSuper.SaveChanges();
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
