using PreEntregaCoderHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaCoderHouse.Handlers
{
    public class UsuarioHandler
    {
        public static Usuario TraerUsuario(string nombreUsuario)
        {
            Usuario usuario = new Usuario();

            SqlConnectionStringBuilder conecctionbuilder = new();
            conecctionbuilder.DataSource = "NIKITODEVSS1";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection conecction = new SqlConnection(cs))
            {
                conecction.Open();

                SqlCommand cmd = conecction.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario where NombreUsuario = @nombre";

                var paramNombre = new SqlParameter("nombre", System.Data.SqlDbType.VarChar);
                paramNombre.Value = nombreUsuario;

                cmd.Parameters.Add(paramNombre);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();

                return usuario;
            }
        }
    }
}
