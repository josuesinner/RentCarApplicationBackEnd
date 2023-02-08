using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.View
{
    public class Renta_DevolucionViewModel
    {
        [Key]
        public int No_Renta { get; set; }
        public string Empleado { get; set; }
        public string Vehiculo { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha_Renta { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
        public string Monto_Dia { get; set; }
        public int Cantidad_dias { get; set; }
        public string Comentario { get; set; }
        public bool Devolucion { get; set; }
        public bool Estado { get; set; }
    }
}
