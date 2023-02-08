using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Combustible
    {
        [Key]
        public int Id_Combustible { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
