using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Entidades;

namespace Datos
{
    public class DProducto
    {
        private readonly Conexion conexion = new Conexion();

        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();

            using SqlConnection connection =
                conexion.ObtenerConexion();

            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    "sp_Productos_Listar",
                    connection);

            cmd.CommandType =
                CommandType.StoredProcedure;

            using SqlDataReader dr =
                cmd.ExecuteReader();

            while (dr.Read())
            {
                Producto producto = new Producto
                {
                    IdProducto =
                        Convert.ToInt32(dr["idproducto"]),

                    NombreProducto =
                        dr["nombreProducto"].ToString()
                        ?? string.Empty,

                    IdProveedor =
                        Convert.ToInt32(dr["idProveedor"]),

                    IdCategoria =
                        Convert.ToInt32(dr["idCategoria"]),

                    CantidadPorUnidad =
                        dr["cantidadPorUnidad"].ToString()
                        ?? string.Empty,

                    PrecioUnidad =
                        Convert.ToDecimal(dr["precioUnidad"]),

                    UnidadesEnExistencia =
                        Convert.ToInt16(dr["unidadesEnExistencia"]),

                    UnidadesEnPedido =
                        Convert.ToInt16(dr["unidadesEnPedido"]),

                    NivelNuevoPedido =
                        Convert.ToInt16(dr["nivelNuevoPedido"]),

                    Suspendido =
                        Convert.ToInt16(dr["suspendido"]),

                    CategoriaProducto =
                        dr["categoriaProducto"].ToString()
                        ?? string.Empty,

                    Eliminado =
                        Convert.ToBoolean(dr["Eliminado"])
                };

                lista.Add(producto);
            }

            return lista;
        }

        public List<Producto> BuscarProductos(string nombre)
        {
            List<Producto> lista = new List<Producto>();

            using SqlConnection connection =
                conexion.ObtenerConexion();

            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    "sp_Productos_Buscar",
                    connection);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            using SqlDataReader dr =
                cmd.ExecuteReader();

            while (dr.Read())
            {
                Producto producto = new Producto
                {
                    IdProducto =
                        Convert.ToInt32(dr["idproducto"]),

                    NombreProducto =
                        dr["nombreProducto"].ToString()
                        ?? string.Empty,

                    IdProveedor =
                        Convert.ToInt32(dr["idProveedor"]),

                    IdCategoria =
                        Convert.ToInt32(dr["idCategoria"]),

                    CantidadPorUnidad =
                        dr["cantidadPorUnidad"].ToString()
                        ?? string.Empty,

                    PrecioUnidad =
                        Convert.ToDecimal(dr["precioUnidad"]),

                    UnidadesEnExistencia =
                        Convert.ToInt16(dr["unidadesEnExistencia"]),

                    UnidadesEnPedido =
                        Convert.ToInt16(dr["unidadesEnPedido"]),

                    NivelNuevoPedido =
                        Convert.ToInt16(dr["nivelNuevoPedido"]),

                    Suspendido =
                        Convert.ToInt16(dr["suspendido"]),

                    CategoriaProducto =
                        dr["categoriaProducto"].ToString()
                        ?? string.Empty,

                    Eliminado =
                        Convert.ToBoolean(dr["Eliminado"])
                };

                lista.Add(producto);
            }

            return lista;
        }

        public int InsertarProducto(Producto producto)
        {
            using SqlConnection connection =
                conexion.ObtenerConexion();

            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    "sp_Productos_Insertar",
                    connection);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@nombreProducto",
                producto.NombreProducto);

            cmd.Parameters.AddWithValue(
                "@idProveedor",
                producto.IdProveedor);

            cmd.Parameters.AddWithValue(
                "@idCategoria",
                producto.IdCategoria);

            cmd.Parameters.AddWithValue(
                "@cantidadPorUnidad",
                producto.CantidadPorUnidad);

            cmd.Parameters.AddWithValue(
                "@precioUnidad",
                producto.PrecioUnidad);

            cmd.Parameters.AddWithValue(
                "@unidadesEnExistencia",
                producto.UnidadesEnExistencia);

            cmd.Parameters.AddWithValue(
                "@unidadesEnPedido",
                producto.UnidadesEnPedido);

            cmd.Parameters.AddWithValue(
                "@nivelNuevoPedido",
                producto.NivelNuevoPedido);

            cmd.Parameters.AddWithValue(
                "@suspendido",
                producto.Suspendido);

            cmd.Parameters.AddWithValue(
                "@categoriaProducto",
                producto.CategoriaProducto);

            return cmd.ExecuteNonQuery();
        }

        public int ActualizarProducto(Producto producto)
        {
            using SqlConnection connection =
                conexion.ObtenerConexion();

            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    "sp_Productos_Actualizar",
                    connection);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@idproducto",
                producto.IdProducto);

            cmd.Parameters.AddWithValue(
                "@nombreProducto",
                producto.NombreProducto);

            cmd.Parameters.AddWithValue(
                "@idProveedor",
                producto.IdProveedor);

            cmd.Parameters.AddWithValue(
                "@idCategoria",
                producto.IdCategoria);

            cmd.Parameters.AddWithValue(
                "@cantidadPorUnidad",
                producto.CantidadPorUnidad);

            cmd.Parameters.AddWithValue(
                "@precioUnidad",
                producto.PrecioUnidad);

            cmd.Parameters.AddWithValue(
                "@unidadesEnExistencia",
                producto.UnidadesEnExistencia);

            cmd.Parameters.AddWithValue(
                "@unidadesEnPedido",
                producto.UnidadesEnPedido);

            cmd.Parameters.AddWithValue(
                "@nivelNuevoPedido",
                producto.NivelNuevoPedido);

            cmd.Parameters.AddWithValue(
                "@suspendido",
                producto.Suspendido);

            cmd.Parameters.AddWithValue(
                "@categoriaProducto",
                producto.CategoriaProducto);

            return cmd.ExecuteNonQuery();
        }

        public int EliminarProducto(int idProducto)
        {
            using SqlConnection connection =
                conexion.ObtenerConexion();

            connection.Open();

            using SqlCommand cmd =
                new SqlCommand(
                    "sp_Productos_Eliminar",
                    connection);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@idproducto",
                idProducto);

            return cmd.ExecuteNonQuery();
        }


    }
}