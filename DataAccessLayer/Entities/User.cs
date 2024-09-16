using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class User
{
    [Key] public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Gender { get; set; }
    public string? DoB { get; set; }
    public string? Phone { get; set; }
    public string? Country { get; set; }
}