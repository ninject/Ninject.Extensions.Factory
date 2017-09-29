// -------------------------------------------------------------------------------------------------
// <copyright file="ConstructorInfoExtensions.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extensions for <see cref="ConstructorInfo"/>
    /// </summary>
    public static class ConstructorInfoExtensions
    {
        /// <summary>
        /// Gets the parameters with the specified type.
        /// </summary>
        /// <param name="constructorInfo">The constructor info.</param>
        /// <param name="parameterType">The requested type.</param>
        /// <returns>The parameters with the specified type.</returns>
        public static IEnumerable<ParameterInfo> GetParametersOfType(this ConstructorInfo constructorInfo, Type parameterType)
        {
            return constructorInfo.GetParameters().Where(argument => argument.ParameterType == parameterType);
        }
    }
}