//inicio del programa principal
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

Console.WriteLine("¡Felicidades! Has completado el juego.");
Console.ReadLine();

// funciones utilizadas en el programa principal
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
    int tamanio = tablero.GetLength(0);
    Random random = new Random();
    bool colocada = false;

    while (!colocada)
    {
        int fila = random.Next(tamanio);
        int columna = random.Next(tamanio);
        int direccion = random.Next(8); // 0: horizontal, 1: vertical, 2-7: diagonales

        if (PuedeColocarPalabra(tablero, palabra, fila, columna, direccion))
        {
            ColocarPalabraEnTablero(tablero, palabra, fila, columna, direccion);
            colocada = true;
        }
    }
}

static bool PuedeColocarPalabra(char[,] tablero, string palabra, int fila, int columna, int direccion)
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
        case 3: // Horizontal izquierda
            columnaOffset = -1;
            break;
        case 4: // Vertical arriba
            filaOffset = -1;
            break;
        case 5: // Diagonal izquierda arriba
            filaOffset = -1;
            columnaOffset = -1;
            break;
        case 6: // Diagonal izquierda abajo
            filaOffset = 1;
            columnaOffset = -1;
            break;
        case 7: // Diagonal derecha arriba
            filaOffset = -1;
            columnaOffset = 1;
            break;
    }

    int filaSiguiente = fila + filaOffset * (palabra.Length - 1);
    int columnaSiguiente = columna + columnaOffset * (palabra.Length - 1);

    if (filaSiguiente >= tamanio || columnaSiguiente >= tamanio)
    {
        return false;
    }

    for (int i = 0; i < palabra.Length; i++)
    {
        if (tablero[fila + filaOffset * i, columna + columnaOffset * i] != '\0')
        {
            return false;
        }
    }

    return true;
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
        case 3: // Horizontal izquierda
            columnaOffset = -1;
            break;
        case 4: // Vertical arriba
            filaOffset = -1;
            break;
        case 5: // Diagonal izquierda arriba
            filaOffset = -1;
            columnaOffset = -1;
            break;
        case 6: // Diagonal izquierda abajo
            filaOffset = 1;
            columnaOffset = -1;
            break;
        case 7: // Diagonal derecha arriba
            filaOffset = -1;
            columnaOffset = 1;
            break;
    }

    for (int i = 0; i < palabra.Length; i++)
    {
        tablero[fila + filaOffset * i, columna + columnaOffset * i] = palabra[i];
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