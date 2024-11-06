class Proyecto
{
    static void Main()
    {
        int[,] matriz_temporal_1 = null;
        int[,] matriz_temporal_2 = null;
        int[,] matriz_temporal_3 = null;
        int[,] matriz_temporal_4 = null;
        int[,] matriz_temporal_5 = null;
        int[,] matriz_temporal_6 = null;
        int[,] matriz_temporal_7 = null;
        int[,] matriz_temporal_8 = null;
        int[,] matriz_temporal_9 = null;
        if (Funciones.comprobar_encabezado() == false)
        {
            Funciones.crear_archivo();
        }
        while (true) 
        {
            Console.WriteLine("1:Comprobar estado del archivo \n2:Imprimir datos del archivo \n3:Escribir en el archivo \n4:Crear Archivo nuevo \n5:Crear matriz \n6:Imprimir matrices temporal");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion) 
            { 
                case 1:
                    if (Funciones.comprobar_encabezado() == false)
                    {
                        Funciones.crear_archivo();
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            Funciones.comprobar_indice_existencia();
                        }
                        Excepciones.Lanzar_bien(0);
                        Excepciones.Lanzar_bien(1);
                        Excepciones.Lanzar_bien(2);
                        Excepciones.Lanzar_bien(100);
                    }
                    break;
                case 2:
                    Funciones.imprimir_texto();
                    break;
                case 3:
                    Console.WriteLine("!La forma de escribir es estricta, primero se pone el texto que quieres ingresar, luego la fila en que de debe poner(1-9), luego se pone el valor de existencia, debe ser 1 o 0¡");
                    string texto = Console.ReadLine();
                    int fila = Convert.ToInt32(Console.ReadLine());
                    int existencia = Convert.ToInt32(Console.ReadLine());
                    Funciones.escribir_lugar_especifico(texto,fila-1,existencia);
                    break;
                case 4:
                    Funciones.crear_archivo();
                    break;
                case 5:
                    Console.WriteLine("En que posicion de matriz temporal se va a guardar? (1-9)");
                    bool conversion = Int32.TryParse(Console.ReadLine(), out int posicion);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    switch (posicion)
                    {
                        case 1:
                            matriz_temporal_1 = Funciones.crear_matriz_temporal();
                            break;
                        case 2:
                            matriz_temporal_2 = Funciones.crear_matriz_temporal();
                            break;
                        case 3:
                            matriz_temporal_3 = Funciones.crear_matriz_temporal();
                            break;
                        case 4:
                            matriz_temporal_4 = Funciones.crear_matriz_temporal();
                            break;
                        case 5:
                            matriz_temporal_5 = Funciones.crear_matriz_temporal();
                            break;
                        case 6:
                            matriz_temporal_6 = Funciones.crear_matriz_temporal();
                            break;
                        case 7:
                            matriz_temporal_7 = Funciones.crear_matriz_temporal();
                            break;
                        case 8:
                            matriz_temporal_8 = Funciones.crear_matriz_temporal();
                            break;
                        case 9:
                            matriz_temporal_9 = Funciones.crear_matriz_temporal();
                            break;
                        default:
                            Excepciones.Lanzar_excepcion(3);
                            break;
                    }
                    break;
                case 6:
                    Console.WriteLine("Que posicion quieres mostrar? (1-9)");
                    bool conversion6 = Int32.TryParse(Console.ReadLine(), out int posicion6);
                    if (conversion6 == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    switch (posicion6)
                    {
                        case 1:
                            if (matriz_temporal_1 != null)
                            {
                                for (int i = 0; i < matriz_temporal_1.GetLength(0); i++)
                                {
                                    for (int j = 0; i < matriz_temporal_1.GetLength(1); j++)
                                    {
                                        Console.WriteLine(matriz_temporal_1[i, j]);
                                    }
                                }
                            }

                            Console.WriteLine(matriz_temporal_2);
                            break;
                        case 2:
                            matriz_temporal_2 = Funciones.crear_matriz_temporal();
                            break;
                        case 3:
                            matriz_temporal_3 = Funciones.crear_matriz_temporal();
                            break;
                        case 4:
                            matriz_temporal_4 = Funciones.crear_matriz_temporal();
                            break;
                        case 5:
                            matriz_temporal_5 = Funciones.crear_matriz_temporal();
                            break;
                        case 6:
                            matriz_temporal_6 = Funciones.crear_matriz_temporal();
                            break;
                        case 7:
                            matriz_temporal_7 = Funciones.crear_matriz_temporal();
                            break;
                        case 8:
                            matriz_temporal_8 = Funciones.crear_matriz_temporal();
                            break;
                        case 9:
                            matriz_temporal_9 = Funciones.crear_matriz_temporal();
                            break;
                        default:
                            Excepciones.Lanzar_excepcion(3);
                            break;
                    }
                    break;
                default:
                    break;
                    
            }
        }

    }
}
