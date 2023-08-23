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
    public class RepositorioCompras : IRepositorioCompras
    {
        private readonly string CadenaConexion;
        public RepositorioCompras()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public List<ComprasDto> GetCompras()
        {
            try
            {
                List<ComprasDto> lista = new List<ComprasDto>();
                using (var conn = new SqlConnection(CadenaConexion))
                {
                    conn.Open();
                    var SelectQuery = @"  select C.CompraId, P.NombreProveedor, C.FechaCompra, C.Total from Compras C
                    INNER JOIN Proveedores P on P.ProveedorId=C.ProveedorId
                    ORDER BY C.CompraId";
                    using (var cmd = new SqlCommand(SelectQuery,conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var compra = ConstruirCompra(reader);
                                lista.Add(compra);
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

        private ComprasDto ConstruirCompra(SqlDataReader reader)
        {
            return new ComprasDto
            {
                CompraId = reader.GetInt32(0),
                proveedor = reader.GetString(1),
                FechaCompra = reader.GetDateTime(2),
                Total=reader.GetDecimal(3)
            };
        }
    }
}
