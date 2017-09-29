// -------------------------------------------------------------------------------------------------
// <copyright file="FactoryInterceptor.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
namespace Ninject.Extensions.Factory
{
    using Castle.DynamicProxy;

    using Ninject.Extensions.Factory.Factory;
    using Ninject.Syntax;

    /// <summary>
    /// Interceptor called by the factory proxies
    /// </summary>
    public class FactoryInterceptor : InstanceResolver, IInterceptor
    {
        /// <summary>
        /// The instance provider.
        /// </summary>
        private readonly IInstanceProvider instanceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryInterceptor"/> class.
        /// </summary>
        /// <param name="resolutionRoot">The resolution root used to create new instances for the factory.</param>
        /// <param name="instanceProvider">The instance provider.</param>
        public FactoryInterceptor(IResolutionRoot resolutionRoot, IInstanceProvider instanceProvider)
            : base(resolutionRoot)
        {
            this.instanceProvider = instanceProvider;
        }

        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            invocation.ReturnValue = this.instanceProvider.GetInstance(this, invocation.Method, invocation.Arguments);
        }
    }
}
#endif