using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GestorDeTareas
{
    public class MotorDeTareas
    {

        List<Tarea> listaTareas = new List<Tarea>();
        List<TareaLocalizada> listaTareasLocalizada = new List<TareaLocalizada>();
        public void EjecutarTareas()
        {


            //tarea con plazo
            TareaConPlazo tareaConPlazo = new TareaConPlazo("Deberes de mates", DateTime.Now.AddDays(5));
            tareaConPlazo.PresentarTarea(DateTime.Now.AddDays(4));
            listaTareas.Add(tareaConPlazo);
            //tarea localizada
            TareaLocalizada tareaLocalizada1 = new TareaLocalizada("Tarea en el extranjero1", "Noruega");
            TareaLocalizada tareaLocalizada2 = new TareaLocalizada("Tarea en el extranjero2", "Francia");
            TareaLocalizada tareaLocalizada3 = new TareaLocalizada("Tarea en el extranjero3", "Francia");
            TareaLocalizada tareaLocalizada4 = new TareaLocalizada("Tarea en el extranjero4", "Noruega");
            tareaLocalizada1.PresentarTarea(DateTime.Now.AddDays(6));

            listaTareasLocalizada.Add(tareaLocalizada1);
            listaTareasLocalizada.Add(tareaLocalizada2);
            listaTareasLocalizada.Add(tareaLocalizada3);
            listaTareasLocalizada.Add(tareaLocalizada4);
            AgregarTareasALaListaGeneral(listaTareasLocalizada);//aplicamos la restricciones  y generics para meter las listas de localizadas y subtareas a la lista general

            //tarea subtareas
            TareaConSubtarea tareaConSubTarea = new TareaConSubtarea("Subtareas");
            tareaConSubTarea.AñadirSubTarea("subtarea 1");
            tareaConSubTarea.AñadirSubTarea("subtarea 2");
            tareaConSubTarea.AñadirSubTarea("subtarea 3");

            listaTareas.Add(tareaConSubTarea);

            MostrarTodaInformacion(listaTareas);

        }

        //public List<TareaLocalizada>TareasLocalizadasPorPais(string pais){
        //    foreach (var tarea in listaTareas) { 
                
            
        //    }
        //}

        public void AgregarTareasALaListaGeneral<T>(List<T> listaTareaEspecifica) where T : Tarea
        {
            foreach (var tarea in listaTareaEspecifica) {
                listaTareas.Add(tarea);
            }
        
        }

        public void MostrarTodaInformacion(List<Tarea> listaTarea)
        {

            foreach (var tarea in listaTarea)
            {
                tarea.ObtenerDatos();

            }
        }

    }
}
