using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.ListDto
{
    public class VentasListDto
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public string FechaCompra { get; set; }
        public float Total { get; set; }
    }
}
