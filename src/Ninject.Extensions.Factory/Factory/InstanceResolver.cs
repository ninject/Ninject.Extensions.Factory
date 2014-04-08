//-------------------------------------------------------------------------------
// <copyright file="InstanceResolver.cs" company="Ninject Project Contributors">
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

namespace Ninject.Extensions.Factory.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Parameters;
    using Ninject.Planning.Bindings;
    using Ninject.Syntax;

    /// <summary>
    /// Resolves instances from the kernel.
    /// </summary>
    public class InstanceResolver : IInstanceResolver
    {
        /// <summary>
        /// The resolution root that is used to get new instances.
        /// </summary>
        private readonly IResolutionRoot resolutionRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceResolver"/> class.
        /// </summary>
        /// <param name="resolutionRoot">The resolution root that is used to get new instances.</param>
        public InstanceResolver(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        /// <summary>
        /// Gets an instance of the specified type.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The parameters that are passed to the request.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        public object Get(Type type, string name, Func<IBindingMetadata, bool> constraint, IParameter[] parameters, bool fallback)
        {
            if (fallback && constraint != null)
            {
                return this.resolutionRoot.TryGet(type, constraint, parameters) ??
                       this.Get(type, name, null, parameters, name != null);
            }

            if (fallback && name != null)
            {
                return this.resolutionRoot.TryGet(type, name, parameters) ??
                       this.Get(type, null, null, parameters, true);
            }

            return constraint == null
                       ? name == null && !fallback
                             ? this.resolutionRoot.Get(type, parameters)
                             : this.resolutionRoot.Get(type, name, parameters)
                       : this.resolutionRoot.Get(type, constraint, parameters);
        }

        /// <summary>
        /// Gets all instances of the specified type as list.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The parameters that are passed to the request.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        public object GetAllAsList(Type type, string name, Func<IBindingMetadata, bool> constraint, IParameter[] parameters, bool fallback)
        {
            var listType = typeof(List<>).MakeGenericType(type);
            var list = listType.GetConstructor(new Type[0]).Invoke(new object[0]);
            var addMethod = listType.GetMethod("Add");

            var values = this.GetAll(type, name, constraint, parameters, fallback);

            foreach (var value in values)
            {
                addMethod.Invoke(list, new[] { value });
            }

            return list;
        }

        /// <summary>
        /// Gets all instances of the specified type as array.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The parameters that are passed to the request.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>An instance of the specified type.</returns>
        public object GetAllAsArray(Type type, string name, Func<IBindingMetadata, bool> constraint, IParameter[] parameters, bool fallback)
        {
            var list = this.GetAllAsList(type, name, constraint, parameters, fallback);
            return typeof(Enumerable)
                .GetMethod("ToArray")
                .MakeGenericMethod(type)
                .Invoke(null, new[] { list });
        }

        /// <summary>
        /// Gets all instances that match the specified parameters.
        /// </summary>
        /// <param name="type">The type of the instance.</param>
        /// <param name="name">The name of the binding to use. If null the name is not used.</param>
        /// <param name="constraint">The constraint for the bindings. If null the constraint is not used.</param>
        /// <param name="parameters">The parameters that are passed to the request.</param>
        /// <param name="fallback">if set to <c>true</c> the request falls back to requesting instances without
        /// name or constraint if no one can received otherwise.</param>
        /// <returns>All instances of the specified type.</returns>
        private IEnumerable<object> GetAll(Type type, string name, Func<IBindingMetadata, bool> constraint, IParameter[] parameters, bool fallback)
        {
            if (fallback && constraint != null)
            {
                var result = this.resolutionRoot.GetAll(type, constraint, parameters);
                return result.Any() ? result : this.GetAll(type, name, null, parameters, true);
            }

            if (fallback && name != null)
            {
                var result = this.resolutionRoot.GetAll(type, name, parameters);
                return result.Any() ? result : this.GetAll(type, null, null, parameters, true);
            }

            return constraint == null
                       ? name == null
                             ? this.resolutionRoot.GetAll(type, parameters)
                             : this.resolutionRoot.GetAll(type, name, parameters)
                       : this.resolutionRoot.GetAll(type, constraint, parameters);
        }
    }
}