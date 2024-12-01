//Mas informacion del como se guardan las matrices en la parte de Excepciones en la funcion de Manual
class Proyecto
{
    static void Main(string[] args)
    {
        int Salir = 0;
        float[,] matriz_temporal = null;

        //comprueba que el archivo exista, si no existe lo crea
        //si existe el archivo comprueba el encabezado
        if (Funciones.comprobar_encabezado() == false)
        {
            Funciones.crear_archivo();
        }

        //Si en cualquier momento esta variable cambia se sale del programa
        while (Salir == 0)
        {
            //Imprime todo lo que se puede hacer
            Console.WriteLine("Cualquier letra o un 0:Salir \n1:Comprobar estado del archivo \n2:Imprimir datos del archivo \n3:Manual del archivo \n4:Crear Archivo nuevo \n5:Crear matriz \n6:Imprimir matriz especifica del archivo \n7:Eliminar matriz \n8:Sumar matrices \n9:Restar matrices \n10:Multiplicacion matrices \n11:Sacar determinante \n12:Sacar transposicion");
            bool conversion_opcion = Int32.TryParse(Console.ReadLine(),out int opcion);//convierte la entradad a entero
            if (conversion_opcion == false) //Si no se puede convertir a algun numero, se sale
            {
                Salir = 1;
            }
            switch (opcion)
            {
                case 0:
                    Salir = 1; //Sale del while
                    break;
                case 1:
                    //esta comprobacion es la misma que se hace al iniciar el programa
                    if (Funciones.comprobar_encabezado() == false)
                    {
                        Funciones.crear_archivo();
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)//comprueba los 9 valores de existencia
                        {
                            Funciones.comprobar_indice_existencia();
                        }
                        Console.WriteLine();
                        Excepciones.Lanzar_bien(0);
                        Excepciones.Lanzar_bien(1);
                        Excepciones.Lanzar_bien(2);
                        Excepciones.Lanzar_bien(100);
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    Console.WriteLine();
                    Funciones.imprimir_texto(); //Escribe toda la informacion del archivo de texto
                    Console.WriteLine();
                    break;
                case 3:
                    Excepciones.Manual();//Escribe el manual
                    break;
                case 4:
                    Funciones.crear_archivo();//No es muy complejo esta parte
                    break;
                case 5:
                    Console.WriteLine("En que posicion del archivo se va a guardar? (1-9)");//pide el lugar en el que se va a guardar
                    bool conversion = Int32.TryParse(Console.ReadLine(), out int posicion);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    float[,] aux;
                    aux = Funciones.crear_matriz();//Crea la matriz
                    if (aux != null)
                    {
                        matriz_temporal = aux;//No se porque no utilize aux directamente
                        Funciones.guardar_matriz_archivo(matriz_temporal,(posicion-1).ToString());
                    }
                    else 
                    {
                        Excepciones.Lanzar_excepcion(4);
                    }
                    
                    break;
                case 6:
                    Console.WriteLine("Cual posicion quieres ver?");
                    string opcion6 = Console.ReadLine() ;
                    bool conversion6 = Int32.TryParse(opcion6, out int fila6);//:u
                    if (conversion6 == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    fila6 = fila6 - 1;//siempre que el usuario ingrese el valor de una fila se le tiene que restar 1
                                      //ya sea afuera como aqui o directamente al momento de llamar una funcion que lo utilize
                    float[,] aux6;
                    try
                    {
                        aux6 = Funciones.leer_matriz_archivo(fila6.ToString());
                        Funciones.imprimir_matriz(aux6);
                    }
                    catch 
                    {
                        Excepciones.Lanzar_excepcion(7);
                    }
                    break;
                case 7:
                    Console.WriteLine("Ingresa la posicion que quieres vaciar");
                    string opcion7 = Console.ReadLine();//:V
                    Funciones.borrar_matriz(opcion7);
                    break;
                case 8:
                    //Todo lo de suma, resta y multiplicacion son lo mismo, solo cambia un poco lo que pone en consola
                    try
                    {
                        Console.WriteLine("Posicion de la primera matriz a sumar");
                        string posicion1 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion1, out int fila1);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion de la segunda matriz a sumar");
                        string posicion2 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion2, out int fila2);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion en la que quieres guardar el resultado");
                        string posicion3 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion3, out int fila3);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                        }
                        //No es tan malo como se ve
                        float[,] aux8 = Funciones.suma_matrices(Funciones.leer_matriz_archivo((fila1 - 1).ToString()), Funciones.leer_matriz_archivo((fila2 - 1).ToString()));
                        Funciones.guardar_matriz_archivo(aux8, (fila3 - 1).ToString());
                        Console.WriteLine("Resultado de la suma");
                        Funciones.imprimir_matriz(Funciones.leer_matriz_archivo((fila3 - 1).ToString()));
                    }
                    catch
                    {

                    }
                    break;
                case 9:
                    //Todo lo de suma, resta y multiplicacion son lo mismo, solo cambia un poco lo que pone en consola
                    try
                    {
                        Console.WriteLine("Posicion de la primera matriz a restar");
                        string posicion1 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion1, out int fila1);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion de la segunda matriz a restar");
                        string posicion2 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion2, out int fila2);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion en la que quieres guardar el resultado");
                        string posicion3 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion3, out int fila3);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                        }
                        float[,] aux9 = Funciones.resta_matrices(Funciones.leer_matriz_archivo((fila1 - 1).ToString()), Funciones.leer_matriz_archivo((fila2 - 1).ToString()));
                        Funciones.guardar_matriz_archivo(aux9, (fila3 - 1).ToString());
                        Console.WriteLine("Resultado de la resta");
                        Funciones.imprimir_matriz(Funciones.leer_matriz_archivo((fila3 - 1).ToString()));
                    }
                    catch
                    {

                    }
                    break;
                case 10:
                    //Todo lo de suma, resta y multiplicacion son lo mismo, solo cambia un poco lo que pone en consola
                    try
                    {
                        Console.WriteLine("Posicion de la primera matriz a multiplicar");
                        string posicion1 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion1, out int fila1);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion de la segunda matriz a multiplicar");
                        string posicion2 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion2, out int fila2);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                            break;
                        }
                        Console.WriteLine("Posicion en la que quieres guardar el resultado");
                        string posicion3 = Console.ReadLine();
                        conversion = Int32.TryParse(posicion3, out int fila3);
                        if (conversion == false)
                        {
                            Excepciones.Lanzar_excepcion(3);
                        }
                        float[,] aux10 = Funciones.multiplicacion_matrices(Funciones.leer_matriz_archivo((fila1 - 1).ToString()), Funciones.leer_matriz_archivo((fila2 - 1).ToString()));
                        Funciones.guardar_matriz_archivo(aux10, (fila3 - 1).ToString());
                        Console.WriteLine("Resultado de la multiplicacion");
                        Funciones.imprimir_matriz(aux10);
                    }
                    catch
                    {

                    }
                    break;
                case 11:
                    Console.WriteLine("De cual matriz quiere sacar la determinante? (1-9) La matriz debe de ser 2x2 o 3x3");
                    conversion = Int32.TryParse(Console.ReadLine(), out int aux11);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    aux11 = aux11 - 1;
                    float determinante;
                    determinante = Funciones.determinante_matriz(Funciones.leer_matriz_archivo(aux11.ToString()));
                    Console.WriteLine("La determinante es: " + determinante);
                    Console.WriteLine("Donde se va a guardar? (1-9)");
                    conversion = Int32.TryParse(Console.ReadLine(), out int fila11);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    Funciones.guardar_determinante(determinante,(fila11 - 1).ToString());
                    break;
                case 12:
                    Console.WriteLine("Cual matriz quieres transposicionar? (1-9)");
                    conversion = Int32.TryParse(Console.ReadLine(), out int posicion12);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    float[,] auxD;
                    auxD = Funciones.trasposicion(Funciones.leer_matriz_archivo((posicion12 - 1).ToString()));
                    Console.WriteLine("La matriz transposicionada es: ");
                    Funciones.imprimir_matriz(auxD);
                    Console.WriteLine("En que posicion se va a guardar?");
                    conversion = Int32.TryParse(Console.ReadLine(), out int posicion12G);
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        break;
                    }
                    Funciones.guardar_matriz_archivo(auxD,(posicion12G-1).ToString());
                    break;
                case 100:
                    Excepciones.Lanzar_bien(100); // (<>__<>)
                    break;
                default:
                    Salir = 1; //Sale del while
                    break;

            }
        }

    }
}
