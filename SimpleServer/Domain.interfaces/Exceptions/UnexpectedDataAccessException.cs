using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Exceptions
{
    public class UnexpectedDataAccessException : Exception
    {
        public UnexpectedDataAccessException(Exception inner) : base(("Error desconocido en la base de datos: " + inner.Message), inner) { }
    }
}
