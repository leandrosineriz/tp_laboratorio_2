using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDeClases
{
    public class Calculadora
    {


        /// <summary>
        /// Opera los Double guardados en los objetos numero1 y numero2
        /// </summary>
        /// <param name="numero1"> Primer numero en la operacion </param>
        /// <param name="numero2"> Segundo numero en la operacion </param>
        /// <param name="operador"> Un string con el operador deseado </param>
        /// <returns> El resultado de la operacion </returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno=0;

            operador = validarOperador(operador);

            switch (operador)
            {
                case "+":
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    retorno = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    retorno = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (!(numero2.getNumero() == 0))
                        retorno = numero1.getNumero() / numero2.getNumero();
                    break;
            }

            return retorno;
        }


        /// <summary>
        /// Valida que el operador ingresado sea alguno valido caso contrario devuelve un "+"
        /// </summary>
        /// <param name="operador"> Un string con el operador deseado </param>
        /// <returns> El operador validado </returns>
        /// 
        public static string validarOperador(string operador)
        {
           string retorno = "+";

           if (operador == "+" || operador == "*" || operador == "-" || operador == "/")
               retorno = operador;

           return retorno;

        }
    }
}
