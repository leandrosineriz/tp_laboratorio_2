using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{

    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region "Constructores"

        public Alumno()
            : base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Muestra los datos del alumno (incluida sus herencias)
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + this._estadoCuenta + "\n" + this.ParticiparEnClase() + "\n";
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this._claseQueToma;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                retorno = true;

            return retorno;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
