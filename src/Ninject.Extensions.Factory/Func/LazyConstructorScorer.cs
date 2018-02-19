// -------------------------------------------------------------------------------------------------
// <copyright file="LazyConstructorScorer.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
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
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System;

    using Ninject.Activation;
    using Ninject.Planning.Directives;
    using Ninject.Selection.Heuristics;

    /// <summary>
    /// Scores constructors by either looking for the existence of an injection marker
    /// attribute, or by counting the number of parameters.
    /// </summary>
    public class LazyConstructorScorer : StandardConstructorScorer
    {
        /// <summary>
        /// Gets the score for the specified constructor.
        /// </summary>
        /// <param name="context">The injection context.</param>
        /// <param name="directive">The constructor.</param>
        /// <returns>The constructor's score.</returns>
        public override int Score(IContext context, ConstructorInjectionDirective directive)
        {
            if (context.Request.Service.IsGenericType &&
                context.Request.Service.GetGenericTypeDefinition() == typeof(Lazy<>))
            {
                if (directive.Constructor.GetParameters().Length == 1 &&
                    directive.Constructor.GetParameters()[0].ParameterType.IsGenericType)
                {
                    var parameterGenericType = directive.Constructor.GetParameters()[0].ParameterType.GetGenericTypeDefinition();
                    if (parameterGenericType == typeof(Func<>)
                        || parameterGenericType == typeof(Func<,>)
                        || parameterGenericType == typeof(Func<,,>)
                        || parameterGenericType == typeof(Func<,,,>)
                        || parameterGenericType == typeof(Func<,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,,,,,>)
                        || parameterGenericType == typeof(Func<,,,,,,,,,,,,,,,,>))
                    {
                        return 1;
                    }
                }

                return 0;
            }
            else
            {
                return base.Score(context, directive);
            }
        }
    }
}