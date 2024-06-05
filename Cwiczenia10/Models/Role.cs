using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

[Table(("Role"))]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int PkRole { get; set; }
    [Column("name")]
    public string Name { get; set; }
    
    public ICollection<Account> Accounts { get; set; }
}