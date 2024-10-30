class Proyecto
{
    static void Main()
    {
        Console.WriteLine("El ARCHIVO SE VA A CREAR DE CERO SI UNA SOLA PARTE DEL ENCABEZADO FALTA");
        if(Funciones.comprobar_archivo() == false)
        {
            Funciones.crear_archivo();
        }
    }
}