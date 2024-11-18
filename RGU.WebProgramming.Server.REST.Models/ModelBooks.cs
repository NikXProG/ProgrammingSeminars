using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RGU.WebProgramming.Server.REST.Models;
[Table("books")]
public class ModelBooks
{
    #region Properties
    

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    [JsonProperty("title")]
    [Column("title")]
    public string Title { get; set; }

    [Required]
    [JsonProperty("publication_year")]
    [Column("publication_year")]
    public int YearPublished { get; set; }

    [Required]
    [MaxLength(100)]
    [JsonProperty("edition")]
    [Column("edition")]
    public string Edition { get; set; }

    [Required]
    [MaxLength(100)]
    [JsonProperty("library_location")]
    [Column("library_location")]
    public string LibraryLocation { get; set; }

 
    [ForeignKey("PublisherId")]
    [JsonProperty("publisher_id")]
    [Column("publisher_id")]
    public int PublisherId { get; set; }
    
    #endregion
    
}