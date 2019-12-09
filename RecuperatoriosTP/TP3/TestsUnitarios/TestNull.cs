using System;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TestNull
    {
        [TestMethod]
        public void InstanciaAlumnoEsNoNulo()
        {
            //Arrange
            Alumno d = new Alumno(4, "Dark", "Zarak", "45786521", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);

            //Assert
            Assert.IsNotNull(d);
        }
    }
}
