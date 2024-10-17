using _Examen01_.Data;
using System;
using System.Web.UI;

namespace _Examen01_
{
    /// <summary>
    /// Página que permite crear un nuevo producto y almacenarlo en la base de datos.
    /// </summary>
    public partial class CrearProducto : Page
    {
        /// <summary>
        /// Evento que se ejecuta al cargar la página. 
        /// Puede ser utilizado para inicializar datos, aunque actualmente no realiza ninguna acción.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // No se necesita cargar datos específicos en este momento.
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón "Guardar". 
        /// Registra el nuevo producto en la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si los datos son correctos antes de proceder
                if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
                {
                    // Mostrar mensaje de alerta si los campos no están completos
                    Response.Write("<script>alert('Todos los campos son obligatorios.');</script>");
                    return;
                }

                // Obtener los datos ingresados en el formulario
                string nombre = txtNombreProducto.Text;
                int cantidad;
                decimal precioUnitario;

                // Validar que los valores de cantidad y precio sean correctos
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad < 0)
                {
                    Response.Write("<script>alert('Ingrese una cantidad válida.');</script>");
                    return;
                }

                if (!decimal.TryParse(txtPrecioUnitario.Text, out precioUnitario) || precioUnitario < 0)
                {
                    Response.Write("<script>alert('Ingrese un precio válido.');</script>");
                    return;
                }

                DateTime fechaRegistro = DateTime.Now;

                // Crear una instancia del contexto de la base de datos
                using (PV_Examen01Entities1 context = new PV_Examen01Entities1())
                {
                    // Ejecutar el procedimiento almacenado "spCrearProducto"
                    context.spCrearProducto(nombre, cantidad, precioUnitario, fechaRegistro);

                    // Redirigir a la página de éxito después de guardar
                    Response.Redirect("Mensaje.aspx", false);

                    // Finalizar la solicitud de manera ordenada
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error amigable en caso de fallo
                Response.Write("<script>alert('Ocurrió un error al intentar guardar el producto.');</script>");
                // LogError(ex); // Método hipotético para registrar el error en un log
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se hace clic en el botón "Cancelar". 
        /// Redirige al usuario de vuelta a la lista de productos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                // Redirigir a la página de lista de productos
                Response.Redirect("ListaProductos.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                // Manejo de errores al redirigir
                Response.Write("<script>alert('Error al redirigir a la lista de productos.');</script>");
                // LogError(ex); // Método hipotético para registrar el error
            }
        }
    }
}
