class Proyecto
{
    static void Main(string[] args)
    {
        int Salir = 0;
        int[,] matriz_temporal = null;
        if (Funciones.comprobar_encabezado() == false)
        {
            Funciones.crear_archivo();
        }
        while (Salir == 0)
        {
            Console.WriteLine("0:Salir \n1:Comprobar estado del archivo \n2:Imprimir datos del archivo \n3:Escribir en el archivo \n4:Crear Archivo nuevo \n5:Crear matriz \n6:Imprimir matrices temporal");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 0:
                    Salir = 1;
                    break;
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
                    Funciones.escribir_lugar_especifico(texto, (fila - 1).ToString(), existencia.ToString());
                    break;
                case 4:
                    Funciones.crear_archivo();
                    break;
                case 5:
                    Console.WriteLine("En que posicion del archivo se va a guardar? (1-9)");
                    bool conversion = Int32.TryParse(Console.ReadLine(), out int posicion);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    int[,] aux;
                    aux = Funciones.crear_matriz();
                    if (aux != null)
                    {
                        matriz_temporal = aux;
                        Funciones.guardar_matriz_archivo(matriz_temporal,(posicion-1).ToString());
                    }
                    Excepciones.Lanzar_excepcion(4);
                    break;
                case 6:
                    if (matriz_temporal != null)
                    {
                        Funciones.imprimir_matriz(matriz_temporal);
                    }
                    else
                    {
                        Console.WriteLine("No se hay ninguna matriz temporal");
                    }
                    break;
                case 100:
                    Excepciones.Lanzar_bien(100);
                    break;
                default:
                    Excepciones.Lanzar_excepcion(3);
                    break;

            }
        }

    }
}
