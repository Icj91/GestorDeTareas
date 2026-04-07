using GestorDeTareas;

public class Program
{
    public static void Main(string[] args)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        //tarea con plazo
        TareaConPlazo tareaConPlazo = new TareaConPlazo("Deberes de mates", DateTime.Now.AddDays(5));

        listaTareas.Add(tareaConPlazo);
        //tarea localizada
        TareaLocalizada tareaLocalizada = new TareaLocalizada("Tarea en el extranjero","Noruega");
        listaTareas.Add(tareaLocalizada);

        //tarea subtareas
        TareaConSubtarea tareaConSubTarea = new TareaConSubtarea("Subtareas");
        tareaConSubTarea.AñadirSubTarea("subtarea 1");
        tareaConSubTarea.AñadirSubTarea("subtarea 2");
        tareaConSubTarea.AñadirSubTarea("subtarea 3");
   
        listaTareas.Add(tareaConSubTarea);
        



        //motor
        MotorDeTareas motorTareas = new MotorDeTareas();
        motorTareas.MostrarTodaInformacion(listaTareas);

    }


}
