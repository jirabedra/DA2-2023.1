
namespace Entities.Exceptions
{
    public class UnexpectedDataAccessException : Exception
    {
        public UnexpectedDataAccessException(Exception inner) : base(("Error desconocido en la base de datos: " + inner.Message), inner) { }
    }
}
