namespace Core.Models;

public class Warning
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string Message { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}