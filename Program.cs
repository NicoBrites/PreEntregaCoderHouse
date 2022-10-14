using PreEntregaCoderHouse.Models;
using PreEntregaCoderHouse.Handlers;


Console.WriteLine("Ingrese el nombre de usuario:");
string nombreUsu = Console.ReadLine();
Console.WriteLine("Ingrese la contraseña:");
string contra = Console.ReadLine();

InicioSesion.InicioDeSesion(nombreUsu, contra);


Console.WriteLine("Ingrese el Nombre del usuario");
nombreUsu = Console.ReadLine();

UsuarioHandler.TraerUsuario(nombreUsu);


Console.WriteLine("Ingrese el ID del usuario");
int idUsuario = Convert.ToInt32(Console.ReadLine());

ProductoHandler.TraerProducto(idUsuario);


Console.WriteLine("Ingrese el ID del usuario");
idUsuario = Convert.ToInt32(Console.ReadLine());

ProductoVentaHandler.TraerProductoVendido(idUsuario);


Console.WriteLine("Ingrese el ID del usuario");
idUsuario = Convert.ToInt32(Console.ReadLine());

VentaHandler.TraerVentas(idUsuario);





