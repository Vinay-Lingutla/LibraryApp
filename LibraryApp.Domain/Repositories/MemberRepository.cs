using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;

namespace LibraryApp.Domain.Repositories
{
    public class MemberRepository:InMemoryRepository<Member>, IMemberRepository
    {
        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }
        public async Task AddMemberAsync(Member member)
        {
            await AddAsync(member);
        }
        public async Task UpdateMemberAsync(Member member)
        {
            await UpdateAsync(member);
        }
        public async Task DeleteMemberAsync(Guid id)
        {
            await DeleteAsync(id);
        }
    }
}
