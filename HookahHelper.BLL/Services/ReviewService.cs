using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class ReviewService: IReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }

    public async Task Create(CreateReviewRequest request)
    {
        var entity = _mapper.Map<Review>(request);
        await _reviewRepository.Create(entity);
    }
}