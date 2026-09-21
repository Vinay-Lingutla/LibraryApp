using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Services
{
    public class LoanService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanReposistory _loanRepository;
        private readonly IMemberRepository _memberRepository;
        public LoanService(IBookRepository bookRepository, ILoanReposistory loanRepository, IMemberRepository memberRepository)
        {
            _bookRepository = bookRepository;
            _loanRepository = loanRepository;
            _memberRepository = memberRepository;
        }
        //IssueBookAsync(bookId, memberId)

        //1. Get Book
        //2. If Book not found -> Exception
        //3. Get Member
        //4. If Member not found -> Exception
        //5. Check AvailableCopies
        //6. If AvailableCopies = 0 -> BookNotAvailableException
        //7. Create Loan
        //8. Reduce AvailableCopies
        //9. Save Loan
        //10. Update Book
        public async Task IssueBookAsync(Guid bookId, Guid memberId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new BookNotAvailableException();
            }
            var member = await _memberRepository.GetMemberByIdAsync(memberId);
            if (member == null)
            {
                throw new MemberNotFoundException();

            }
            if (book.AvailableCopies <= 0)
            {
                throw new BookNotAvailableException();
            }
            Loan loan = new Loan
            (
               bookId,
               memberId,
                DateTime.Now,
                DateTime.Now.AddDays(14)
            );
            await _loanRepository.AddLoanAsync(loan);
            book.AvailableCopies--;
            await _bookRepository.UpdateBookAsync(book);



        }
        public async Task ReturnBookAsync(Guid loanId)
        {
            var loan = await _loanRepository.GetLoanByIdAsync(loanId);
            if (loan == null)
            {
                throw new LoanNotFoundException();
            }
            var book = await _bookRepository.GetBookByIdAsync(loan.BookId);
            if (book == null)
            {
                throw new ArgumentException("Book not Found");
            }
            book.AvailableCopies++;
            await _bookRepository.UpdateBookAsync(book);
            await _loanRepository.DeleteLoanAsync(loanId);

        }
        public async Task<IEnumerable<Book>> GetAllAvailableBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return books.Where(b => b.AvailableCopies > 0);
        }
        public async Task<IEnumerable<Loan>> GetAllOverDueLoansAsync()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return loans.Where(loans=> loans.ReturnDate > DateTime.Now);
        }
        public async Task<IEnumerable<Loan>> GetMemberLoansAsync()
        {
            var loans = await _loanRepository.GetAllLoansAsync();
            return loans.Where(loans=>loans.ReturnDate > DateTime.Now);
        }
    }
}
