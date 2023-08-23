using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Entidades.ListDto
{
    public class ComprasDto
    {
        public int CompraId { get; set; }
        public string proveedor { get; set;}
        public DateTime FechaCompra { get; set; }
        public Decimal Total { get; set; }
    }
}
