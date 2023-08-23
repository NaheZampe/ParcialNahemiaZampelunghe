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
    public class ServicioVentas : IServicioVentas
    {
        private readonly IRepositorioVentas _repo;
        public ServicioVentas()
        {
            _repo = new RepositorioVentas();
        }
        public List<VentasListDto> GetVentas()
        {
			try
			{
				return _repo.GetVentas();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
