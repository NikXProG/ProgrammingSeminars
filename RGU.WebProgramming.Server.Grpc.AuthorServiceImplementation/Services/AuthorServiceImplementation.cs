using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;
using RGU.WebProgramming.Domain.Converters;
using RGU.WebProgramming.Domain.Models;
using RGU.WebProgramming.Grpc;
using RGU.WebProgramming.Server.Grpc.MyFirstServiceImplementation.Settings;
using AuthorModel = RGU.WebProgramming.Grpc.AuthorModel;
using Empty = Google.Protobuf.WellKnownTypes.Empty;

namespace RGU.WebProgramming.Server.Grpc.MyFirstServiceImplementation.Services;

/// <summary>
/// 
/// </summary>
public sealed class AuthorServiceImplementation:
    AuthorService.AuthorServiceBase
{
    
    #region Fields
    
    /// <summary>
    /// 
    /// </summary>
    private readonly IOptions<MyFirstServiceImplementationSettings> _options;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<AuthorServiceImplementation>? _logger;
    private readonly ApplicationDbContext  _dbContext;
    
    /// <summary>
    /// 
    /// </summary>
    private int _value = 0;
    
    #endregion
    
    #region Constructors
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public  AuthorServiceImplementation(
        IOptions<MyFirstServiceImplementationSettings> options,
        ILogger< AuthorServiceImplementation>? logger,
        ApplicationDbContext  dbContext)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _logger = logger;
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    #endregion
    
    #region RGU.WebProgramming.Grpc.MyFirstService.MyFirstServiceBase overrides
    
    /// <inheritdoc cref="MyFirstService.MyFirstServiceBase.MyFirstRPC" />
    // public override Task<AuthorModel> MyFirstRPC(
    //     Empty request,
    //     ServerCallContext context)
    // {
    //     _logger?.LogDebug($"{nameof(MyFirstRPC)} request execution started");
    //     
    //     try
    //     {
    //         ++_value;
    //         
    //         var responseTask = Task.FromResult(new Domain.Models.MyFirstModel
    //         {
    //             Value = _value
    //         }.Convert());
    //         
    //         _logger?.LogDebug($"{nameof(MyFirstRPC)} request execution succeeded.");
    //
    //         return responseTask;
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger?.LogError($"Failed to execute {nameof(MyFirstRPC)} request");
    //         
    //         return Task.FromResult(new MyFirstModel
    //         {
    //             Value = 0
    //         });
    //     }
    // }
    
    public override async Task<AuthorModel> GetAuthors(
        Empty request, 
        ServerCallContext context)
    {
        _logger?.LogDebug($"{nameof(GetAuthors)} request execution started");
            
        try
        {

            var authors = await _dbContext.Authors.ToListAsync(); // Извлекаем авторов из базы данных

            var authorsList = new AuthorsList(); // gRPC-ответ

            foreach (var author in authors)
            {
                Console.WriteLine(authors);
            }

            _logger?.LogDebug($"{nameof(GetAuthors)} request execution succeeded");
            return new AuthorModel();
        }
        catch (Exception ex)
        {
            _logger?.LogError($"Failed to execute {nameof(GetAuthors)} request: {ex.Message}");


        }
    }
    
    #endregion
    
}

