using PreEntregaCoderHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaCoderHouse.Handlers
{
    public class ProductoHandler
    {
        public static List<Producto> TraerProducto(int idUsuario)
        {
            var listaProductos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "NIKITODEVSS1";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection conecction = new SqlConnection(cs))
            {
                conecction.Open();
                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto where IdUsuario = @idUsu";

                var paramIdUsu = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                paramIdUsu.Value = idUsuario;

                cmd.Parameters.Add(paramIdUsu);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prod = new Producto();

                    prod.Id = Convert.ToInt32(reader.GetValue(0));
                    prod.Descripcion = reader.GetValue(1).ToString();
                    prod.Costo = Convert.ToInt32(reader.GetValue(2));
                    prod.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    prod.Stock = Convert.ToInt32(reader.GetValue(4));
                    prod.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(prod);
                }

                reader.Close();

                return listaProductos;
            }
        }

    }
}
