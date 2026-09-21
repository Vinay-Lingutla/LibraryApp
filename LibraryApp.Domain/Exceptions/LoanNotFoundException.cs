using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Exceptions
{
    public class LoanNotFoundException: Exception
    {
        public LoanNotFoundException():base("Loan not found"){
        }
    }
}
