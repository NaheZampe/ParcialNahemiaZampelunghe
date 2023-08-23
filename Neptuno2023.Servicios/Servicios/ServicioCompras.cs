using Neptuno2023.Comun.Interfases;
using Neptuno2023.Datos.Repositorios;
using Neptuno2023.Entidades.ListDto;
using Neptuno2023.Servicios.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Servicios.Servicios
{
    public class ServicioCompras : IServicioCompra
    {
		private readonly IRepositorioCompras _repo;
        public ServicioCompras()
        {
            _repo = new RepositorioCompras();
        }
        public List<ComprasDto> GetCompras()
        {
			try
			{
				return _repo.GetCompras();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
