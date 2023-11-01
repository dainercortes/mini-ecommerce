using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    internal class TarjetaDTO
    {
        [Required(ErrorMessage = "Ingrese el nombre del titular")]
        public string? Titular {  get; set; }

        [Required(ErrorMessage = "Ingrese el número de la tarjeta")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de vigencia de la tarjeta")]
        public string? Vigencia { get; set; }

        [Required(ErrorMessage = "Ingrese el código de seguridad de la tarjeta")]
        public string? CVV { get; set; }
    }
}
