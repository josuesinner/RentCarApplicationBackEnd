using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.View
{
    public class VehiculoViewModel
    {
        [Key]
        public int Id_Vehiculo { get; set; }
        public string Descripcion { get; set; }
        public string No_Chasis { get; set; }
        public string No_Motor { get; set; }
        public string No_Placa { get; set; }
        public string Tipo_Vehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo_Combustible { get; set; }
        public bool Estado { get; set; }
    }
}
