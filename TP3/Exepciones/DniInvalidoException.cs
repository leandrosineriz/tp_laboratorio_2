using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class DniInvalidoException : ApplicationException
    {
        private string mensajeBase;

        public DniInvalidoException()
            : base()
        {
            this.mensajeBase = "El DNI no es valido para la nacionalidad";
        }

        public DniInvalidoException(Exception e)          
        {
            this.mensajeBase = e.Message;
        }

        public DniInvalidoException(string message)
            : base(message)
        {
            this.mensajeBase = message;
        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this.mensajeBase = message;
        }
    }
}
