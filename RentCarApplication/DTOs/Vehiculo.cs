using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Vehiculo
    {
        [Key]
        public int Id_Vehiculo { get; set; }
        public string Descripcion { get; set; }
        public string No_Chasis { get; set; }
        public string No_Motor { get; set; }
        public string No_Placa { get; set; }
        public int Tipo_VehiculoId { get; set; }
        public Tipo_Vehiculo Tipo_Vehiculo { get; set; }
        public int MarcaId { get; set; }
        public Marcas Marca { get; set; }
        public int ModeloId { get; set; }
        public Modelos Modelo { get; set; }
        public int CombustibleId { get; set; }
        public Combustible Tipo_Combustible { get; set; }
        public bool Estado { get; set; }
    }
}
