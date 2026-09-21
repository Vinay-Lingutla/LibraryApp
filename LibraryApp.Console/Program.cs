using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Services;
using LibraryApp.Domain.Repositories;




namespace LibraryApp.Console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var bookRepository = new BookRepository();
            
            var memberRepository = new MemberRepository();
             
            var loanRepository = new LoanRepository();

            var loanService =  new LoanService(bookRepository, loanRepository, memberRepository);

            var book = new Book(
                             "Clean Code",
                            "Robert Martin",
                            "12345",
                             5);
            var member = new Member(
                            "John Doe",
                            "vinay@gmail.com",
                            "password123");
            await bookRepository.AddBookAsync(book);
            await memberRepository.AddMemberAsync(member);
            await loanService.IssueBookAsync(book.Id, member.Id);
            var members = await loanService.GetMemberLoansAsync();


            var books = await bookRepository.GetAllBooksAsync();
            if (books == null || members == null)
            {
                System.Console.WriteLine("GetAllBooksAsync returned null.");
            }
            else
            {
                
                foreach (var i in books)
                {
                    System.Console.WriteLine($"Book: {i.Title}, Author: {i.Author}, ISBN: {i.ISBN}, Available Copies: {i.AvailableCopies}");
                }
                foreach (var i in members)
                {
                    System.Console.WriteLine($"loan: {i.MemberId}, Book: {i.BookId}, Loan Date: {i.BorrowedDate}, Due Date: {i.ReturnDate}");
                }
            }

        }

    }
}
