using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Controladores;
using System.Collections.Generic;
using MD5Hash;
namespace Testing
{
    [TestClass]
    public class PizzaTest
    {
        private string GenerarStringRandom()
        {
            return Hash.Content(DateTime.Now.ToString());
        }

        private int GenerarNumeroRandom()
        {
            Random rnd = new Random();
            return rnd.Next(1000);
        }
        [TestMethod]
        public void TestEliminar()
        {
            string id = "21";
            bool resultado;
            Dictionary<string, string> pizza = new Dictionary<string, string>();

            try
            {
                resultado = PizzaControlador.Eliminar(id);
                pizza = PizzaControlador.Buscar(Int32.Parse(id));
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);
            Assert.AreEqual(pizza["resultado"], "false");
        }

        [TestMethod]
        public void TestEliminarUnoQueNoExiste()
        {
            string id = "100000";
            bool resultado = true;
            bool error = false;
            

            try
            {
                resultado = PizzaControlador.Eliminar(id);
            }
            catch (Exception ex)
            {
                error = true;
            }

            Assert.IsFalse(resultado);
            Assert.IsFalse(error);

        }

        [TestMethod]
        public void TestCrear()
        {
            bool resultado;
            Dictionary<string, string> pizza = new Dictionary<string, string>();

            string nombre = GenerarStringRandom();
            string precio = GenerarNumeroRandom().ToString();

            try
            {
                PizzaControlador.Crear(nombre,precio);
                pizza = PizzaControlador.BuscarPorNombre(nombre);
                resultado = true;
            }
            catch(Exception ex)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);
            Assert.AreEqual(pizza["nombre"], nombre);
            Assert.AreEqual(pizza["precio"], precio);

        }


    }
}
