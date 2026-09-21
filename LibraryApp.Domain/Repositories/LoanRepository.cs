using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Repositories;


namespace LibraryApp.Domain.Repositories
{
    public class LoanRepository:InMemoryRepository<Loan>, ILoanReposistory
    {
        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Loan> GetLoanByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }
        public async Task AddLoanAsync(Loan loan)
        {
            await AddAsync(loan);
        }
        public async Task UpdateLoanAsync(Loan loan)
        {
            await UpdateAsync(loan);
        }
        public async Task DeleteLoanAsync(Guid id)
        {
            await DeleteAsync(id);
        }

    }
}
