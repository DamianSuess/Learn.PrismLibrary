using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Prism.Ioc;
using Prism.Modularity;

namespace Learn.PrismWpf.Common
{
  // Based on, ModuleInitializer
  // https://raw.githubusercontent.com/PrismLibrary/Prism/master/src/Wpf/Prism.Wpf/Modularity/ModuleInitializer.cs
  public class RoleModuleInitializer : IModuleInitializer
  {
    private readonly IContainerExtension _containerExtension;

    /// <summary>
    /// Initializes a new instance of <see cref="ModuleInitializer"/>.
    /// </summary>
    /// <param name="containerExtension">The container that will be used to resolve the modules by specifying its type.</param>
    public RoleModuleInitializer(IContainerExtension containerExtension)
    {
      this._containerExtension = containerExtension ?? throw new ArgumentNullException(nameof(containerExtension));
    }

    /// <summary>
    /// Handles any exception occurred in the module Initialization process,
    /// This method can be overridden to provide a different behavior.
    /// </summary>
    /// <param name="moduleInfo">The module metadata where the error happened.</param>
    /// <param name="assemblyName">The assembly name.</param>
    /// <param name="exception">The exception thrown that is the cause of the current error.</param>
    /// <exception cref="ModuleInitializeException"></exception>
    public virtual void HandleModuleInitializationError(IModuleInfo moduleInfo, string assemblyName, Exception exception)
    {
      if (moduleInfo == null)
        throw new ArgumentNullException(nameof(moduleInfo));

      if (exception == null)
        throw new ArgumentNullException(nameof(exception));

      Exception moduleException;

      if (exception is ModuleInitializeException)
      {
        moduleException = exception;
      }
      else
      {
        if (!string.IsNullOrEmpty(assemblyName))
        {
          moduleException = new ModuleInitializeException(moduleInfo.ModuleName, assemblyName, exception.Message, exception);
        }
        else
        {
          moduleException = new ModuleInitializeException(moduleInfo.ModuleName, exception.Message, exception);
        }
      }

      throw moduleException;
    }

    /// <summary>
    /// Initializes the specified module.
    /// </summary>
    /// <param name="moduleInfo">The module to initialize</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Catches Exception to handle any exception thrown during the initialization process with the HandleModuleInitializationError method.")]
    public void Initialize(IModuleInfo moduleInfo)
    {
      if (moduleInfo == null)
        throw new ArgumentNullException(nameof(moduleInfo));

      IModule moduleInstance = null;
      try
      {
        if (ModuleIsInUserRole(moduleInfo))
        {

          moduleInstance = this.CreateModule(moduleInfo);
          if (moduleInstance != null)
          {
            moduleInstance.RegisterTypes(_containerExtension);
            moduleInstance.OnInitialized(_containerExtension);
          }
        }
      }
      catch (Exception ex)
      {
        this.HandleModuleInitializationError(
            moduleInfo,
            moduleInstance?.GetType().Assembly.FullName,
            ex);
      }
    }

    private bool ModuleIsInUserRole(IModuleInfo moduleInfo)
    {
      var inRole = false;

      var roles = GetModuleRoles(moduleInfo);

      foreach(var role in roles)
      {
        if (WindowsPrincipal.Current.IsInRole(role))
        {
          inRole = true;
          break;
        }
      }

      return inRole;
    }

    private IEnumerable<string> GetModuleRoles(IModuleInfo moduleInfo)
    {
      var type = Type.GetType(moduleInfo.ModuleType);
      foreach(var attr in GetCustomAttribute<RolesAttribute>(type))
      {
        return attr.Roles.AsEnumerable();
      }

      return null;
    }

    IEnumerable<T> GetCustomAttribute<T>(Type type)
    {
      return type.GetCustomAttributes(typeof(T), true).OfType<T>();
    }

    /// <summary>
    /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
    /// </summary>
    /// <param name="moduleInfo">The module to create.</param>
    /// <returns>A new instance of the module specified by <paramref name="moduleInfo"/>.</returns>
    protected virtual IModule CreateModule(IModuleInfo moduleInfo)
    {
      if (moduleInfo == null)
        throw new ArgumentNullException(nameof(moduleInfo));

      return this.CreateModule(moduleInfo.ModuleType);
    }

    /// <summary>
    /// Uses the container to resolve a new <see cref="IModule"/> by specifying its <see cref="Type"/>.
    /// </summary>
    /// <param name="typeName">The type name to resolve. This type must implement <see cref="IModule"/>.</param>
    /// <returns>A new instance of <paramref name="typeName"/>.</returns>
    protected virtual IModule CreateModule(string typeName)
    {
      Type moduleType = Type.GetType(typeName);
      //// if (moduleType == null)
      //// {
      ////   throw new ModuleInitializeException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.FailedToGetType, typeName));
      //// }

      return (IModule)_containerExtension.Resolve(moduleType);
    }
  }
}
