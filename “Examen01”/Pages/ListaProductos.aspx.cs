using _Examen01_.Data;
using System;
using System.Linq;
using System.Web.UI;

namespace _Examen01_
{
    /// <summary>
    /// Página que muestra la lista de productos almacenados en la base de datos.
    /// </summary>
    public partial class ListaProductos : Page
    {
        /// <summary>
        /// Evento que se ejecuta cuando la página se carga. Si no es un postback, carga los productos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Cargar los productos si la página no es un postback
                    CargarProductos();
                }
                catch (Exception ex)
                {
                    // Manejo de errores: loguear el error y notificar al usuario
                    // LogError(ex); // Método hipotético para registrar el error
                    Response.Write("<script>alert('Ocurrió un error al cargar la lista de productos.');</script>");
                }
            }
        }

        /// <summary>
        /// Método para cargar los productos desde la base de datos y enlazarlos al GridView.
        /// Incluye cálculos adicionales de costo total y estado basado en la cantidad.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                using (PV_Examen01Entities1 context = new PV_Examen01Entities1())
                {
                    // Obtener los productos desde el procedimiento almacenado
                    var productos = context.spConsultarTodosLosProductos().ToList();

                    // Crear una lista con los productos y los campos calculados (costo total y estado)
                    var productosConCalculos = productos.Select(p => new
                    {
                        p.idProducto,
                        p.nombre,
                        p.fechaRegistro,
                        p.cantidad,
                        p.precioUnitario,
                        // Cálculo del costo total
                        costoTotal = p.cantidad * p.precioUnitario,
                        // Determinar estado basado en la cantidad
                        estado = p.cantidad > 0 ? "Disponible" : "No disponible"
                    }).ToList();

                    // Enlazar los productos al GridView
                    gvProductos.DataSource = productosConCalculos;
                    gvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al cargar los productos
                // LogError(ex); // Método hipotético para registrar el error
                Response.Write("<script>alert('Error al cargar los productos.');</script>");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón "Nuevo producto".
        /// Redirige a la página para crear un nuevo producto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void BtnNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Redirigir a la página CrearProducto.aspx
                Response.Redirect("CrearProducto.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                // Manejo de errores al redirigir
                // LogError(ex); // Método hipotético para registrar el error
                Response.Write("<script>alert('Error al redirigir a la página de creación de productos.');</script>");
            }
        }
    }
}
