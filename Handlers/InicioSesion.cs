using PreEntregaCoderHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreEntregaCoderHouse.Handlers
{
    public class InicioSesion
    {
        public static Usuario InicioDeSesion(string nombreUsu, string contra)
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
                cmd.CommandText = "SELECT * FROM usuario where NombreUsuario = @nombreUsu AND Contraseña = @contra";

                var paramNombreUsu = new SqlParameter("nombreUsu", System.Data.SqlDbType.VarChar);
                paramNombreUsu.Value = nombreUsu;

                var paramContra = new SqlParameter("contra", System.Data.SqlDbType.VarChar);
                paramContra.Value = contra;

                cmd.Parameters.Add(paramNombreUsu);
                cmd.Parameters.Add(paramContra);

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
