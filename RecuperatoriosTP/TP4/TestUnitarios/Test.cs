using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests_Unitarios
{
    [TestClass]
    public class Test
    {
        /// <summary>
        /// Chequea que la instancia de correa no sea nula.
        /// </summary>
        [TestMethod]

        public void ListaPaquetesEstaInstanciada()
        {
            //Arrange
            Correo c = new Correo();

            //Assert
            Assert.IsNotNull(c.Paquetes);
        }

        /// <summary>
        /// Chequea que dos paquetes con el mismo tracking id no puedan cargarse.
        /// </summary>
        [TestMethod]

        public void NoCargarDosPaquetes()
        {
            //Arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Calle Infierno 666", "854259");
            Paquete p2 = new Paquete("Pepe", "854259");

            //Assert
            try
            {
                correo += p1;
                correo += p2;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));

            }
        }
    }
}
