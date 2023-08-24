using AutoMapper;
using Persons.Entities;
using Persons.Info.Model;

namespace Persons.Info.Profiles
{
    internal class PersonsProfile : Profile
    {
        public PersonsProfile()
        {
            CreateMap<PersonsEntity, PersonsInfo>().ReverseMap();
        }
    }
}
