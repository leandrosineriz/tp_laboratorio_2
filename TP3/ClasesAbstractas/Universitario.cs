using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region "Constructores"
        public Universitario()
            : base()
        {
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;

        }
        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (this.GetType() == obj.GetType())
            {
                if (this._legajo == ((Universitario)obj)._legajo || this.DNI == ((Universitario)obj).DNI)
                    retorno = true;

            }

            return retorno;
        }
        #endregion

        #region "Operadores"

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            try
            {
                if (pg1.Equals(pg2))
                    retorno = true;

            }
            catch (NullReferenceException)
            {

            }


            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

        #region "Metodos"

        /// <summary>
        /// Muestra los datos (incluida su herencia)
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO NUMERO :" + this._legajo;
        }

        protected abstract string ParticiparEnClase();

        #endregion
    }
}
