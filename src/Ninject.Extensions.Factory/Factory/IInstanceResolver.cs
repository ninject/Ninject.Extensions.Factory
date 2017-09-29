// -------------------------------------------------------------------------------------------------
// <copyright file="IInstanceResolver.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory.Factory
{
    using System;

    using Ninject.Parameters;
    using Ninject.Planning.Bindings;

    /// <summary>
    /// Resolves instances from the kernel.
    /// </summary>
    public interface IInstanceResolver
    {
        /// <summary>
        /// Gets an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The constructor arguments.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        object Get(
            Type type,
            string name,
            Func<IBindingMetadata, bool> constraint,
            IParameter[] parameters,
            bool fallback);

        /// <summary>
        /// Gets all instances of the specified type as list.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The constructor arguments.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        object GetAllAsList(
            Type type,
            string name,
            Func<IBindingMetadata, bool> constraint,
            IParameter[] parameters,
            bool fallback);

        /// <summary>
        /// Gets all instances of the specified type as array.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The constructor arguments.</param>
        /// <param name="fallback">if set to <c>true</c> the request fallsback to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        object GetAllAsArray(
            Type type,
            string name,
            Func<IBindingMetadata, bool> constraint,
            IParameter[] parameters,
            bool fallback);
    }
}