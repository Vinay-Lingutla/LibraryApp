using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Exceptions
{
    public class BookNotAvailableException: Exception
    {
        public BookNotAvailableException(): base("Book is not Available")
        {
        }
    }
}
