//En este archivo se guardan todas las funciones
//Mas informacion del como se guardan las matrices en la parte de Excepciones en la funcion de Manual
class Funciones
{
    public static bool comprobar_encabezado()
    {
        //Esto solo es un sistema de "puntos" que aumenta por cada encabezado bien hecho
        int puntos = 0;


        if (File.Exists("matrices.txt") == true)
        {
            
            using (StreamReader Sr = new StreamReader("matrices.txt"))
            {
                string line;
                for (int i = 1; i <= 9; i++)
                {
                    line = Sr.ReadLine();
                    if (line == null)
                    {
                        puntos = puntos - 1;
                    }
                    else if (line.Length >= 2)
                    {
                        if (line[0] == Convert.ToChar(i + '0') && line[1] == ';')
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
        //si la cantidad de puntos es 9 el encabezado esta bien
        if (puntos == 9)
        {
            return true;
        }
        Excepciones.Lanzar_excepcion(0);
        return false;


    }
                                                       //Comprueba que este valor 1;1;2;2;1,2,/3,4,/ este enre 1 a 9
                                                       //                         ^
                                                       //Esto comprueba que el encabezado tenga el formato correcto
                                                       //Aqui se empezo a hacer todo, por lo que esta horrible y tambien
                                                       //es el responsable de que solo pueda guardar 9 matrices
    public static void crear_archivo()
    {
        using (StreamWriter Sw = new StreamWriter("matrices.txt"))
        {
            Console.WriteLine("Se creo el archivo");
            for (int i = 1; i <= 9; i++)
            {
                Sw.WriteLine(i + ";0;");
            }
        }
    } //Su nombre lo dice, crea un archivo nuevo
    public static void comprobar_indice_existencia()
    {
        int fila = 0;
        StreamReader Sr = new StreamReader("matrices.txt"); //Crea el StreamReader con el archivo de texto
        for (int i = 0; i < 9; i++)
        {

            string line = Sr.ReadLine();//obtiene una linea de texto
            if (line.Length < 4)//esto comprueba si le falta algo a la linea de texto (es decir que es menor que 4 caracteres)
            {
                Excepciones.Lanzar_excepcion(2);
                Sr.Close();
                fila = i;//no se porque no utilize i directamente
                escribir_lugar_especifico("", fila.ToString(), "0");//se lie falta algo reescribe toda la linea y pone el valor de existencia en 0
                break;
                //como esto cuenta como error cierra el bucle completo y terminas volviendo al menu
            }
            //Toda esa linea giante solo comprueba que el valor de existencia no sea 0,1,2
            else if ((Convert.ToChar(line[2]) != Convert.ToChar("0") && Convert.ToChar(line[2]) != Convert.ToChar("1") && Convert.ToChar(line[2]) != Convert.ToChar("2")) || Convert.ToChar(line[3]) != Convert.ToChar(";"))
            {
                //Si por alguna razon no el valor no es 0,1,2 lanza un mensaje de consola, reescribe y lo pone en cero
                Excepciones.Lanzar_excepcion(2);
                Sr.Close();
                fila = i;
                escribir_lugar_especifico("", fila.ToString(), "0");
                break;
            }
        }
        Sr.Close();
    }//Comprueba que este valor 1;1;2;2;1,2,/3,4,/ (Asi se guardan las matrices) sea 0,1,2
                                                       //                           ^
    public static void escribir_lugar_especifico(string texto_nuevo, string filaS, string existenciaS)
    {
        //La funcion pide datos en este orden
        //El nuevo texto que se va a poner
        //La fila en que se va a escribir
        //Y el valor de existencia
        bool conversion;
        //Aqui se convierte el valor de la fila a un numero entero, se pide primero en texto para evitar errores
        conversion = Int32.TryParse(filaS, out int fila);
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(5);
            return;
        }
        //Comprueba que la cantidad de filas sea valida
        if (fila < 0 || fila > 9) 
        {
            Excepciones.Lanzar_excepcion(5);
            return;
        }
        //Aqui se convierte el valor de la existencia a un numero entero, se pide primero en texto para evitar errores
        conversion = Int32.TryParse(existenciaS, out int existencia);
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(5);
            return;
        }
        //Comprueba que el valor de existencia sea valido
        if (existencia < 0 || existencia > 2) 
        {
            Excepciones.Lanzar_excepcion(5);
            return;
        }
        //Se crea un nuevo string que va a contener todo el texto y se le asigna
        string[] texto_antiguo = new string[9];
        using (StreamReader Sr = new StreamReader("matrices.txt"))
        {
            for (int i = 0; i < 9; i++)
            {
                texto_antiguo[i] = Sr.ReadLine();
            }
            //Esto ingresa el texto deseado en la matriz del archivo
            if (fila > -1 || fila < 9)
            {
                texto_antiguo[fila] = (fila + 1) + ";" + existencia + ";" + texto_nuevo;
            }
        }
        //Reescribe el archivo de texto ahora cambiado
        using (StreamWriter Sw = new StreamWriter("matrices.txt"))
        {
            for (int i = 0; i < 9; i++)
            {
                Sw.WriteLine(texto_antiguo[i]);
            }
        }
    }
                                                       //Esta el la funcion que se utiliza para poder escribir enel archivo de texto
    public static void imprimir_texto()
    {
        Console.ForegroundColor = ConsoleColor.Yellow; // colores para mas bonito (<>__<>)
        using (StreamReader Sr = new StreamReader("matrices.txt"))
        {
            string[] texto = new string[9];//Crea un string y se le ... creo que esto no se utiliza
            string line;//se crea un string
            for (int i = 0; i < 9; i++)
            {
                //Se le da el valor a line y lo imprime en consola
                line = Sr.ReadLine();
                Console.WriteLine(line);
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
                                                      //Escribe en consola todo el contenido del archivo de texto
    public static int[,] crear_matriz()
    {
        //Pregunta por la cantidad de columnas
        Console.WriteLine("Ingresa la cantidad de columnas");
        bool conversion = Int32.TryParse(Console.ReadLine(), out int columnas);
        if (conversion == false)
        {//comprobacion de valores
            Excepciones.Lanzar_excepcion(3);
            Excepciones.Lanzar_excepcion(4);
            return null;
        }
        //Pregunta por la cantidad de filas
        Console.WriteLine("Ingresa la cantidad de filas");
        conversion = Int32.TryParse(Console.ReadLine(), out int filas);
        if (conversion == false)
        {//comprobacion de valores
            Excepciones.Lanzar_excepcion(3);
            Excepciones.Lanzar_excepcion(4);
            return null;
        }

        //unicamente crea la matriz si su cantidad de filas y columnas son mayores a uno
        if ((filas > 1) && (columnas > 1))
        {
            int[,] matriz = new int[columnas, filas];//crea la matriz
            for (int i = 0; i <= columnas - 1; i++)//da valores a la matriz
            {
                for (int j = 0; j <= filas - 1; j++)
                {
                    Console.WriteLine("Ingresa el valor de la columna: " + (i + 1) + " y fila: " + (j + 1));
                    conversion = Int32.TryParse(Console.ReadLine(), out int numero);//comprueba que el numero es valido
                    if (conversion == false)
                    {
                        Excepciones.Lanzar_excepcion(3);
                        Excepciones.Lanzar_excepcion(4);
                        return null;
                    }

                    matriz[i, j] = numero;//se le asigna

                }
            }

            return matriz;
        }
        Excepciones.Lanzar_excepcion(3);
        Excepciones.Lanzar_excepcion(4);
        return null;
    }
                                                      //Crea una matriz de enteros, lamentablente no puse para poder llenarla de forma automatica 
    public static void imprimir_matriz(int[,] matriz)
    {
        try
        {
            Console.WriteLine();
            for (int i = 0; i < matriz.GetLength(0); i++)//un for para cada fila
            {
                Console.Write("|");
                for (int j = 0; j < matriz.GetLength(1); j++)//otro para cada columna
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine();
        }
        catch//errores
        {
            Excepciones.Lanzar_excepcion(8);
        }
    }
                                                      //Imprime la matriz en la consola
    public static void imprimir_matriz_linea(int[,] matriz)
    {
        try
        {
            Console.WriteLine();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        catch
        {
            Excepciones.Lanzar_excepcion(8);
        }
    }
                                                      //Lo mismo que el de arrbia pero en linea recta y sin formato, solo se utilizo para comprobar valores, ya no se ocupa, deberia borrarlo
    public static void guardar_matriz_archivo(int[,] matriz, string fila)
    {
        //Pide la matriz a guardar
        //Y la posicion en donde se va a guardar
        if (matriz != null)// solo lo hace si la matriz no es nula
        {
            string line;
            //Pone en el string los valores de cantidad de filas y de columnas ya con formato
            line = matriz.GetLength(0).ToString() + ";";
            line = line + matriz.GetLength(1).ToString() + ";";
            //Escribe los valores de la matriz en el string
            for (int i = 0; i <= matriz.GetLength(0) - 1; i++)//for para filar
            {
                for (int j = 0; j <= matriz.GetLength(1) - 1; j++)//for para columnas
                {
                    line = line + matriz[i, j].ToString() + ",";//introduce el valor y lo separa por comas
                }
                line = line + "/";//cada ves que se terminan de poner los valores de una fila se pone un "/" para separar las columnas

            }
            escribir_lugar_especifico(line, fila, "1");//Escribe la linea e el lugar espesifico
        }
        else { return; }//Ya hay tantas funciones que lanzan excepciones si no tienen esto que es irrelevante que lanze exepciones
        
    }
                                                      //Su nombre lo dice, guarda matrices de enteros en el archivo de texto
    public static int[,] leer_matriz_archivo(string filaS)
    {
        bool conversion = Int32.TryParse(filaS, out int fila);//convierte las filas a enteros
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(6);
            return null;
        }
        if (fila < 0 || fila > 9)//comprueba el valor de las filas
        {
            Excepciones.Lanzar_excepcion(6);
            return null;
        }
        //Todos los valores que se van a utilizar
        string line;
        string[] split;
        string[] split2;
        string[] texto = new string[9];
        int[,] matriz;
        //Se le asigna todo el texto al string texto
        using (StreamReader Sr = new StreamReader("matrices.txt"))
        {
            for (int i = 0; i < 9; i++)
            {
                texto[i] = Sr.ReadLine();
            }
            //Se le asigna el texto de la fila deseada a line
            line = texto[fila];
        }
        //comprueba que el valor de existencia sea 1
        if (line[2] == Convert.ToChar("1"))
        {
            matriz = new int[Convert.ToInt32(line[4]) - 48, Convert.ToInt32(line[6]) - 48];//Define las dimensiones de la matriz
            split = line.Split(';');//Separa line por cada ; que tenga
            line = split[4];//Si todo salio bien en todo el codigo, split [4] siempre deberia contener los valor a poner en la matriz
            split = line.Split('/');//ahora separa todos los valores por cada /  es decir por cada columna

            //Esto corre siempre que la cantidad de columnas sea mayor al de las filas
            if (split.Length > matriz.GetLength(0))
            {
                for (int i = 0; i < matriz.GetLength(1); i++)//for por cada columna
                {
                    line = split[i];//le da el valor de una columna a line
                    line = line.Substring(0, line.Length - 1);//quita el utlimo caracter, que siempre es una coma, pero pues... no puede ser una coma
                    split2 = line.Split(",");//separa line por cada coma
                    for (int j = 0; j < matriz.GetLength(0); j++)//ingresa los valores a la matriz
                    {
                        line = split2[j];
                        matriz[j, i] = Convert.ToInt32(line);
                    }
                }
            }

            //Esto corre siempre que la cantidad de filas sea mayor al de las columnas
            //Lo mismo de arriba, pero con columnas y filas invertidas
            else if (split.Length < matriz.GetLength(0)) 
            {

                for (int i = 0; i < matriz.GetLength(1); i++)
                {
                    line = split[i];
                    line = line.Substring(0, line.Length - 1);
                    split2 = line.Split(",");
                    for (int j = 0; j < matriz.GetLength(0); j++)
                    {
                        line = split2[j];
                        matriz[i, j] = Convert.ToInt32(line);
                    }
                }
            }

            //Viendo esto de nuevo creo que no hace falta, pero no quiero tocar nada de aqui, por lo que hay se queda
            else if (split.Length == matriz.GetLength(0))
            {
                for (int i = 0; i < matriz.GetLength(1); i++)
                {
                    line = split[i];
                    line = line.Substring(0, line.Length - 1);
                    split2 = line.Split(",");
                    for (int j = 0; j < matriz.GetLength(0); j++)
                    {
                        line = split2[j];
                        matriz[j, i] = Convert.ToInt32(line);
                    }
                }
            } 
            return matriz;
        }
        else//si no es 1 tira error
        {
            Excepciones.Lanzar_excepcion(6);
            return null;
        }

    }
                                                     //Su nombre lo dice
    public static void borrar_matriz(string filaS)
    {
        bool conversion = Int32.TryParse(filaS, out int fila);
        if (conversion == false)
        {
            Excepciones.Lanzar_excepcion(9);
            return;
        }
        fila = fila - 1;
        escribir_lugar_especifico("", fila.ToString(), "0");
    }
                                                     //Aunque en su nombre diga borrar, realmente lo que hace es remplazar el texto por un espacio
                                                     //y poner el valor de existencia en 0
    public static int[,] suma_matrices(int[,] matriz1, int[,] matriz2)
    {
        int[,] matriz;
        //compruea que las matrices no sean nulas
        if (matriz1 == null || matriz2 == null)
        {
            Excepciones.Lanzar_excepcion(10);
            return null;
        }
        //comprueba las dimensiones de las matrices y las suma
        if (matriz1.GetLength(0) == matriz2.GetLength(0) && matriz1.GetLength(1) == matriz2.GetLength(1))
        {
            imprimir_matriz(matriz1);
            Console.WriteLine(" + ");
            imprimir_matriz(matriz2);
            matriz = new int[matriz1.GetLength(0), matriz1.GetLength(1)];//Le da dimensiones a la matriz que se va a devolver
            for (int i = 0; i < matriz1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz1.GetLength(1); j++)
                {
                    matriz[j, i] = matriz1[i, j] + matriz2[i, j];//Se ingresan los valores
                }
            }
            return matriz;
        }
        else 
        {
            Excepciones.Lanzar_excepcion(10);
            return null;
        }
        
    }
                                                     //Solo matrices de enteros
    public static int[,] resta_matrices(int[,] matriz1, int[,] matriz2)
    {
        //Lo mismo que la suma pero con signos de -
        //literalmente lo mismo
        int[,] matriz;
        if (matriz1 == null || matriz2 == null)
        {
            Excepciones.Lanzar_excepcion(11);
            return null;
        }
        if (matriz1.GetLength(0) == matriz2.GetLength(0) && matriz1.GetLength(1) == matriz2.GetLength(1))
        {
            imprimir_matriz(matriz1);
            Console.WriteLine(" - ");
            imprimir_matriz(matriz2);
            matriz = new int[matriz1.GetLength(0), matriz1.GetLength(1)];
            for (int i = 0; i < matriz1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz1.GetLength(1); j++)
                {
                    matriz[j, i] = matriz1[i, j] - matriz2[i, j];
                }
            }
            return matriz;
        }
        else
        {
            Excepciones.Lanzar_excepcion(10);
            return null;
        }

    }
    public static int[,] multiplicacion_matrices(int[,] matriz1, int[,] matriz2)
    {
        int[,] matriz;
        //comprueba que las matrices no sean nulas
        if (matriz1 == null || matriz2 == null)
        {
            Excepciones.Lanzar_excepcion(12);
            return null;
        }
        //comprueba las dimensiones
        if (matriz1.GetLength(1) == matriz2.GetLength(0))
        {
            imprimir_matriz(matriz1);
            Console.WriteLine(" * ");
            imprimir_matriz(matriz2);
            matriz = new int[matriz1.GetLength(0), matriz2.GetLength(1)];//les da las dimensiones a la nueva matriz
            for (int i = 0; i < matriz1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz2.GetLength(1); j++)
                {
                    for (int k = 0; k < matriz1.GetLength(1); k++)
                    {
                        matriz[i, j] += matriz1[i, k] * matriz2[k, j];//Solo se que funciona, lamentablemente no me acuerdo porque funciona
                        
                    }
                }
            }
            imprimir_matriz(matriz);
            return matriz;
        }
        else
        {
            Excepciones.Lanzar_excepcion(15);
            return null;
        }

    }
    public static int determinante_matriz(int[,] matriz)
    {
        //solo son determinantes de matrices 2x2 y 3x3
        //no se como se sacan las demas
        int aux = 0;
        if (matriz == null)//comprueba que no sea nula
        {
            Excepciones.Lanzar_excepcion(13);
            return aux;
        }
        else if (matriz.GetLength(0) == 2 && matriz.GetLength(1) == 2)//Esta es en caso de que las matrices sean 2x2
        { 
            aux = matriz[0,0] * matriz[1, 1] - matriz[1,0] * matriz[0,1];//Esto seria como la "formula" para sacar la determinante
            return aux;
        }
        else if (matriz.GetLength(0) == 3 && matriz.GetLength(1) == 3)//Esta es en caso de que las matrices sean 3x3
        {
            aux = matriz[0, 0] * (matriz[1, 1] * matriz[2, 2] - matriz[1, 2] * matriz[2, 1])
                    - matriz[0, 1] * (matriz[1, 0] * matriz[2, 2] - matriz[1, 2] * matriz[2, 0])//Igualmente esto seria como la formula
                    + matriz[0, 2] * (matriz[1, 0] * matriz[2, 1] - matriz[1, 1] * matriz[2, 0]); 
            return aux;
        }
        else //errores
        {
            Excepciones.Lanzar_excepcion(13);
            return aux; 
        }
    }
    public static void guardar_determinante(int determinante, string fila)
    {
        //Super simple
        try
        {
            escribir_lugar_especifico(determinante.ToString(), fila, "2");
        }
        catch (Exception ex) { Excepciones.Lanzar_excepcion(100); }
    }
                                                    //Esta cosa solo llama directamente a la funcion de escribir_lugar_especifico() porque como no es una matriz no puede utilizar guardar_matriz_archivo()
    public static int[,] trasposicion(int[,] matriz)
    {
        if (matriz == null)//que la matriz no sea nula
        {
            Excepciones.Lanzar_excepcion(14);
            return null;
        }
        int[,] matriz_nueva = new int[matriz.GetLength(1), matriz.GetLength(0)];//le da dimensiones a la nueva matriz
        if (matriz.GetLength(0) <= matriz.GetLength(1))//En caso de que la cantidad de columnas sea igual o mayor a de las filas
        {
            for (int i = 0; i < matriz.GetLength(1); i++)//for para columnas
            {
                for ( int j = 0; j < matriz.GetLength(0); j++)//for para filas
                {
                    matriz_nueva[j,i] = matriz[i,j];//le los valores invertidos
                }
            }
            return matriz_nueva;
        }
        else if (matriz.GetLength(1) < matriz.GetLength(0))//En caso de que la cantidad de fila sea menor al de columnas
        {
            for (int i = 0; i < matriz.GetLength(0); i++)//for para filas
            {
                for (int j = 0; j < matriz.GetLength(1); j++)//for para columnas
                {
                    matriz_nueva[j, i] = matriz[i, j];//le los valores invertidos
                }
            }
            return matriz_nueva;
        }
        else
        {
            return null;
        }
        
    }
}
