using GestorDeTareas.Domain.Entities;
using NUnit.Framework;
using System.Numerics;

namespace GestorTareas.Test
{
    [TestFixture]
    public class Tests
    {
        private MotorDeTareas _motorTareas;
        [SetUp]
        public void Setup()
        {
            _motorTareas = new MotorDeTareas();
        }

        [Test]
        public void Obtener_TresTareasAgregadas()
        {
            // ARRANGE
            TareaLocalizada tareaLocalizada1 = new TareaLocalizada("Tarea en el extranjero1", "Noruega");
            TareaLocalizada tareaLocalizada2 = new TareaLocalizada("Tarea en el extranjero2", "Francia");
            TareaLocalizada tareaLocalizada3 = new TareaLocalizada("Tarea en el extranjero3", "Francia");

            _motorTareas.AgregarTarea(tareaLocalizada1);
            _motorTareas.AgregarTarea(tareaLocalizada2);
            _motorTareas.AgregarTarea(tareaLocalizada3);

            // ACT
            _motorTareas.MostrarTodaInformacion();

            // ASSERT — completa estas líneas:
            Assert.That(_motorTareas.listaTareas.Count, Is.EqualTo(3));
        }



        [Test]
        public void CrearTareaLocalizada_SiEsEspaña_LanzaException()
        {
            // Como el error lo lanza el "new", el Assert.Throws debe envolver al constructor, ya que si creo el objeto antes no me deja
            var ex = Assert.Throws<ArgumentException>(() => new TareaLocalizada("Título", "España"));

            //Verifico que el mensaje sea el del error
            Assert.That(ex.Message, Is.EqualTo("España no esta permitido"));
        }

    }
}
