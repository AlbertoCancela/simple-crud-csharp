using System.ComponentModel.DataAnnotations;
namespace simple_crud.Models;
public class UserRequest
{
    [Required]
    [StringLength(15)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string LastName { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(15)]
    public string Data { get; set; } = null!;
}

