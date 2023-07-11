namespace HookahHelper.BLL.ViewModels.Default;

public class GetAllResponse<T>
{
    public GetAllResponse(int total, IEnumerable<T> list)
    {
        Total = total;
        List = list;
    }
    
    public GetAllResponse(int total)
    {
        Total = total;
    }
    
    public int Total { get; set; }
    public IEnumerable<T> List { get; set; }
}