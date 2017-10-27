using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {

        //Valida que no se puedan agregar alumnos con el mismo dni o legajo
        [TestMethod]
        public void ValidarAlumnoRepetidoException()
        {
            Universidad uni = new Universidad();

            Alumno alu1 = new Alumno(1, "Pepe", "Suarez", "23456789", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            Alumno alu2 = new Alumno(1, "Juan", "Ramirez", "23456789", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            uni += alu1;

            try
            {
                uni += alu2;
            }
            catch (AlumnoRepetidoException a)
            {

                Assert.IsTrue(alu1 == alu2);
            }

        }

        //Valida que el DNI sea correcto
        [TestMethod]
        public void ValidarDniInvalidoExeption()
        {
            try
            {
                Alumno alu1 = new Alumno(1, "Pepe", "Suarez", "asd", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("DNI INCORRECTO.");
            }
            catch (DniInvalidoException)
            {

            }

        }

        //Valida que el numero del DNI sea correcto
        [TestMethod]
        public void ValidarNumeroDni()
        {

            try
            {
                Alumno alu1 = new Alumno(1, "Pepe", "Suarez", "23456789", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
                alu1.DNI = 911111111;
                Assert.Fail("DNI INCORRECTO.");
            }
            catch (DniInvalidoException)
            {

            }

        }

        //Valida que no haya Nulos en los atributos de una "Universidad".
        [TestMethod]
        public void ValidarNulos()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);

            Assert.IsNotNull(uni.Instructores);

            Assert.IsNotNull(uni.Jornadas);

        }
    }
}
