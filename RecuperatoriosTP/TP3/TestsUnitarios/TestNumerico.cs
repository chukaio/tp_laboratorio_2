using System;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestNumerico
    {
        [TestMethod]
        public void AlumnoDniEsNumerico()
        {
            //Arrange
            Alumno c = new Alumno(3, "Ultra", "Magnus", "18456742", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            int dniObtenido;

            //Act
            dniObtenido = c.DNI;

            //Assert
            Assert.IsInstanceOfType(dniObtenido, typeof(int));
        }
    }
}
