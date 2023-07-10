namespace HookahHelper.BLL.ViewModels.Default;

public class GetAllResponse<T>
{
    public int TotalPages { get; set; }
    public IEnumerable<T> List { get; set; } = null!;
}