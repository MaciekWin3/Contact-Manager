using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface IContactsRepository
    {
        Task AddAsync(Contact contact);
        Task DeleteAsync(Contact contact);
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetAsync(int id);
        Task UpdateAsync(Contact contact);
    }
}