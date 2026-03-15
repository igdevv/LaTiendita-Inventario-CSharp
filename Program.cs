using System;

class Program
{
    static string[] nombres = new string[100];
    static double[] precios = new double[100];
    static int[] stock = new int[100];

    static int cantidadProductos = 0;

    static void Main()
    {
        int opcion;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarProducto();
                    break;

                case 2:
                    ListarProductos();
                    break;

                case 3:
                    ActualizarStock();
                    break;

                case 4:
                    EliminarProducto();
                    break;

                case 5:
                    GenerarFactura();
                    break;

                case 6:
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 6);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n====== LA TIENDITA ======");
        Console.WriteLine("1. Registrar producto");
        Console.WriteLine("2. Listar productos");
        Console.WriteLine("3. Actualizar stock");
        Console.WriteLine("4. Eliminar producto");
        Console.WriteLine("5. Generar factura");
        Console.WriteLine("6. Salir");
        Console.WriteLine("=========================");
    }

    static void RegistrarProducto()
    {
        Console.Write("Nombre del producto: ");
        nombres[cantidadProductos] = Console.ReadLine();

        Console.Write("Precio: ");
        precios[cantidadProductos] = Convert.ToDouble(Console.ReadLine());

        Console.Write("Cantidad en stock: ");
        stock[cantidadProductos] = Convert.ToInt32(Console.ReadLine());

        cantidadProductos++;

        Console.WriteLine("Producto registrado correctamente.");
    }

    static void ListarProductos()
    {
        Console.WriteLine("\n--- INVENTARIO ---");

        if (cantidadProductos == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.WriteLine($"{i + 1}. {nombres[i]} | Precio: {precios[i]} | Stock: {stock[i]}");
        }
    }

    static void ActualizarStock()
    {
        ListarProductos();

        Console.Write("Seleccione el número del producto: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < cantidadProductos)
        {
            Console.Write("Nuevo stock: ");
            stock[indice] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Stock actualizado.");
        }
        else
        {
            Console.WriteLine("Producto inválido.");
        }
    }

    static void EliminarProducto()
    {
        ListarProductos();

        Console.Write("Seleccione el producto a eliminar: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < cantidadProductos)
        {
            for (int i = indice; i < cantidadProductos - 1; i++)
            {
                nombres[i] = nombres[i + 1];
                precios[i] = precios[i + 1];
                stock[i] = stock[i + 1];
            }

            cantidadProductos--;

            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto inválido.");
        }
    }

    static void GenerarFactura()
    {
        double total = 0;
        string continuar = "s";

        Console.WriteLine("\n--- FACTURA ---");

        while (continuar.ToLower() == "s")
        {
            ListarProductos();

            Console.Write("Seleccione producto: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (indice < 0 || indice >= cantidadProductos)
            {
                Console.WriteLine("Producto inválido.");
                continue;
            }

            Console.Write("Cantidad: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());

            if (cantidad > stock[indice])
            {
                Console.WriteLine("Stock insuficiente.");
                continue;
            }

            double subtotal = cantidad * precios[indice];
            total += subtotal;

            stock[indice] -= cantidad;

            Console.WriteLine($"Subtotal: {subtotal}");

            Console.Write("¿Agregar otro producto? (s/n): ");
            continuar = Console.ReadLine();
        }

        Console.WriteLine($"\nTOTAL A PAGAR: {total}");
    }
}
