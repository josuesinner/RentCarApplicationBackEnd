using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Inspeccion
    {
        [Key]
        public int Id_Transaccion { get; set; }
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public string Cedula { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public bool Tiene_Ralladuras { get; set; }
        public string Cantidad_Combustible { get; set; }
        public bool Goma_respuesta { get; set; }
        public bool Tiene_Gato { get; set; }
        public bool Roturas_cristal { get; set; }
        public bool IzqFrontal { get; set; }
        public bool DerFrontal { get; set; }
        public bool IzqTrasera { get; set; }
        public bool DerTrasera { get; set; }
        public string Etc { get; set; }
        public DateTime Fecha { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public bool Estado { get; set; }
    }
}
