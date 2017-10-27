using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using Archivos;

namespace ClasesInstanciables
{


    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region "Propiedades"

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }

        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i] { get { return this.jornada[i]; } set { this.jornada[i] = value; } }

        #endregion

        #region "Constructores"

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno i in g.Alumnos)
            {
                if (i == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor a in g.Instructores)
            {
                if (a == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);

        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase caso contrario lanza un exception
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor retorno = null;
            bool flag = true;

            foreach (Profesor i in g.Instructores)
            {
                if (i == clase)
                {
                    retorno = i;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor i in g.Instructores)
            {
                if (i != clase)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agregar una nueva Jornada indicando la clase, un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Profesor auxProf = (g == clase);
            List<Alumno> auxALumno = new List<Alumno>();
            try
            {
                foreach (Alumno a in g.Alumnos)
                {
                    if (a == clase)
                    {
                        auxALumno.Add(a);
                    }
                }

                Jornada auxJornada = new Jornada(clase, auxProf);

                auxJornada.Alumnos = auxALumno;

                g.Jornadas.Add(auxJornada);

            }
            catch (NullReferenceException)
            {


            }


            return g;
        }

        /// <summary>
        /// Agrega un  Alumno validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {


            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                g.Alumnos.Add(a);
            }

            return g;
        }

        /// <summary>
        /// Agrega un  Alumno validando que no estén previamente cargados.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {

            if (g == i)
            {
                throw new SinProfesorException();
            }
            else
            {
                g.Instructores.Add(i);
            }

            return g;
        }

        #endregion

        #region "Metodos"

        private static string MostrarDatos(Universidad g)
        {
            string retorno = "\nJORNADA: \n";

            for (int i = 0; i < g.Jornadas.Count; i++)
            {
                retorno += g[i];
            }

            return retorno;
        }

        /// <summary>
        /// Serializa una "Universidad" en un .xml, si no puede lanza un "ArchivosException".
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            bool retorno = false;

            try
            {
                Xml<Universidad> serializador = new Xml<Universidad>();

                retorno = serializador.Guardar("Universidad", gim);

            }
            catch (ArchivosException e)
            {
                throw e;
            }


            return retorno;
        }
        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Muestra los datos de la jornada de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion




    }
}
