using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace simple_crud.Models;

public partial class Users
{
    public Users()
    {
        CONTACT_DATA = new HashSet<ContactData>();
        ADDITIONAL_DATA = new HashSet<AdditionalData>();    
    }


    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(15)]
    [Column("NAME")]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(15)]
    [Column("LAST_NAME")]
    public string LastName { get; set; } = null!;

    [Column("DATE_CREATION")]
    public DateTime DateCreation { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ContactData> CONTACT_DATA { get; set; }
    public virtual ICollection<AdditionalData> ADDITIONAL_DATA { get; set; } 
}
