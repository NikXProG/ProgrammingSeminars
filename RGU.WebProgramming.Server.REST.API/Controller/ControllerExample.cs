﻿using Microsoft.AspNetCore.Mvc;

using RGU.WebProgramming.Server.REST.Models;
using Microsoft.AspNetCore.Mvc;
using RGU.WebProgramming.Server.DbContext;


namespace RGU.WebProgramming.Server.REST.API.Controller;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/controller_example")]
[Produces("application/json")]
public sealed class ControllerExample:
    ControllerBase
{
    
    #region Fields
    
    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<ControllerExample> _logger;
    private readonly ApplicationDbContext _context;
    
    #endregion
    
    #region Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ControllerExample(
        ApplicationDbContext context, 
        ILogger<ControllerExample> logger)
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
    [HttpGet("method_example_get")]
    public async Task<IActionResult> MethodExampleGetAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation($"Got GET request");

            //

            return StatusCode(StatusCodes.Status200OK);
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
    /// <param name="modelExampleInstance"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("method_example_post")]
    public async Task<IActionResult> MethodExamplePostAsync(
        [FromBody] ModelExample modelExampleInstance,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation($"Got request body: {modelExampleInstance}");
            // _context.ModelExamples.Add(modelExampleInstance);
            //
            // await _context.SaveChangesAsync();
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