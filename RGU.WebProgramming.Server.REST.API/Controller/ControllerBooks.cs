namespace RGU.WebProgramming.Server.REST.API.Controller;
using Microsoft.AspNetCore.Mvc;

using RGU.WebProgramming.Server.REST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RGU.WebProgramming.Server.REST.DbContext;

[ApiController]
[Route("api/controller_books")]
[Produces("application/json")]
public class ControllerBooks:
    ControllerBase
{
    
    #region Fields
    
    private readonly ILogger<ControllerBooks> _logger;
    private readonly ApplicationDbContext _context;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControllerBooks(
        ApplicationDbContext context, 
        ILogger<ControllerBooks> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    #endregion

    
    #region  API Methods

    
    [HttpGet("books_get")]
    public async Task<IActionResult> AuthorsGetAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation($"Got GET request");

            var items = await _context.Books.ToListAsync(cancellationToken);
            
            return StatusCode(StatusCodes.Status200OK, items);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpPost("add_book_post")]
    public async Task<IActionResult> AddBookPostAsync(
        [FromBody] ModelBooks modelBooksInstance,
        CancellationToken cancellationToken = default)
    {
        try
        {
            
            _logger.LogInformation($"Got request body: {modelBooksInstance}");
            
            await _context.Books.AddAsync(modelBooksInstance, cancellationToken);
             
            await _context.SaveChangesAsync(cancellationToken);
            
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occured");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

        
    [HttpPost("remove_book_post")]
    public async Task<IActionResult> RemoveBookPostAsync(
        [FromBody] ModelBooks modelBooksInstance,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var books = await _context.Books
                .FirstOrDefaultAsync(a => a.Title == modelBooksInstance.Title &&
                                          a.Edition == modelBooksInstance.Edition &&
                                          a.LibraryLocation == modelBooksInstance.LibraryLocation && 
                                          a.YearPublished == modelBooksInstance.YearPublished &&             
                                          a.PublisherId == modelBooksInstance.PublisherId, 
                    cancellationToken);

            
            if (books == null)
            {
                return NotFound($"Book with  title {modelBooksInstance.Title} not found.");
            }
            
            _logger.LogInformation($"Got request body: {modelBooksInstance}");
            
            _context.Books.Remove(books);
            
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