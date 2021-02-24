using Microsoft.EntityFrameworkCore;
using ServingyouApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingyouApi.Data
{
    public class SqlMemberApiRepo : IMemberApiRepo
    {
        private readonly ServingyouApiContext context;

        public SqlMemberApiRepo(ServingyouApiContext context)
        {
            this.context = context;
        }

        public async Task PostMemberAsync(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            await context.Members.AddAsync(member);
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            return await context.Members.ToListAsync();
        }

        public async Task<Member> GetMemberAsync(int id)
        {
            return await context.Members.SingleOrDefaultAsync(b => b.Id == id);            
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        public async Task<Member> GetMemberByEmailAsync(string email)
        {            
            return await context.Members.SingleOrDefaultAsync(m => m.Email == email);
        }
    }
}
