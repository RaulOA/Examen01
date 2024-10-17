namespace _Examen01_.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PV_Examen01Entities1 : DbContext
    {
        public PV_Examen01Entities1()
            : base("name=PV_Examen01Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<spConsultarTodosLosProductos_Result> spConsultarTodosLosProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarTodosLosProductos_Result>("spConsultarTodosLosProductos");
        }
    
        public virtual int spCrearProducto(string nombre, Nullable<int> cantidad, Nullable<decimal> precioUnitario, Nullable<System.DateTime> fechaRegistro)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            var precioUnitarioParameter = precioUnitario.HasValue ?
                new ObjectParameter("precioUnitario", precioUnitario) :
                new ObjectParameter("precioUnitario", typeof(decimal));
    
            var fechaRegistroParameter = fechaRegistro.HasValue ?
                new ObjectParameter("fechaRegistro", fechaRegistro) :
                new ObjectParameter("fechaRegistro", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrearProducto", nombreParameter, cantidadParameter, precioUnitarioParameter, fechaRegistroParameter);
        }
    }
}
