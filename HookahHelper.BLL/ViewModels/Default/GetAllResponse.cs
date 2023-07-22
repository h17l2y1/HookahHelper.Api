namespace HookahHelper.BLL.ViewModels.Default;

public class GetAllResponse<T>
{
    public GetAllResponse(int total)
    {
        Total = total;
    }
    
    public GetAllResponse()
    {
    }
    
    public int Total { get; set; }
    public IEnumerable<T> List { get; set; }
}