// -------------------------------------------------------------------------------------------------
// <copyright file="FuncModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System;
    using System.Linq;

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
    using Castle.DynamicProxy;
#endif

    using Ninject.Activation;
    using Ninject.Modules;
    using Ninject.Syntax;

    /// <summary>
    /// Defines the bindings for this extension.
    /// </summary>
    public class FuncModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            if (!this.Kernel.GetBindings(typeof(Func<IContext, IResolutionRoot>)).Any())
            {
                this.Bind<Func<IContext, IResolutionRoot>>().ToMethod(ctx => context => context.Kernel);
            }

            this.Bind<FuncProvider>().ToSelf().InSingletonScope();
            this.Bind<IFunctionFactory>().To<FunctionFactory>();
            this.Bind<IInstanceProvider>().To<StandardInstanceProvider>();
#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
            this.Bind<IInterceptor>().To<FactoryInterceptor>()
                .When(request => typeof(IFactoryProxy).IsAssignableFrom(request.Target.Member.ReflectedType));
#endif

            this.Bind(typeof(Func<>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,>)).ToProvider<FuncProvider>();
#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
            this.Bind(typeof(Func<,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>();
            this.Bind(typeof(Func<,,,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>();
#endif
        }
    }
}