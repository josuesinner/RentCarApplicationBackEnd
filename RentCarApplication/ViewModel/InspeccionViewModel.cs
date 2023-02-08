using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.View
{
    public class InspeccionViewModel
    {
        [Key]
        public int Id_Transaccion { get; set; }
        public string Vehiculo { get; set; }
        public string Cedula { get; set; }
        public string Cliente { get; set; }
        public bool Tiene_Ralladuras { get; set; }
        public string Cantidad_Combustible { get; set; }
        public bool Goma_respuesta { get; set; }
        public bool Tiene_Gato { get; set; }
        public bool roturas_cristal { get; set; }
        public string Estado_gomas { get; set; }
        public string Etc { get; set; }
        public DateTime Fecha { get; set; }
        public string Empleado { get; set; }
        public bool Estado { get; set; }
    }
}
