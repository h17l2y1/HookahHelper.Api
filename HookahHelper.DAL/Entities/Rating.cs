namespace HookahHelper.DAL.Entities;

public class Rating: BaseEntity
{
    public float Value { get; set; }
    public int VotedValue { get; set; }
    public int VotedCount { get; set; }
}