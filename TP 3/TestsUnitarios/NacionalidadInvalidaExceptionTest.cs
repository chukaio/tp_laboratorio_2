using System;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class NacionalidadInvalidaExceptionTest
    {
        [TestMethod]
        [ExpectedExceptionAttribute(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            //Arrange
            Alumno a = new Alumno(1, "Optimus", "Prime", "23456789", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }
    }
}
