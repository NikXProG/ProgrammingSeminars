﻿using DryIoc;

using RGU.WebProgramming.Server.Core;
using RGU.WebProgramming.Server.REST.API.Controller;

namespace RGU.WebProgramming.Server.REST.API;

/// <summary>
/// 
/// </summary>
public sealed class ServiceRegistrator:
    IServiceRegistrator
{
    
    #region RGU.WebProgramming.Server.Core.IServiceRegistrator implementation
    
    /// <inheritdoc cref="IServiceRegistrator.Register" />
    public void Register(
        IRegistrator registrator,
        IConfiguration configuration)
    {
        registrator.RegisterMany<ApplicationConfigurator>(Reuse.Singleton);
        registrator.Register<IWebHostConfigurator, WebHostConfigurator>(Reuse.Singleton);

        #region Controllers

        registrator.Register<ControllerAuthors>(Reuse.Singleton);
        registrator.Register<ControllerBooks>(Reuse.Singleton);

        #endregion
        
        // TODO: maybe some other types will be registered
    }
    
    #endregion
    
}