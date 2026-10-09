using System.Collections.Generic;
using Datos;
using Entidades;

namespace Negocio
{
    public class NProducto
    {
        public List<Producto> ListarProductos()
        {
            DProducto dProducto =
                new DProducto();

            return dProducto.ListarProductos();
        }

        public List<Producto> BuscarProductos(string nombre)
        {
            DProducto dProducto =
                new DProducto();

            return dProducto.BuscarProductos(nombre);
        }

        public int InsertarProducto(Producto producto)
        {
            DProducto dProducto =
                new DProducto();

            return dProducto.InsertarProducto(producto);
        }

        public int ActualizarProducto(Producto producto)
        {
            DProducto dProducto =
                new DProducto();

            return dProducto.ActualizarProducto(producto);
        }

        public int EliminarProducto(int idProducto)
        {
            DProducto dProducto =
                new DProducto();

            return dProducto.EliminarProducto(idProducto);
        }
    }
}