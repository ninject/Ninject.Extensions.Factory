//-------------------------------------------------------------------------------
// <copyright file="FuncModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------   

namespace Ninject.Extensions.Factory
{
    using System;

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35 && !MONO
    using Castle.DynamicProxy;
#endif

    using Ninject.Activation;
    using Ninject.Modules;
    using Ninject.Parameters;

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
            this.Bind<FuncProvider>().ToSelf().InSingletonScope();
            this.Bind<IFunctionFactory>().To<FunctionFactory>();
#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35 && !MONO
            this.Bind<IInterceptor>().To<FactoryInterceptor>()
                .When(request => typeof(IFactoryProxy).IsAssignableFrom(request.Target.Member.ReflectedType));
#endif

            this.Bind(typeof(Func<>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
            this.Bind(typeof(Func<,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
            this.Bind(typeof(Func<,,,,,,,,,,,,,,,,>)).ToProvider<FuncProvider>().When(VerifyFactoryFunction);
#endif
        }

        /// <summary>
        /// Verifies that the Func can be resolved and be used as factory Func.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>True if the return value can be resolved.</returns>
        private static bool VerifyFactoryFunction(IRequest request)
        {
            var genericArguments = request.Service.GetGenericArguments();
            var instanceType = genericArguments[genericArguments.Length - 1];
            return request.ParentContext.Kernel.CanResolve(new Request(instanceType, null, new IParameter[0], null, false, true))
                   || TypeIsSelfBindable(instanceType);
        }

        /// <summary>
        /// Checks if the service type is self bindable.
        /// </summary>
        /// <param name="service">The service type.</param>
        /// <returns>True if the service type is self bindable.</returns>
        private static bool TypeIsSelfBindable(Type service)
        {
            return !service.IsInterface && !service.IsAbstract && !service.IsValueType && service != typeof(string) && !service.ContainsGenericParameters;
        }
    }
}