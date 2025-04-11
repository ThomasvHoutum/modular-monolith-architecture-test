using Domain.Models.Interfaces;

namespace Domain.Models;

public class User : IBaseModel
{
    public int Id { get; set; }
    
    public string Username { get; set; }
}