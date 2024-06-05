using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cwiczenia10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int PkCategory { get; set; }
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}