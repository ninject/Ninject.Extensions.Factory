// -------------------------------------------------------------------------------------------------
// <copyright file="IFactoryProxy.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
namespace Ninject.Extensions.Factory
{
    /// <summary>
    /// Marker for factory proxies
    /// </summary>
    public interface IFactoryProxy
    {
    }
}
#endif