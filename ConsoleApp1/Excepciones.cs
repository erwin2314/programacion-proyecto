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
            case 100:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ocurrio un error inesperado");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                break;
        }
    }
    public static void Lanzar_bien(int numero_error) 
    { 
        switch (numero_error)
        {
            case 0:
                Console.WriteLine("Se encontro el archivo correctamente");
                break;
            case 1:
                Console.WriteLine("No se encontro ningun problema con el encabezado");
                break;
            case 2:
                Console.WriteLine("Todos los valores de existencia se encuentran bien");
                break;
            case 100:
                Console.WriteLine("()__()");
                break;
            default:
                break;
        }
    }
}
