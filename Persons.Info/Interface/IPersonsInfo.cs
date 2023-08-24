using Persons.Entities;

namespace Persons.Info.Interface
{
    public interface IPersonsInfo
    {
        Task CreateUser(PersonsEntity personsEntity);

        Task UpdateUserAsync(PersonsEntity personsEntity);
        void DeleteUserAsync(PersonsEntity personsEntity);

        Task<IEnumerable<PersonsEntity>> GetAllUsersAsync();
        Task<PersonsEntity?> GetUserInfoByIdAsync(int id);
    }
}
