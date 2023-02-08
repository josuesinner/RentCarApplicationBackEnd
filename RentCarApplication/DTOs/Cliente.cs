using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string No_Tarjeta_CR { get; set; }
        public string Limite_Credito { get; set; }
        public string Tipo_Persona { get; set; }
        public bool Estado { get; set; }
    }
}
