using GestorDeTareas;

public class Program
{
    public static void Main(string[] args)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        TareaConPlazo tareaConPlazo = new TareaConPlazo("Deberes de mates", DateTime.Now.AddDays(5));
        listaTareas.Add(tareaConPlazo);
        TareaLocalizada tareaLocalizada = new TareaLocalizada("Tarea en extranjero","Noruega");
        listaTareas.Add(tareaLocalizada);
        foreach (var tarea in listaTareas) {

            tarea.ObtenerDatos();
        }
        
    }


}
