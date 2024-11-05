class Proyecto
{
    static void Main()
    {
        if(Funciones.comprobar_encabezado() == false)
        {
            Funciones.crear_archivo();
        }
        Funciones.comprobar_indice_existencia();
    }
}