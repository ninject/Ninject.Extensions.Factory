// -------------------------------------------------------------------------------------------------
// <copyright file="TypeMatchingArgumentInheritanceInstanceProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------
namespace Ninject.Extensions.Factory
{
    using System.Reflection;
    using Ninject.Parameters;

    /// <summary>
    /// The type matching implementation of the instance provider using constructor argument inheritance.
    /// </summary>
    public class TypeMatchingArgumentInheritanceInstanceProvider : StandardInstanceProvider
    {
        /// <summary>
        /// Gets the constructor arguments that shall be passed with the instance request. Created constructor arguments are flagged as inherited
        /// and are of type TypeMatchingConstructorArgument
        /// </summary>
        /// <param name="methodInfo">The method info of the method that was called on the factory.</param>
        /// <param name="arguments">The arguments that were passed to the factory.</param>
        /// <returns>The constructor arguments that shall be passed with the instance request.</returns>
        protected override IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
        {
            ParameterInfo[] parameters = methodInfo.GetParameters();
            IConstructorArgument[] constructorArguments = new IConstructorArgument[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                int closure = i;
                constructorArguments[i] = new TypeMatchingConstructorArgument(parameters[i].ParameterType, (context, target) => arguments[closure], true);
            }

            return constructorArguments;
        }
    }
}