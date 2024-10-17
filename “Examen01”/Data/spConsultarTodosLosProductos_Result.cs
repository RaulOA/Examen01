namespace _Examen01_.Data
{
    using System;
    
    public partial class spConsultarTodosLosProductos_Result
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
    }
}
