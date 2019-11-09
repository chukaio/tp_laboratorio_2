using System;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class DniInvalidoExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            //Arrange
            Alumno b = new Alumno(2, "Rodimus", "Prime", "autobot", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }
    }
}
