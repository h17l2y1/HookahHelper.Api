using Newtonsoft.Json;

namespace HookahHelper.BLL.Models;

public class ResponseRootObject<T>
{
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("success")]
    public bool Success { get; set; }
    [JsonProperty("status")]
    public int Status { get; set; }
}