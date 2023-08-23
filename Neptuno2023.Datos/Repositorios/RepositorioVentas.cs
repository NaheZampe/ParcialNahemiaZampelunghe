using Neptuno2023.Comun.Interfases;
using Neptuno2023.Entidades.ListDto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuno2023.Datos.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
		private readonly string CadenaConexion;
        public RepositorioVentas()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public List<VentasListDto> GetVentas()
        {
			try
			{
				List<VentasListDto> lista=new List<VentasListDto>();
				using (var conn = new SqlConnection(CadenaConexion))
				{
					conn.Open();
					String SelectQuery = @"select Cl.NombreCliente ,V.FechaVenta, V.VentaId from Ventas V
										INNER JOIN Clientes Cl on Cl.ClienteId=V.ClienteId
										ORDER BY V.VentaId";
					using (var cmd=new SqlCommand(SelectQuery,conn))
					{
						using (var reader=cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								var venta = ConstruirVenta(reader);
								lista.Add(venta);
							}
						}
					}

                }
				return lista;
			}
			catch (Exception)
			{

				throw;
			}
        }

        private VentasListDto ConstruirVenta(SqlDataReader reader)
        {
			return new VentasListDto()
			{
				Cliente = reader.GetString(0),
				FechaCompra = reader.GetString(1)
			};
        }
    }
}
