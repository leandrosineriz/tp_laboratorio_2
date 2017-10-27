using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region "Propiedades"

        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }

        public Universidad.EClases Clase { get { return this._clase; } set { this._clase = value; } }

        public Profesor Instructor { get { return this._instructor; } set { this._instructor = value; } }

        #endregion

        #region "Constructores"

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno i in j._alumnos)
            {
                if (i == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega el alumno a la lista validando que no este previamente cargado.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Muestra todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = "\nCLASE DE: " + this.Clase + " POR " + this.Instructor + "\n\nALUMNOS: ";

            foreach (Alumno a in this.Alumnos)
            {
                retorno += "\n" + a;
            }

            retorno += "\n\n<---------------------------------------------------------->";

            return retorno;
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Guarda los datos de una "Jornada" en un .txt, si no puede lanza un "ArchivosException".
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> true si pudo </returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;

            try
            {
                Texto escritor = new Texto();

                escritor.Guardar("Jornada", jornada.ToString());

                retorno = true;

            }
            catch (ArchivosException e)
            {
                throw e;
            }


            return retorno;

        }

        /// <summary>
        /// Lee los datos del archivo "Jornada.txt" y los devuelve en forma de string.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string aux = "";

            try
            {
                Texto lectora = new Texto();

                lectora.Leer("Jornada", out aux);

            }
            catch (ArchivosException e)
            {

                throw e;
            }


            return aux;
        }

        #endregion
    }
}
