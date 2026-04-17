using GestorDeTareas;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {

        static List<TareaDto> CargarDatos()
        {
            const string ruta = "tareas.json";
            if (!File.Exists(ruta))
            {
                Console.WriteLine("Sin datos previos. Iniciando vacío.");
                return new List<TareaDto>();
            }
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<TareaDto>>(json) ?? new List<TareaDto>();

        }

        // Al cerrar el programa — guardar siempre
        static void GuardarDatos(List<TareaDto> datos)
        {
            File.WriteAllText("tareas.json",
            JsonSerializer.Serialize(datos,
            new JsonSerializerOptions { WriteIndented = true }));
        }




        //cargamos
        MotorDeTareas motorTareas = new MotorDeTareas();
        
        

        motorTareas.EjecutarTareas();



        GuardarDatos(motorTareas.listaDto);




        
    }


}
