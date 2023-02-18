using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("player_model")]
public class PlayerModel
{
    [Key]
    [Column("uid", TypeName = "varchar(100)")]
    public string Uid { get; set; }
    
    [Column("score")]
    public int Score { get; set; }
}