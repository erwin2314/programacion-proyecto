class Funciones 
{
    public static bool comprobar_archivo()
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
        return false;
        
        
    }
    public static void crear_archivo()
    {
        using (StreamWriter Sw = new StreamWriter("matrices.txt"))
        {
        Console.WriteLine("Se creo el archivo");
        for(int i = 1; i <= 9;i++)
        {
            Sw.WriteLine(i + ";");
        }
        }
    }
    public static int[,] crear_matriz()
    {
        bool conversion;
        Console.WriteLine("Ingresa la cantidad de columnas");
        conversion = Int32.TryParse(Console.ReadLine(), out int columnas);
        if (conversion == false)
        {
            return null;
        }
        Console.WriteLine("Ingresa la cantidad de filas");
        conversion = Int32.TryParse(Console.ReadLine(), out int filas);
        if (conversion == false)
        {
            return null;
        }
        int[,] matriz = new int[columnas,filas];
        return matriz;
    }
}