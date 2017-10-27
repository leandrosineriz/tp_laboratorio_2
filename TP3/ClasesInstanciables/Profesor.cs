using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #region "Constructores"

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor()
            : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region "Sobrecargas"


        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        protected override string ParticiparEnClase()
        {
            string retorno = "\nCLASES DEL DIA: ";

            foreach (Universidad.EClases i in this._clasesDelDia)
            {
                retorno += "\n" + i;
            }

            return retorno;
        }

        /// <summary>
        /// Muestra los datos del profesor (incluida sus herencias)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Asigna 2 clases de manera aleatoria al profesor
        /// </summary>
        private void _randomClases()
        {

            for (int i = 0; i < 2; i++)
            {
                int rand = _random.Next(1, 5);

                switch (rand)
                {
                    case 1:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 4:
                        this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases e in i._clasesDelDia)
            {
                if (e == clase)
                {
                    retorno = true;
                    break;
                }

            }
            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
