//Aunque el archivo y la clase se llame excepciones, realmente no se utiliza para lanzar excepciones (Al principio si lo hacia)
//Ahora solo es un lugar en el que se guardan dos cosas, cosas con mucho texto, o cuando se quiere lanzar un mensaje de consola
//de que las comprobaciones salieron bien o mal
public class Excepciones
{
    public static void Lanzar_excepcion(int numero_error)
    {
        switch (numero_error)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se encontro un problema al buscar el archivo, se va a crear uno nuevo");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se encontro un problema al revisar el encabezado del archivo");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se encontro un problema al revisar la existencia de la matriz en alguna posicion, la posicion se va a limpiar y esteblecer a 0");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede utilizar el valor ingresado");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo crear la matriz");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo guardar en el archivo");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo leer la matriz");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 7:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No existe una matriz en esa posicion");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 8:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo imprimir la matriz");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 9:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo eliminar la matriz");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 10:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo sumar las matrices");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 11:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo restar las matrices");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 12:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo multiplicar las matrices");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 13:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo sacar la determinante");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 14:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se pudo sacar la transposicion");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 100:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrio un error inesperado");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                break;
        }
    } //lanza un mensaje cuando algo malo pasa
    public static void Lanzar_bien(int numero_error) 
    { 
        switch (numero_error)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se encontro el archivo correctamente");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No se encontro ningun problema con el encabezado");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Todos los valores de existencia se encuentran bien");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 100:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("(<>__<>)");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                break;
        }
    }// (<>__<>)
    public static void Manual()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();     
        Console.WriteLine("Manual");
        Console.WriteLine();
        Console.WriteLine("Unicamente acepta numeros enteros, no porque no sepa como hacerlo, sino porque me di cuenta de eso muy tarde como para cambiarlo");
        Console.WriteLine();
        Console.WriteLine("Formato del archivo de guardado");
        Console.WriteLine();
        Console.WriteLine("1;0;");
        Console.WriteLine("^ numero del encabezado, solo se utiliza para indicar el numero de fila y poder modificarlo mas facilmente");
        Console.WriteLine();
        Console.WriteLine("1;0;");
        Console.WriteLine(" ^ cada tipo de dato importante va separado por un ;");
        Console.WriteLine();
        Console.WriteLine("1;0;");
        Console.WriteLine("  ^ Es el valor de existencia, indica si hay o no un valor con el que trabajar, ayuda para evitar errores");
        Console.WriteLine("  0 es que no hay nada, 1 es que hay una matriz y 2 es una determinante");
        Console.WriteLine();
        Console.WriteLine("2;1;2;2;1,2,/3,4,/");
        Console.WriteLine("    ^ Es la cantidad de filas de la matriz");
        Console.WriteLine();
        Console.WriteLine("2;1;2;2;1,2,/3,4,/");
        Console.WriteLine("      ^ Es la cantidad de columnas de la matriz");
        Console.WriteLine();
        Console.WriteLine("2;1;2;2;1,2,/3,4,/");
        Console.WriteLine("        ^ A partir de aqui comienzan los valores de la matriz, cada numero va separado por una coma");
        Console.WriteLine();
        Console.WriteLine("2;1;2;2;1,2,/3,4,/");
        Console.WriteLine("            ^ Un / indica que hay acaba una columna");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    } //Este es el manual del formato del archivo de texto
}
