using System;
using System.Collections.Generic;

class MaquinaExpendedora
{
    private static readonly Dictionary<int, (string, int)> Productos = new Dictionary<int, (string, int)>()
    {
        {1, ("Soda Coca Cola", 50)},
        {2, ("Soda Pepsi", 30)},
        {3, ("Chips", 20)},
        {4, ("Jugo", 60)},
        {5, ("Agua", 10)},
        {6, ("Chocolate", 80)},
        {7, ("Galletas", 40)},
        {8, ("Paleta", 25)},
        {9, ("Café", 70)},
        {10, ("Té", 35)}
    };

    private static readonly HashSet<int> MonedasValidas = new HashSet<int> { 5, 10, 50, 100, 200 };

    // Method to check if there is enough change available
    static bool TieneCambio(int cambio)
    {
        if (cambio == 0) return true;

        foreach (var moneda in MonedasValidas)
        {
            while (cambio >= moneda)
            {
                cambio -= moneda;
            }
        }

        return cambio == 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Productos en existencia:");
        foreach (var producto in Productos)
        {
            Console.WriteLine($"{producto.Key}: {producto.Value.Item1} ${producto.Value.Item2} ");
        }

        Console.WriteLine("Monedas/Billetes permitidos: 5, 10, 50, 100, 200:");
        Console.WriteLine("Ingrese las monedas/billetes que desea ingresar separados por espacios:");
        
        string[] entradaMonedas = Console.ReadLine().Trim().Split(' ');
        List<int> monedas = new List<int>();
        int totalDinero = 0;

        // Process each coin entered by the user
        foreach (var entrada in entradaMonedas)
        {
            if (int.TryParse(entrada, out int moneda) && MonedasValidas.Contains(moneda))
            {
                monedas.Add(moneda);
                totalDinero += moneda;
            }
            else
            {
                Console.WriteLine($"Moneda/Billete inválido: {entrada}, solo se aceptan de 5, 10, 50, 100 y 200.");
                return;
            }
        }

        Console.WriteLine($"Total de dinero ingresado: ${totalDinero}");

        Console.WriteLine("Ingrese el número del producto que va a querer");
        if (!int.TryParse(Console.ReadLine().Trim(), out int numeroProducto) || !Productos.ContainsKey(numeroProducto))
        {
            Console.WriteLine("El producto no es válido, se devolverán las monedas.");
            return;
        }

        var productoSeleccionado = Productos[numeroProducto];
        if (totalDinero < productoSeleccionado.Item2)
        {
            Console.WriteLine($"Dinero insuficiente para el producto {productoSeleccionado.Item1}, se devolverán las monedas.");
            return;
        }

        int cambio = totalDinero - productoSeleccionado.Item2;
        if (!TieneCambio(cambio))
        {
            Console.WriteLine("No hay cambio suficiente, se devolverán las monedas.");
            return;
        }

        Console.WriteLine($"Producto: {productoSeleccionado.Item1}");
        Console.WriteLine($"Cambio: ${cambio}");
    }
}
