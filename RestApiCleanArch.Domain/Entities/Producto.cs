namespace RestApiCleanArch.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public int IdReport { get; set; }
        public string Unidad { get; set; }
        public double Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public string IngredienteActivo { get; set; }
        public string Concentracion { get; set; }
        public string IntervaloSeguridad { get; set; }
        public virtual Reporte Reporte { get; set; }

    }
}