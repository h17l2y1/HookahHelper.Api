using AutoMapper;
using HookahHelper.BLL.ViewModels.Comments;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class CommentProfile: Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, GetCommentResponse>();
        CreateMap<CreateCommentRequest, Comment>();
    }
}