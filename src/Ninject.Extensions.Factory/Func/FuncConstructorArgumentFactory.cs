// -------------------------------------------------------------------------------------------------
// <copyright file="FuncConstructorArgumentFactory.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Extensions.Factory
{
    using System;

    /// <summary>
    /// Factory for creating <see cref="FuncConstructorArgument"/> instances.
    /// </summary>
    public static class FuncConstructorArgumentFactory
    {
        /// <summary>
        /// Creates instances of <see cref="FuncConstructorArgument"/>.
        /// </summary>
        /// <param name="typeArgument">The type of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <returns>The newly created <see cref="FuncConstructorArgument"/>.</returns>
         public static FuncConstructorArgument CreateFuncConstructorArgument(Type typeArgument, object value)
         {
             return new FuncConstructorArgument(typeArgument, value, new ArgumentPositionCalculator());
         }
    }
}