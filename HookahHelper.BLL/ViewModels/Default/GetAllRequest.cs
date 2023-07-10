namespace HookahHelper.BLL.ViewModels.Default;

public class GetAllRequest
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 100;
}