using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerPacialBlazor.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        [Required(ErrorMessage = "Es obligatorio introduccir una descripcion.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Es obligatorio introduccir una existencia.")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "Es obligatorio introduccir un costo.")]
        public double Costo { get; set; }
        public double ValorInventario { get; set; }
    }
}
