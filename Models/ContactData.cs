using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace simple_crud.Models;

public partial class ContactData
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }

    [Required]
    [StringLength(15)]
    [Column("PHONE_NUMBER")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [StringLength(15)]
    [Column("EMAIL")]
    public string Email { get; set; } = null!;

    [ForeignKey("UserId")]
    [JsonIgnore] // Evita referencias circulares
    public virtual Users User { get; set; } = null!;
}

