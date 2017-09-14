using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public class Numero
    {
        private double _numero;


        /// <summary>
        /// Getter de _numero
        /// </summary>
        /// <returns> valor en _numero </returns>
        public double getNumero()
        {
            return _numero;
        }

        /// <summary>
        /// Setter de _numero, en caso de que el parametro no sea un numero guarda un 0 
        /// </summary>
        /// <param name="numero"> Un string de un numero </param>
        private void setNumero(string numero)
        {
            this._numero=validarNumero(numero);
        }


        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Numero()
        {
            this._numero = 0;
 
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="numero"> Un numero de tipo Double </param>
        public Numero(double numero):this()
        {
            this._numero = numero;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="numero"> Un string de un numero </param>
        public Numero(string numero):this()
        {
            setNumero(numero);
        }

        /// <summary>
        /// Valida que el valor del string sea un numero caso contrario devuelve 0
        /// </summary>
        /// <param name="numeroString"> Un string de un numero </param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double retorno=0;

            double.TryParse(numeroString, out retorno);

            return retorno;

        }


    }
}
