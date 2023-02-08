using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Tipo_Vehiculo
    {
        [Key]
        public int Id_Tipo_Vehiculo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
