using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestorDeTareas
{
    public class MotorDeTareas 
    {
        public List<Tarea> listaTareas { get; set; }
        public MotorDeTareas()
        {
           listaTareas = new List<Tarea>();
        }
        
        public void EjecutarTareas()
        {


            //tarea con plazo
            //TareaConPlazo tareaConPlazo = new TareaConPlazo("Deberes de mates", DateTime.Now.AddDays(5));
            //tareaConPlazo.PresentarTarea(DateTime.Now.AddDays(4));
            //listaTareas.Add(tareaConPlazo);


            ////tarea localizada
            //TareaLocalizada tareaLocalizada1 = new TareaLocalizada("Tarea en el extranjero1", "Noruega");
            //TareaLocalizada tareaLocalizada2 = new TareaLocalizada("Tarea en el extranjero2", "Francia");
            //TareaLocalizada tareaLocalizada3 = new TareaLocalizada("Tarea en el extranjero3", "Francia");
            //TareaLocalizada tareaLocalizada4 = new TareaLocalizada("Tarea en el extranjero4", "Noruega");
            //tareaLocalizada1.PresentarTarea(DateTime.Now.AddDays(6));

            //AgregarTarea(tareaLocalizada1);
            //listaTareas.Add(tareaLocalizada2);
            //listaTareas.Add(tareaLocalizada3);
            //listaTareas.Add(tareaLocalizada4);




            //tarea subtareas
            TareaConSubtarea tareaConSubTarea = new TareaConSubtarea("Subtareas1");
            tareaConSubTarea.AñadirSubTarea("subtarea 1");
            tareaConSubTarea.AñadirSubTarea("subtarea 2");
            tareaConSubTarea.AñadirSubTarea("subtarea 3");

            TareaConSubtarea tareaConSubTarea2 = new TareaConSubtarea("Subtareas2");
            tareaConSubTarea2.AñadirSubTarea("subtarea 4");
            tareaConSubTarea2.AñadirSubTarea("subtarea 1");
            tareaConSubTarea2.AñadirSubTarea("subtarea 3");

            TareaConSubtarea tareaConSubTarea3 = new TareaConSubtarea("Subtareas3");
            tareaConSubTarea3.AñadirSubTarea("subtarea 5");
            tareaConSubTarea3.AñadirSubTarea("subtarea 4");
            tareaConSubTarea3.AñadirSubTarea("subtarea 3");

            AgregarTarea(tareaConSubTarea);
            AgregarTarea(tareaConSubTarea2);
            AgregarTarea(tareaConSubTarea3);
            BuscarPorSubTarea("subtarea 1");



            //Agregamos las listas a la lista general de tareas
            //aplicamos la restricciones  y generics para meter las listas de localizadas y subtareas a la lista general




            //MostrarTodaInformacion(listaTareas);
            //BuscarPorPais("Noruega");//Metodo buscar por pais

        }


        public void AgregarTarea(Tarea tarea)
        {
            if (tarea == null)
            {
                throw new ArgumentNullException(nameof(tarea), "No se puede agregar una tarea nula.");
            }
            listaTareas.Add(tarea);
        }

        public void BuscarPorPais(string pais) {

            //var listaLocalizados=listaTareasLocalizada.Where(p => p.Lugar.Equals(pais));
            //foreach (var tarea in listaLocalizados) {
            //    Console.WriteLine($"{tarea.Titulo} pais: {tarea.Lugar}");
            //}

            var localizadas = listaTareas.OfType<TareaLocalizada>().
                            Where(p => p.Lugar.Equals(pais)).
                            ToList();

            if (localizadas.Any())
            {
                MostrarTodaInformacionPorLista(localizadas);
            }
            else {
                Console.WriteLine("NO hay registros de ese pais");
            }
        }

        public void BuscarPorSubTarea(string subTarea) {

            List<Tarea> listaEncontradas = new List<Tarea>();
            var localizadas = listaTareas.OfType<TareaConSubtarea>().ToList()
                .Where(t => t.ListaSubTareas.Contains(subTarea, StringComparer.OrdinalIgnoreCase))
                .ToList();


            if (localizadas.Any())
            {
                Console.WriteLine($"--- Resultados para la subtarea: {subTarea} ---");
                MostrarTodaInformacionPorLista(localizadas);
            }
            else
            {
                Console.WriteLine($"No hay registros con la subtarea: '{subTarea}'");
            }

            //foreach (var subt in localizadas)
            //{
            //    foreach (var item in subt.ListaSubTareas)
            //    {
            //        if (item.Equals(subTarea))
            //        {
            //            listaEncontradas.Add(subt);
            //            break;
            //        }
            //    }
            //}

            //if (listaEncontradas.Any())
            //{
            //    foreach (var t in listaEncontradas) {
            //        Console.WriteLine(t.Titulo);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("NO hay registros de esa subatarea");
            //}
        
        }



        public void MostrarTodaInformacionPorLista<T>(List<T> listaTarea) where T : Tarea
        {

            foreach (var tarea in listaTarea)
            {
                tarea.ObtenerDatos();

            }
        }

        public void MostrarTodaInformacion() 
        {

            foreach (var tarea in listaTareas)
            {
                tarea.ObtenerDatos();

            }
        }


    }
}
