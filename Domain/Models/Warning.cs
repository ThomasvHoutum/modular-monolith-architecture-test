using Domain.Models.Interfaces;

namespace Domain.Models;

public class Warning : IBaseModel
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string Message { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; }
}