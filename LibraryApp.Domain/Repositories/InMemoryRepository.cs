using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain.Repositories
{
    public class InMemoryRepository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly List<T> _items = new();
        public async Task AddAsync(T entity)
        {
            await Task.Run(() => _items.Add(entity));
        }

        public async Task DeleteAsync(Guid id)
        {
            await Task.Run(() =>
            {
                var item = _items.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    _items.Remove(item);
                }
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var items = await Task.Run(() => _items.ToList());
            return items;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var item = await Task.Run(()=>_items.FirstOrDefault(i => i.Id == id));
            if (item != null)
            {
                return item;
            }
            return item;
        }

        public async Task UpdateAsync(T entity)
        {
            var existingItem = await Task.Run(() => _items.FirstOrDefault(i => i.Id == entity.Id));
            if (existingItem != null)
            {
                var index = _items.IndexOf(existingItem);
                _items[index] = entity;
            }
        }
    }
}
