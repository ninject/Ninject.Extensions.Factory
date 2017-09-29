// -------------------------------------------------------------------------------------------------
// <copyright file="FuncProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System;

    using Ninject.Activation;
    using Ninject.Syntax;

    /// <summary>
    /// Provider for Func's
    /// </summary>
    public class FuncProvider : IProvider
    {
        /// <summary>
        /// The factory to create func instances.
        /// </summary>
        private readonly IFunctionFactory functionFactory;

        /// <summary>
        /// The resolution root used to create new instances.
        /// </summary>
        private readonly Func<IContext, IResolutionRoot> resolutionRootRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="FuncProvider"/> class.
        /// </summary>
        /// <param name="functionFactory">The function factory.</param>
        /// <param name="resolutionRootRetriever">Func to get the resolution root from a context.</param>
        public FuncProvider(IFunctionFactory functionFactory, Func<IContext, IResolutionRoot> resolutionRootRetriever)
        {
            this.functionFactory = functionFactory;
            this.resolutionRootRetriever = resolutionRootRetriever;
        }

        /// <summary>
        /// Gets the type (or prototype) of instances the provider creates.
        /// </summary>
        /// <value>The type (or prototype) of instances the provider creates.</value>
        public Type Type
        {
            get
            {
                return typeof(Func<>);
            }
        }

        /// <summary>
        /// Creates an instance within the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The created instance.</returns>
        public object Create(IContext context)
        {
            var genericArguments = context.GenericArguments;
            var mi = this.functionFactory.GetMethodInfo(genericArguments.Length);
            var createMethod = mi.MakeGenericMethod(genericArguments);
            return createMethod.Invoke(this.functionFactory, new object[] { this.resolutionRootRetriever(context) });
        }
    }
}