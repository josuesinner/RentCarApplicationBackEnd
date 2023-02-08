using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Renta_Devolucion
    {
        [Key]
        public int No_Renta { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha_Renta { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public string Monto_Dia { get; set; }
        public int Cantidad_dias { get; set; }
        public string Comentario { get; set; }
        public bool Devolucion { get; set; }
        public bool Estado { get; set; }
    }
}
