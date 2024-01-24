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
    private readonly ITobaccoRepository _tobaccoRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository, ITobaccoRepository tobaccoRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
        _tobaccoRepository = tobaccoRepository;
    }

    public async Task Create(CreateReviewRequest request)
    {
        var entity = _mapper.Map<Review>(request);
        await _reviewRepository.Create(entity);
        await UpdateTobacco(request.TobaccoId);
    }

    private async Task UpdateTobacco(string tobaccoId)
    {
        double avg = await _reviewRepository.GetAvgRating(tobaccoId);
        Tobacco entity = await _tobaccoRepository.FindById(tobaccoId);
        entity.Rating = Math.Round(avg, 2);
        await _tobaccoRepository.Update(entity);
    }
}