using PreEntregaCoderHouse;

Console.WriteLine("Ingrese el nombre de usuario:");
string nombreUsu = Console.ReadLine();
Console.WriteLine("Ingrese la contraseña:");
string contra = Console.ReadLine();

Usuario.InicioDeSesion(nombreUsu, contra);


Console.WriteLine("Ingrese el Nombre del usuario");
nombreUsu = Console.ReadLine();

Usuario.TraerUsuario(nombreUsu);


Console.WriteLine("Ingrese el ID del usuario");
int idUsuario = Convert.ToInt32(Console.ReadLine());

Producto.TraerProducto(idUsuario);


Console.WriteLine("Ingrese el ID del usuario");
idUsuario = Convert.ToInt32(Console.ReadLine());

ProductoVenta.TraerVentas(idUsuario);


Console.WriteLine("Ingrese el ID del usuario");
idUsuario = Convert.ToInt32(Console.ReadLine());

ProductoVenta.TraerProductoVendido(idUsuario);






