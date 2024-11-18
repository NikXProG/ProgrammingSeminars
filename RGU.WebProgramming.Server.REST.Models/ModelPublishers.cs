using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RGU.WebProgramming.Server.REST.Models;

[Table("publishers")]
public class ModelPublishers
{

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    [JsonProperty("name")]
    [Column("name")]
    public string Name {
        
        get;
        
        set; 
        
    }

}