using GestorDeTareas.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace GestorDeTareas.Domain.Entities
{
    public class MotorDeTareas 
    {
        public List<Tarea> listaTareas { get; set; }
        public List<TareaDto> listaDto { get; set; }
        public MotorDeTareas()
        {
           listaTareas = new List<Tarea>();
           listaDto = new List<TareaDto>();
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
            tareaConSubTarea.AnadirSubTarea("subtarea 1");
            tareaConSubTarea.AnadirSubTarea("subtarea 2");
            tareaConSubTarea.AnadirSubTarea("subtarea 3");

            //TareaConSubtarea tareaConSubTarea2 = new TareaConSubtarea("Subtareas2");
            //tareaConSubTarea2.AñadirSubTarea("subtarea 4");
            //tareaConSubTarea2.AñadirSubTarea("subtarea 1");
            //tareaConSubTarea2.AñadirSubTarea("subtarea 3");

            //TareaConSubtarea tareaConSubTarea3 = new TareaConSubtarea("Subtareas3");
            //tareaConSubTarea3.AñadirSubTarea("subtarea 5");
            //tareaConSubTarea3.AñadirSubTarea("subtarea 4");
            //tareaConSubTarea3.AñadirSubTarea("subtarea 3");

            AgregarTarea(tareaConSubTarea);
            //AgregarTarea(tareaConSubTarea2);
            //AgregarTarea(tareaConSubTarea3);
            //BuscarPorSubTarea("subtarea 1");

            listaDto = VolcarADto(listaTareas);

            //MostrarTodaInformacionPorLista
            //Agregamos las listas a la lista general de tareas
            //aplicamos la restricciones  y generics para meter las listas de localizadas y subtareas a la lista general




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
        
        }



        public void MostrarTodaInformacionPorLista<T>(List<T> listaTarea) where T : Tarea
        {

            foreach (var tarea in listaTarea)
            {
                tarea.ObtenerDatos();

            }
        }


        // Versión para DTOs la sobrecargamos
        public void MostrarTodaInformacionPorLista(List<TareaDto> listaDto)
        {
            foreach (var dto in listaDto)
            {
                Console.WriteLine($"[DTO] ID: {dto.TareaId} | Título: {dto.Titulo} | Estado: {dto.Estado}");
            }
        }

        public List<TareaDto> VolcarADto(List<Tarea> listaOriginal)
        {
            var listaDto = new List<TareaDto>();

            foreach (var tarea in listaOriginal)
            {
                var dto = new TareaDto
                {
                    TareaId = tarea.TareaId,
                    Titulo = tarea.Titulo,
                    FechaCreacion = tarea.FechaCreacion,
                    Estado = tarea.Estado,
                    FechaPresentacion = tarea.FechaPresentacion
                };

                // Guardamos datos específicos según el tipo
                if (tarea is TareaLocalizada tareaLocalizada)
                {
                    
                    dto.Lugar = tareaLocalizada.Lugar;
                }
                else if (tarea is TareaConSubtarea tareaConSubtarea)
                {
                    
                    dto.ListaSubTareas = tareaConSubtarea.ListaSubTareas;
                }
                else if(tarea is TareaConPlazo tareaConPlazo)
                {
                    dto.FechaVencimiento = tareaConPlazo.FechaVencimiento;
                }

                listaDto.Add(dto);
            }


            return listaDto;
        }




    
    }
}
