//inicio programa
string[] palabras = { "GATO", "PERRO", "CASA", "ARBOL" };
char[,] tablero = GenerarTablero(palabras);

Console.WriteLine("¡Bienvenido al juego de búsqueda de palabras!");
MostrarTablero(tablero);
foreach (string palabra in palabras)
{
    Console.Write($"Ingresa la posición de la palabra '{palabra}' (fila, columna): ");
    string[] posicion = Console.ReadLine().Split(',');
    int fila = int.Parse(posicion[0]);
    int columna = int.Parse(posicion[1]);

    if (VerificarPalabra(tablero, palabra, fila, columna))
    {
        Console.WriteLine("¡Correcto!");
    }
    else
    {
        Console.WriteLine("Incorrecto. Intenta de nuevo.");
    }
}

static void ColocarPalabraEnTablero(char[,] tablero, string palabra, int fila, int columna, int direccion)
{
    int filaOffset = 0, columnaOffset = 0;

    switch (direccion)
    {
        case 0: // Horizontal derecha
            columnaOffset = 1;
            break;
        case 1: // Vertical abajo
            filaOffset = 1;
            break;
        case 2: // Diagonal derecha abajo
            filaOffset = 1;
            columnaOffset = 1;
            break;
            // ... (omitido por brevedad)
    }

    for (int i = 0; i < palabra.Length; i++)
    {
        tablero[fila, columna] = palabra[i];
        fila += filaOffset;
        columna += columnaOffset;
    }
}

static void MostrarTablero(char[,] tablero)
{
    int tamanio = tablero.GetLength(0);
    Console.WriteLine("   " + new string('-', tamanio * 2 + 1));
    for (int i = 0; i < tamanio; i++)
    {
        Console.Write($"{i + 1,2} "); // Mostrar el número de fila
        for (int j = 0; j < tamanio; j++)
        {
            Console.Write($"|{tablero[i, j]}");
        }
        Console.WriteLine("|");
    }
    Console.WriteLine("   " + new string('-', tamanio * 2 + 1));
    Console.WriteLine("    " + new string(' ', tamanio) + "Columnas");
}

static bool VerificarPalabra(char[,] tablero, string palabra, int fila, int columna)
{
    int tamanio = tablero.GetLength(0);
    int longitudPalabra = palabra.Length;

    // Verificar horizontal derecha
    if (columna + longitudPalabra <= tamanio)
    {
        string palabraEncontrada = "";
        for (int i = 0; i < longitudPalabra; i++)
        {
            palabraEncontrada += tablero[fila, columna + i];
        }
        if (palabraEncontrada == palabra)
        {
            return true;
        }
    }

    // Verificar otras direcciones (omitido por brevedad)

    return false;
}

Console.WriteLine("¡Felicidades! Has completado el juego.");
Console.ReadLine();

static char[,] GenerarTablero(string[] palabras)
{
    int tamanio = 10;
    char[,] tablero = new char[tamanio, tamanio];

    // Rellenar el tablero con caracteres aleatorios
    Random random = new Random();
    for (int i = 0; i < tamanio; i++)
    {
        for (int j = 0; j < tamanio; j++)
        {
            tablero[i, j] = (char)random.Next('A', 'Z' + 1);
        }
    }

    // Colocar las palabras en el tablero
    foreach (string palabra in palabras)
    {
        UbicarPalabra(tablero, palabra);
    }

    return tablero;
}

static void UbicarPalabra(char[,] tablero, string palabra)
{
    switch (palabra)
    {
        case "GATO":
            ColocarPalabraEnTablero(tablero, "GATO", 0, 0, 0); // Horizontal derecha desde (0,0)
            break;
        case "PERRO":
            ColocarPalabraEnTablero(tablero, "PERRO", 2, 0, 1); // Vertical abajo desde (2,0)
            break;
        case "CASA":
            ColocarPalabraEnTablero(tablero, "CASA", 4, 0, 2); // Diagonal derecha abajo desde (4,0)
            break;
        case "ARBOL":
            ColocarPalabraEnTablero(tablero, "ARBOL", 6, 0, 3); // Horizontal izquierda desde (6,0)
            break;
        default:
            // En caso de que haya más palabras, puedes manejarlas aquí
            break;
    }
}

static bool PuedeColocarPalabraEnTablero(char[,] tablero, string palabra, int fila, int columna, int direccion)
{
    int tamanio = tablero.GetLength(0);
    int filaOffset = 0, columnaOffset = 0;

    switch (direccion)
    {
        case 0: // Horizontal derecha
            columnaOffset = 1;
            break;
        case 1: // Vertical abajo
            filaOffset = 1;
            break;
        case 2: // Diagonal derecha abajo
            filaOffset = 1;
            columnaOffset = 1;
            break;
            // ... (omitido por brevedad)
    }

    int filaSiguiente = fila + filaOffset;
    int columnaSiguiente = columna + columnaOffset;

    for (int i = 0; i < palabra.Length; i++)
    {
        if (filaSiguiente >= tamanio && columnaSiguiente >= tamanio && tablero[filaSiguiente, columnaSiguiente] != '\0')
        {
            return false;
        }

        filaSiguiente += filaOffset;
        columnaSiguiente += columnaOffset;
    }

    return true;
}