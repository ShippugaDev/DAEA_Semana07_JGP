using System;
using System.Windows;
using Negocio;
using Entidades;

namespace Lab07_JGP
{
    public partial class MainWindow : Window
    {

        private int idProductoSeleccionado = 0;
        private NProducto nProducto;

        public MainWindow()
        {
            InitializeComponent();

            nProducto = new NProducto();

            CargarProductos();
        }

        private void CargarProductos()
        {
            dgProductos.ItemsSource =
                nProducto.ListarProductos();
        }

        private void btnBuscar_Click(
            object sender,
            RoutedEventArgs e)
        {
            string nombre =
                txtBuscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                CargarProductos();
                return;
            }

            dgProductos.ItemsSource =
                nProducto.BuscarProductos(nombre);
        }
        private void btnMostrarTodos_Click(
            object sender,
            RoutedEventArgs e)
        {
            txtBuscar.Clear();

            CargarProductos();
        }

        private void btnGuardar_Click(
    object sender,
    RoutedEventArgs e)
        {
            try
            {
                Producto producto = new Producto
                {
                    NombreProducto =
                        txtNombre.Text.Trim(),

                    IdProveedor =
                        Convert.ToInt32(txtProveedor.Text),

                    IdCategoria =
                        Convert.ToInt32(txtCategoria.Text),

                    CantidadPorUnidad =
                        txtCantidad.Text.Trim(),

                    PrecioUnidad =
                        Convert.ToDecimal(txtPrecio.Text),

                    UnidadesEnExistencia =
                        Convert.ToInt16(txtExistencia.Text),

                    UnidadesEnPedido =
                        Convert.ToInt16(txtPedido.Text),

                    NivelNuevoPedido =
                        Convert.ToInt16(txtNivelPedido.Text),

                    Suspendido =
                        Convert.ToInt16(txtSuspendido.Text),

                    CategoriaProducto =
                        txtCategoriaProducto.Text.Trim()
                };

                int resultado =
                    nProducto.InsertarProducto(producto);

                if (resultado > 0)
                {
                    MessageBox.Show(
                        "Producto registrado correctamente.");

                    LimpiarCampos();

                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar:\n" +
                    ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtProveedor.Clear();
            txtCategoria.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            txtPedido.Clear();
            txtNivelPedido.Clear();
            txtSuspendido.Clear();
            txtCategoriaProducto.Clear();
            idProductoSeleccionado = 0;
            dgProductos.SelectedItem = null;
            txtNombre.Focus();

        }

        private void btnNuevo_Click(
    object sender,
    RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(
     object sender,
     RoutedEventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            try
            {
                Producto producto = new Producto
                {
                    IdProducto =
                        idProductoSeleccionado,

                    NombreProducto =
                        txtNombre.Text.Trim(),

                    IdProveedor =
                        Convert.ToInt32(txtProveedor.Text),

                    IdCategoria =
                        Convert.ToInt32(txtCategoria.Text),

                    CantidadPorUnidad =
                        txtCantidad.Text.Trim(),

                    PrecioUnidad =
                        Convert.ToDecimal(txtPrecio.Text),

                    UnidadesEnExistencia =
                        Convert.ToInt16(txtExistencia.Text),

                    UnidadesEnPedido =
                        Convert.ToInt16(txtPedido.Text),

                    NivelNuevoPedido =
                        Convert.ToInt16(txtNivelPedido.Text),

                    Suspendido =
                        Convert.ToInt16(txtSuspendido.Text),

                    CategoriaProducto =
                        txtCategoriaProducto.Text.Trim()
                };

                int resultado =
                    nProducto.ActualizarProducto(producto);

                if (resultado > 0)
                {
                    MessageBox.Show(
                        "Producto actualizado correctamente.");

                    LimpiarCampos();

                    idProductoSeleccionado = 0;

                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar:\n" +
                    ex.Message);
            }
        }

        private void btnEliminar_Click(
          object sender,
          RoutedEventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto.");

                return;
            }

            MessageBoxResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de eliminar este producto?",
                    "Confirmación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)
            {
                try
                {
                    int resultado =
                        nProducto.EliminarProducto(
                            idProductoSeleccionado);

                    if (resultado > 0)
                    {
                        MessageBox.Show(
                            "Producto eliminado correctamente.");

                        LimpiarCampos();

                        CargarProductos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al eliminar:\n" +
                        ex.Message);
                }
            }
        }

        private void dgProductos_SelectionChanged(
    object sender,
    System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Producto producto =
                dgProductos.SelectedItem as Producto;

            if (producto != null)
            {
                idProductoSeleccionado =
                    producto.IdProducto;

                txtNombre.Text =
                    producto.NombreProducto;

                txtProveedor.Text =
                    producto.IdProveedor.ToString();

                txtCategoria.Text =
                    producto.IdCategoria.ToString();

                txtCantidad.Text =
                    producto.CantidadPorUnidad;

                txtPrecio.Text =
                    producto.PrecioUnidad.ToString();

                txtExistencia.Text =
                    producto.UnidadesEnExistencia.ToString();

                txtPedido.Text =
                    producto.UnidadesEnPedido.ToString();

                txtNivelPedido.Text =
                    producto.NivelNuevoPedido.ToString();

                txtSuspendido.Text =
                    producto.Suspendido.ToString();

                txtCategoriaProducto.Text =
                    producto.CategoriaProducto;
            }
        }
    }
}