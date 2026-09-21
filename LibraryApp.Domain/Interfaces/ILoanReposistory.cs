using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public  interface ILoanReposistory:IRepository<Loan>
    {
        public Task<IEnumerable<Loan>> GetAllLoansAsync();
        public Task<Loan> GetLoanByIdAsync(Guid id);
        public Task AddLoanAsync(Loan loan);
        public Task UpdateLoanAsync(Loan loan);
        public Task DeleteLoanAsync(Guid id);
    }
}
