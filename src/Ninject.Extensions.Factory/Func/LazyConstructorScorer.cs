// -------------------------------------------------------------------------------------------------
// <copyright file="LazyConstructorScorer.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
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
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return base.Score(context, directive);
            }
        }
    }
}