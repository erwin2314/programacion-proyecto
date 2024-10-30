class Proyecto
{
    static void Main()
    {
        if(Funciones.comprobar_archivo() == false)
        {
            Funciones.crear_archivo();
        }
    }
}