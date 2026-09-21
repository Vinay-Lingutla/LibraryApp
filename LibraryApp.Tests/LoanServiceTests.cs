using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Exceptions;
using LibraryApp.Domain.Repositories;
using LibraryApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Tests
{
    public class LoanServiceTests
    {
        [Fact]
        public async Task IssueBookAsync_BookAvailable_CreatesLoan()
        {
            //Arrange
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var book = new Book("Test Book", "Test Author", "1234567890", 1);
            var member = new Member("Test Member", "test@email.com", "password");
            await bookRepo.AddBookAsync(book);
            await memberRepo.AddMemberAsync(member);
            //Act
            await loanService.IssueBookAsync(book.Id, member.Id);
            //Assert
            var updatedBook = await bookRepo.GetBookByIdAsync(book.Id);
            Assert.Equal(0, updatedBook.AvailableCopies);
            var loans = await loanRepo.GetAllLoansAsync();
            Assert.Single(loans);
        }
        [Fact]
        public async Task IssueBookAsync_NoCopies_ThrowsBookNotAvailableException()
        {
            //Arrange
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var book = new Book("Test Book", "Test Author", "1234567890", 0);
            var member = new Member("Test Member", "test@gmail", "password");
            await bookRepo.AddBookAsync(book);
            await memberRepo.AddMemberAsync(member);

            //Act & Assert
            await Assert.ThrowsAsync<BookNotAvailableException>(() => loanService.IssueBookAsync(book.Id, member.Id));
        }
        [Fact]
        public async Task IssueBooktAsync_MemberNotFound_ThrowsMemberNotFoundException() 
        {
            //Arrange
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var book = new Book("Test Book", "Test Author", "1234567890", 1);
            await bookRepo.AddBookAsync(book);
            //Act & Assert
            await Assert.ThrowsAsync<MemberNotFoundException>(() => loanService.IssueBookAsync(book.Id, Guid.NewGuid()));


        }
        [Fact]
        public async Task ReturnBookAsync_validLoan_ReturnsBook()
        {
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var book = new Book("Test Book", "Test Author", "1234567890", 1);
            var member = new Member("Test Member", "test@gmail", "password");
            await bookRepo.AddBookAsync(book);
            await memberRepo.AddMemberAsync(member);
            await loanService.IssueBookAsync(book.Id, member.Id);
            //Act& Assert
            await loanService.ReturnBookAsync((await loanRepo.GetAllLoansAsync()).First().Id);
            var updatedBook = await bookRepo.GetBookByIdAsync(book.Id);
            //Assert
            Assert.Equal(1, updatedBook.AvailableCopies);

        }
        [Fact]
        public async Task ReturnBookAsync_InvalidLoan_throwsLoanNotFoundException()
        {
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var loans = await loanRepo.GetAllLoansAsync();
            foreach(var loan in loans)
            {
                await loanRepo.DeleteLoanAsync(loan.Id);
            }
            //Act & Assert
            await Assert.ThrowsAsync<LoanNotFoundException>(() => loanService.ReturnBookAsync(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetOverDueLoansAsync_ReturnOnlyOverdueLoans()
        {
            var bookRepo = new BookRepository();
            var memberRepo = new MemberRepository();
            var loanRepo = new LoanRepository();
            var loanService = new LoanService(bookRepo, loanRepo, memberRepo);
            var book = new Book("Test Book", "Test Author", "1234567890", 1);
            var member = new Member("Test Member", "test@gmail", "password");
            await bookRepo.AddBookAsync(book);
            await memberRepo.AddMemberAsync(member);
            await loanService.IssueBookAsync(book.Id, member.Id);
            var loan = (await loanRepo.GetAllLoansAsync()).First();
            loan.BorrowedDate = DateTime.Now.AddDays(-15);
            //Act
            var OverDueLoans = await loanService.GetAllOverDueLoansAsync();
            //Assert
            Assert.Single(OverDueLoans);

        }

    }
}
