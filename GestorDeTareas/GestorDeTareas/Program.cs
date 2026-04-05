using GestorDeTareas;

public class Program
{
    public static void Main(string[] args)
    {
        List<Tarea> listaTareas = new List<Tarea>();
        Tarea tarea1 = new Tarea("Comprar alimentos", DateTime.Now.AddDays(2));

        // Agregar tareas a la lista
        listaTareas.Add(tarea1);
  
        
        Console.WriteLine("Tareas:");
        foreach (var tarea in listaTareas)
        {
            Console.WriteLine(tarea);
        }

        
        tarea1.EditarTarea("Comprar alimentos y bebidas", DateTime.Now.AddDays(4));
        tarea1.CambiarEstado(EstadoTarea.EnProgreso);

        
        Console.WriteLine("Tareas después de las modificaciones:");
        foreach (var tarea in listaTareas)
        {
            Console.WriteLine(tarea);
        }
    }


}
