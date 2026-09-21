using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Interfaces
{
    public interface IMemberRepository: IRepository<Member>
    {
        public Task<IEnumerable<Member>> GetAllMembersAsync();
        public Task<Member> GetMemberByIdAsync(Guid id);
        public Task AddMemberAsync(Member member);
        public Task UpdateMemberAsync(Member member);
        public Task DeleteMemberAsync(Guid id);
    }
}
