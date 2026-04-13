using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class ReviewService : IReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;
    private readonly ITobaccoRepository _tobaccoRepository;
    private readonly IMixRepository _mixRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository, ITobaccoRepository tobaccoRepository,
        IMixRepository mixRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
        _tobaccoRepository = tobaccoRepository;
        _mixRepository = mixRepository;
    }

    public async Task Create(CreateReviewRequest request)
    {
        var entity = _mapper.Map<Review>(request);
        await _reviewRepository.Create(entity);
        if (request.TobaccoId != null)
        {
            await UpdateTobacco((int)request.TobaccoId);
        }
        if (request.MixId != null)
        {
            await UpdateMix((int)request.MixId);
        }
    }

    private async Task UpdateTobacco(int tobaccoId)
    {
        double avg = await _reviewRepository.GetAvgTobaccoRating(tobaccoId);
        Tobacco entity = await _tobaccoRepository.FindById(tobaccoId);
        entity.Rating = Math.Round(avg, 2);
        await _tobaccoRepository.Update(entity);
    }

    private async Task UpdateMix(int mixId)
    {
        double avg = await _reviewRepository.GetAvgMixRating(mixId);
        Mix entity = await _mixRepository.FindById(mixId);
        entity.Rating = Math.Round(avg, 2);
        await _mixRepository.Update(entity);
    }
}