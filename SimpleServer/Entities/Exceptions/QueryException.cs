using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class QueryException : Exception
    {
        public QueryException(Exception inner) : base(("Error al comunicarse con la base de datos: " + inner.Message), inner) { }
    }
}
