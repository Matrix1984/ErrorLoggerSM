namespace ErrorLoggerSM.Domain.Entities;
public class Alert : BaseEntity
{
    public required string Name { get; set; }
    public required ErrorLogType ErrorLogType { get; set; }
    public int NumberOfOccurences { get; set; }
}
