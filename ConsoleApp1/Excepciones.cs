public class Excepciones
{
    public static void Lanzar_excepcion(int numero_error)
    {
        switch (numero_error)
        {
            case 0:
                Console.WriteLine("Se encontro un problema al buscar el archivo, se va a crear uno nuevo");
                break;
            case 1:
                Console.WriteLine("Se encontro un problema al revisar el encabezado del archivo");
                break;
            case 2:
                Console.WriteLine("Se encontro un problema al revisar la existencia de la matriz en alguna posicion, la posicion se va a limpiar y esteblecer a 0");
                break;
            case 100:
                Console.WriteLine("Ocurrio un error inesperado");
                break;
            default:
                break;
        }
    }
}