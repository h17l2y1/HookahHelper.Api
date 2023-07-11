using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class CountryRepository: BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationContext context): base(context)
    {
    }
}