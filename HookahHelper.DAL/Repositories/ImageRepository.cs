using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;


public class ImageRepository: BaseRepository<Image>, IImageRepository
{
    public ImageRepository(ApplicationContext context): base(context)
    {
    }
}