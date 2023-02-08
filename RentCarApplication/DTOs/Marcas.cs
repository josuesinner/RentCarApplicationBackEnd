using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Marcas
    {
        [Key]
        public int Id_Marca { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
