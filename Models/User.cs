using System.ComponentModel.DataAnnotations;
using MinimalApiDemo.Data;

namespace MinimalApiDemo.Models;

public record User(
    Guid Id,
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    string Name,
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email must be a valid email address")]
    string Email) : IEntity;
