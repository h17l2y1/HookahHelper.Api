using System.ComponentModel.DataAnnotations;

namespace HookahHelper.BLL.ViewModels.TobaccoRating;

public class CreateTobaccoRatingRequest
{
    [Required]
    public required float Value { get; set; }
}