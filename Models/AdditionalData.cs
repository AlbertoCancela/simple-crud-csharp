using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace simple_crud.Models;
public partial class AdditionalData
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("USER_ID")]
    public int UserId { get; set; }

    [StringLength(15)]
    [Column("USER_DATA")]
    public string? UserData { get; set; }  

    [ForeignKey("UserId")]
    [JsonIgnore]
    public virtual Users User { get; set; }
}

