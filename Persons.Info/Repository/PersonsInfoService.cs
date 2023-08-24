using Microsoft.EntityFrameworkCore;
using PersonDatabase.PostgresContext;
using Persons.Entities;
using Persons.Info.Interface;

namespace Persons.Info.Repository
{
    public class PersonsInfoService : IPersonsInfo
    {
        private readonly PostgresDbContext _context;
        public PersonsInfoService(PostgresDbContext postgresContext)
        {
            _context = postgresContext ?? throw new ArgumentException(nameof(postgresContext));
        }

        public async Task CreateUser(PersonsEntity personsEntity)
        {
            _context.Add(personsEntity);
        }

        public async Task<IEnumerable<PersonsEntity>> GetAllUsersAsync()
        {
            return await _context.PersonsInfo.OrderBy(_ => _.UserId).ToListAsync();
        }

        public async Task<PersonsEntity?> GetUserInfoByIdAsync(int id)
        {
            return await _context.PersonsInfo.Where(_ => _.UserId == id).FirstOrDefaultAsync();
        }

        public Task UpdateUserAsync(PersonsEntity personsEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAsync(PersonsEntity personsEntity)
        {
            _context.PersonsInfo.Remove(personsEntity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
