using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class ContactsRepository : BaseRepository, IContactsRepository
    {
        public ContactsRepository(ApplicationDbContext context) : base(context) { }

        public Task<Contact> GetAsync(int id)
        {
            return context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task AddAsync(Contact contact)
        {
            await context.Contacts.AddAsync(contact);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            context.Contacts.Update(contact);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact contact)
        {
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
        }
    }
}
