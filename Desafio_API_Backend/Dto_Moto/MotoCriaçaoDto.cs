using System.ComponentModel.DataAnnotations;

namespace Desafio_API_Backend.Dto
{
    public class MotoCriaçaoDto
    {
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Placa { get; set; }
    }
}
