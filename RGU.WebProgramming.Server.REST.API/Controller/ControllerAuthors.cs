using Microsoft.AspNetCore.Mvc;

using RGU.WebProgramming.Server.REST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RGU.WebProgramming.Server.REST.DbContext;


namespace RGU.WebProgramming.Server.REST.API.Controller;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/controller_authors")]
[Produces("application/json")]
public sealed class ControllerAuthors:
    ControllerBase
{
    
    #region Fields
    
    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<ControllerAuthors> _logger;
    private readonly ApplicationDbContext _context;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControllerAuthors(
        ApplicationDbContext context, 
        ILogger<ControllerAuthors> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    #endregion
    
    #region API methods
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("authors_get")]
    public async Task<IActionResult> AuthorsGetAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation($"Got GET request");

            var items = await _context.Authors.ToListAsync(cancellationToken);
            
            return StatusCode(StatusCodes.Status200OK, items);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelAuthorsInstance"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("add_author_post")]
    public async Task<IActionResult> AddAuthorPostAsync(
        [FromBody] ModelAuthors modelAuthorsInstance,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation($"Got request body: {modelAuthorsInstance}");
            
            await _context.Authors.AddAsync(modelAuthorsInstance, cancellationToken);
    
            await _context.SaveChangesAsync(cancellationToken);
            
            return StatusCode(StatusCodes.Status201Created, modelAuthorsInstance); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    
    [HttpPost("remove_author_post")]
    public async Task<IActionResult> RemoveAuthorPostAsync(
        [FromBody] ModelAuthors modelAuthorsInstance,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var author = await _context.Authors
                .FirstOrDefaultAsync(a => a.FirstName == modelAuthorsInstance.FirstName &&
                                          a.LastName == modelAuthorsInstance.LastName, 
                    cancellationToken);

            
            if (author == null)
            {
                return NotFound($"Author with full name {modelAuthorsInstance.LastName}" +
                                $" {modelAuthorsInstance.FirstName} not found.");
            }
            
            _logger.LogInformation($"Got request body: {modelAuthorsInstance}");
            
            _context.Authors.Remove(author);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    
    #endregion
    
}