using CleanArchitectureTemplate.Domain.Abstractions;

namespace CleanArchitectureTemplate.Domain.Entities;

public class ErrorLog : BaseEntity
{
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
    public string RequestPath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime TimeStamp { get; set; }
}
