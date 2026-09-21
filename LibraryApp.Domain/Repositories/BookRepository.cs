using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Repositories
{
    public class BookRepository: InMemoryRepository<Book>,IBookRepository
    {
        public async Task<Book> GetBookByIsbnAync(string ISBN)
        {
            var book = await Task.Run(() => _items.FirstOrDefault(b => b.ISBN == ISBN));
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ISBN {ISBN} not found.");
            }
            return book;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Book> GetBookByIdAsync(Guid id)
        {
           return await GetByIdAsync(id);
        }
        public async Task AddBookAsync(Book book)
        {
            await AddAsync(book);
        }
        public async Task UpdateBookAsync(Book book)
        {
            await UpdateAsync(book);
        }
        public async Task DeleteBookAsync(Guid id)
        {
            await DeleteAsync(id);
        }

    }
}
