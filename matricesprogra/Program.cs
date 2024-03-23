int[,] matriz = new int[10, 10];
int opcion;

do
{
    Console.Clear();
    Console.WriteLine("Menú de opciones");
    Console.WriteLine("1. Llenar matriz con ceros");
    Console.WriteLine("2. Mostrar matriz");
    Console.WriteLine("3. Obtener valor de una posición");
    Console.WriteLine("4. Cambiar valor de una posición");
    Console.WriteLine("5. Salir");
    Console.Write("Ingrese una opción: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            LlenarMatrizConCeros(matriz);
            break;
        case 2:
            MostrarMatriz(matriz);
            Console.ReadKey();
            break;
        case 3:
            Console.Write("Ingrese la fila: ");
            int fila = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la columna: ");
            int columna = int.Parse(Console.ReadLine());
            Console.WriteLine("El valor en la posición [{0}, {1}] es: {2}", fila, columna, ObtenerValorPosicion(matriz, fila, columna));
            Console.ReadKey();
            break;
        case 4:
            Console.Write("Ingrese la fila: ");
            fila = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la columna: ");
            columna = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nuevo valor: ");
            int nuevoValor = int.Parse(Console.ReadLine());
            CambiarValorPosicion(matriz, fila, columna, nuevoValor);
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Intente nuevamente.");
            Console.ReadKey();
            break;
    }
} while (opcion != 5);


static void LlenarMatrizConCeros(int[,] matriz)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            matriz[i, j] = 0;
        }
    }
}

static void MostrarMatriz(int[,] matriz)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Console.Write("{0,3}", matriz[i, j]);
        }
        Console.WriteLine();
    }
}

static int ObtenerValorPosicion(int[,] matriz, int fila, int columna)
{
    if (fila >= 0 && fila < 10 && columna >= 0 && columna < 10)
    {
        return matriz[fila, columna];
    }
    else
    {
        Console.WriteLine("Posición fuera de rango.");
        return 0;
    }
}

static void CambiarValorPosicion(int[,] matriz, int fila, int columna, int nuevoValor)
{
    if (fila >= 0 && fila < 10 && columna >= 0 && columna < 10)
    {
        matriz[fila, columna] = nuevoValor;
    }
    else
    {
        Console.WriteLine("Posición fuera de rango.");
    }
}