using System.ComponentModel.DataAnnotations;

namespace RentCarApplication.DTOs
{
    public class Modelos
    {
        [Key]
        public int Id_Modelo { get; set; }
        public int MarcaId { get; set; }
        public Marcas Marca { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
