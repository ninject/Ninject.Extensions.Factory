//-------------------------------------------------------------------------------
// <copyright file="BindToExtensions.cs" company="Ninject Project Contributors">
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
    using Castle.DynamicProxy;

    using Ninject.Syntax;

    /// <summary>
    /// Extension methods for IBindingToSyntax
    /// </summary>
    public static class BindToExtensions
    {
        /// <summary>
        /// Defines that the interface shall be bound to an automatically created factory proxy.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="syntax">The syntax.</param>
        /// <returns>The IBindingWhenInNamedWithOrOnSyntax to configure more things for the binding.</returns>
        public static IBindingWhenInNamedWithOrOnSyntax<TInterface> ToFactory<TInterface>(this IBindingToSyntax<TInterface> syntax)
            where TInterface : class
        {
            var proxy = new ProxyGenerator().ProxyBuilder
                .CreateInterfaceProxyTypeWithoutTarget(typeof(TInterface), new[] { typeof(IFactoryProxy) }, ProxyGenerationOptions.Default);
            var proxy2 = new ProxyGenerator().ProxyBuilder
                .CreateInterfaceProxyTypeWithTargetInterface(typeof(IResolutionRoot), new[] { typeof(TInterface), typeof(IFactoryProxy) }, ProxyGenerationOptions.Default);
            var result = syntax.To(proxy2);
            result.WithParameter(new ProxyTargetParameter());
            return result;
        }
    }
}