using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{


    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region "Propiedades"

        public string Apellido { get { return this._apellido; } set { this._apellido = ValidarNombreApellido(value); } }

        /// <summary>
        /// Solo carga si el DNI es valido
        /// </summary>
        public int DNI { get { return this._dni; } set { this._dni = ValidarDni(this.Nacionalidad, value); } }

        public ENacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad = value; } }

        public string Nombre { get { return this._nombre; } set { this._nombre = ValidarNombreApellido(value); } }

        /// <summary>
        /// Solo carga si el DNI es valido
        /// </summary>
        public string StringToDni
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);

                }
                catch (DniInvalidoException e)
                {

                    throw e;
                }

            }
        }
        #endregion

        #region "Constructores"
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
            this.Apellido = apellido;

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;

        }
        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Muestra los Datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\nNOMBRE COMPLETO: " + this.Nombre + ", " + this.Apellido + "\nNACIONALIDAD: " + this.Nacionalidad;
        }
        #endregion

        #region "Metodos"

        /// <summary>
        ///  Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad sino lanzara una excepcion.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato < 1 || dato > 89999999)
                    throw new DniInvalidoException();

            }
            else
            {
                if (dato >= 1 && dato <= 89999999)
                    throw new NacionalidadInvalidaException();
            }

            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;

            if (int.TryParse(dato, out retorno))
            {
                retorno = ValidarDni(nacionalidad, retorno);
            }
            else
            {
                throw new DniInvalidoException();
            }

            return retorno;

        }

        /// <summary>
        /// Valida que el Nombre o Apellido tengan caracteres validos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";

            Regex val = new Regex(@"[a-zA-ZñÑ\s]{2,50}");

            if (val.IsMatch(dato))
            {
                retorno = dato;
            }

            return retorno;
        }
        #endregion

    }
}
