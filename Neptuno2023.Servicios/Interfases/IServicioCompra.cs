using Neptuno2023.Entidades.ListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Interfases
{
    public interface IServicioCompra
    {
        List<ComprasDto> GetCompras();
    }
}
