class Funciones 
{
    public static bool comprobar_encabezado()
    {
        int puntos = 0;
        
        if (File.Exists("matrices.txt") == true)
        {
            using (StreamReader Sr = new StreamReader("matrices.txt"))
            {
            string line;
            for (int i = 1; i <= 9;i++)
            {
                line = Sr.ReadLine();
                if (line == null)
                {
                    puntos = puntos - 1;
                }
                else if (line.Length >= 2)
                {
                    if(line[0] == Convert.ToChar(i + '0') && line[1] == ';')
                    {
                        puntos = puntos + 1;
                    }
                    else
                    {
                        puntos = puntos - 1;
                    }
                }
                else
                {
                    puntos = puntos - 1;
                }
            }
            }
        }
        if (puntos == 9)
        {
            return true;
        }
        Excepciones.Lanzar_excepcion(0);
        return false;
        
        
    }
    public static void crear_archivo()
    {
        using (StreamWriter Sw = new StreamWriter("matrices.txt"))
        {
        Console.WriteLine("Se creo el archivo");
        for(int i = 1; i <= 9;i++)
        {
            Sw.WriteLine(i + ";0;");
        }
        }
    }
    public static void comprobar_indice_existencia()
    {
        int fila = 0;
            StreamReader Sr = new StreamReader("matrices.txt");
            for (int i = 0; i < 9 ; i++)
            {
                
                string line = Sr.ReadLine();
                if (line.Length < 4)
                {
                    Excepciones.Lanzar_excepcion(2);
                    Sr.Close();
                    fila = i;
                    escribir_lugar_especifico("",fila ,0);
                    break;
                }
                else if ((Convert.ToChar(line[2]) != Convert.ToChar("0") && Convert.ToChar(line[2]) != Convert.ToChar("1")) || Convert.ToChar(line[3]) != Convert.ToChar(";"))
                {
                    Excepciones.Lanzar_excepcion(2);
                    Sr.Close();
                    fila = i;
                    escribir_lugar_especifico("",fila ,0);
                    break;
                }
            }
    }
    public static void escribir_lugar_especifico(string texto_nuevo, int fila, int existencia)
    {
        string[] texto_antiguo = new string[9];
        using(StreamReader Sr = new StreamReader("matrices.txt"))
        {
            for (int i = 0; i < 9; i++)
            {
                texto_antiguo[i] = Sr.ReadLine();
            }
            if (fila > 0 || fila < 10)
            {
                texto_antiguo[fila] = (fila + 1) + ";" + existencia + ";" + texto_nuevo;
            }
        }
        using(StreamWriter Sw = new StreamWriter("matrices.txt"))
        {
            for(int i = 0; i < 9; i++)
            {
                Sw.WriteLine(texto_antiguo[i]);
            }
        }
    }
    public static void imprimir_texto()
    {
        using (StreamReader Sr = new StreamReader("matrices.txt"))
        {
            string[] texto = new string[9];
            string line;
            for (int i = 0;i < 9;i++)
            {
                line = Sr.ReadLine();
                Console.WriteLine(line);   
            }
        }
    }
    public static int[,] crear_matriz_temporal()
    {
        bool conversion;
        Console.WriteLine("Ingresa la cantidad de columnas");
        conversion = Int32.TryParse(Console.ReadLine(), out int columnas);
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(3);
            Excepciones.Lanzar_excepcion(4);
            return null;
        }
        Console.WriteLine("Ingresa la cantidad de filas");
        conversion = Int32.TryParse(Console.ReadLine(), out int filas);
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(3);
            Excepciones.Lanzar_excepcion(4);
            return null;
        }
        
        if ((filas > 1) && (columnas > 1))
        {
            Console.WriteLine("Para ingresar cualquier valor debe ir unicamente el valor numerico");
            int[,] matriz = new int[columnas, filas];
            for (int i = 0; i <= columnas-1; i++)
            {
                for (int j = 0; j <= filas-1; j++)
                {
                    Console.WriteLine("Ingresa el valor de la columna: " + (i+1) + " y fila: " + (j+1));
                    conversion = Int32.TryParse(Console.ReadLine(), out int numero);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        Excepciones.Lanzar_excepcion(4);
                        return null;
                    }
                    
                    matriz[i, j] = numero;

                }
            }
            
            return matriz;
        }
        Excepciones.Lanzar_excepcion(3);
        Excepciones.Lanzar_excepcion(4);
        return null;
    }
    public static int[,] guardar_matriz_temporal_programa(int[,] matriz_a_guardar, int matriz_en_la_que_guardar)
    {
        switch (matriz_en_la_que_guardar)
        {
            case 1:
                int[,] matriz_temporal_1 = matriz_a_guardar;
                return matriz_temporal_1;
            case 2:
                int[,] matriz_temporal_2 = matriz_a_guardar;
                return matriz_temporal_2;
            case 3:
                int[,] matriz_temporal_3 = matriz_a_guardar;
                return matriz_temporal_3;
            case 4:
                int[,] matriz_temporal_4 = matriz_a_guardar;
                return matriz_temporal_4;
            case 5:
                int[,] matriz_temporal_5 = matriz_a_guardar;
                return matriz_temporal_5;
            case 6:
                int[,] matriz_temporal_6 = matriz_a_guardar;
                return matriz_temporal_6;
            case 7:
                int[,] matriz_temporal_7 = matriz_a_guardar;
                return matriz_temporal_7;
            case 8:
                int[,] matriz_temporal_8 = matriz_a_guardar;
                return matriz_temporal_8;
            case 9:
                int[,] matriz_temporal_9 = matriz_a_guardar;
                return matriz_temporal_9;
            default:
                Excepciones.Lanzar_excepcion(3);
                return null;
        }

    }
}
