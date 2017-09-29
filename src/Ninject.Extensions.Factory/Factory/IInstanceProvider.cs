// -------------------------------------------------------------------------------------------------
// <copyright file="IInstanceProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System.Reflection;
    using Ninject.Extensions.Factory.Factory;

    /// <summary>
    /// Provides instances to the interceptor.
    /// </summary>
    public interface IInstanceProvider
    {
        /// <summary>
        /// Gets an instance for the specified method and arguments.
        /// </summary>
        /// <param name="instanceResolver">The instance resolver.</param>
        /// <param name="methodInfo">The method info.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The newly created instance.</returns>
        object GetInstance(IInstanceResolver instanceResolver, MethodInfo methodInfo, object[] arguments);
    }
}