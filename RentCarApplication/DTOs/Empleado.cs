using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Empleado
    {
        [Key]
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Tanda_Labor { get; set; }
        public string Porciento_Comision { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public bool Estado { get; set; }
    }
}
