using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaCoderHouse
{
    public class ProductoVenta
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public ProductoVenta()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
            IdVenta = 0;
        }

        public static List<ProductoVenta> TraerVentas(int idUsuario)
        {
            var listaProductoVenta = new List<ProductoVenta>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "NIKITODEVSS1";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection conecction = new SqlConnection(cs))
            {
                conecction.Open();
                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "SELECT pv.Id, pv.Stock ,pv.IdProducto ,pv.IdVenta FROM ProductoVendido pv INNER JOIN Producto p on pv.IdProducto = p.Id WHERE p.IdUsuario = @idUsu";

                var paramIdUsu = new SqlParameter("idUsu", System.Data.SqlDbType.Int);
                paramIdUsu.Value = idUsuario;

                cmd.Parameters.Add(paramIdUsu);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var prodven = new ProductoVenta();

                    prodven.Id = Convert.ToInt32(reader.GetValue(0));
                    prodven.Stock = Convert.ToInt32(reader.GetValue(1));
                    prodven.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    prodven.IdVenta = Convert.ToInt32(reader.GetValue(3));

                    listaProductoVenta.Add(prodven);
                }

                reader.Close();

                return listaProductoVenta;
            }
        }
        public static List<ProductoVenta> TraerProductoVendido(int idUsuario)
        {
            var listaProductoVenta = new List<ProductoVenta>();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "NIKITODEVSS1";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            List<Producto> productos = Producto.TraerProducto(idUsuario);

            foreach (Producto p in productos)
            {

                using (SqlConnection conecction = new SqlConnection(cs))
                {
                    conecction.Open();
                    SqlCommand cmd = conecction.CreateCommand();
                    cmd.CommandText = "SELECT * FROM ProductoVendido WHERE idProducto = @idProducto";

                    var paramIdProducto = new SqlParameter("idProducto", System.Data.SqlDbType.Int);
                    paramIdProducto.Value = p.Id;

                    cmd.Parameters.Add(paramIdProducto);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var prodven = new ProductoVenta();

                        prodven.Id = Convert.ToInt32(reader.GetValue(0));
                        prodven.Stock = Convert.ToInt32(reader.GetValue(1));
                        prodven.IdProducto = Convert.ToInt32(reader.GetValue(2));
                        prodven.IdVenta = Convert.ToInt32(reader.GetValue(3));

                        listaProductoVenta.Add(prodven);
                    }

                    reader.Close();
                }
            }

            return listaProductoVenta;
        }
    }
}