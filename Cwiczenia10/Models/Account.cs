using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

[Table(("Accounts"))]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int PkAccount { get; set; }
    [Column("first_name")]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    [Column("last_name")]
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    [Column("email")]
    [MaxLength(80)]
    [Required]
    public string Email { get; set; }
    [Column("phone")]
    [MaxLength(9)]
    public string? Phone { get; set; }
    
    
    public int FkRole { get; set; }
    [ForeignKey("FkRole")]
    public Role Role { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}