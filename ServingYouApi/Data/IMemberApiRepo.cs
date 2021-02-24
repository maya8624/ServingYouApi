using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public interface IMemberApiRepo
    {
        Task PostMemberAsync(Member member);
        
        Task<Member> GetMemberAsync(int id);
        
        Task<IEnumerable<Member>> GetAllAsync();

        Task<bool> SaveChangesAsync();

        Task<Member> GetMemberByEmailAsync(string email);
    }
}
