using GestorDeTareas;
using NUnit.Framework;

namespace GestorTareas.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ObtenerTodas_TresTareasAgregadas()
        {
            // ARRANGE
            TareaLocalizada tareaLocalizada1 = new TareaLocalizada("Tarea en el extranjero1", "Noruega");
            TareaLocalizada tareaLocalizada2 = new TareaLocalizada("Tarea en el extranjero2", "Francia");
            TareaLocalizada tareaLocalizada3 = new TareaLocalizada("Tarea en el extranjero3", "Francia");
            MotorDeTareas motorTareas = new MotorDeTareas();
            motorTareas.AgregarTarea(tareaLocalizada1);
            motorTareas.AgregarTarea(tareaLocalizada2);
            motorTareas.AgregarTarea(tareaLocalizada3);

            // ACT
            motorTareas.MostrarTodaInformacion();

            // ASSERT — completa estas líneas:
            Assert.That(motorTareas.listaTareas.Count, Is.EqualTo(3));

            /* Incluye aquí tu código */
        }

    }
}
