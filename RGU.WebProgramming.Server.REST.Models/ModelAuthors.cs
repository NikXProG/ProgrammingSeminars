using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RGU.WebProgramming.Server.REST.Models;

/// <summary>
/// 
/// </summary>
[Table("authors")]
public class ModelAuthors
{
    
    #region Properties
    
    [Key]
    [Column("id")]
    public int Id { 
        
        get;
        
        set;
        
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(100)]
    [JsonProperty("last_name")]
    [Column("last_name")]
    public string LastName
    {
        get;

        set;
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("first_name")]
    [JsonProperty("first_name")]
    public string FirstName
    {
        get;

        set;
    }
    
    #endregion
    
    #region System.Object overrides
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        
        return $"\"LastName\": {LastName}, \"FirstName\": {FirstName}";
        
    }

    #endregion
    
}