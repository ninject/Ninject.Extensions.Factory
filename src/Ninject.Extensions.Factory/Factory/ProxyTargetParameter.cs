// -------------------------------------------------------------------------------------------------
// <copyright file="ProxyTargetParameter.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2017 Ninject Project Contributors
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// </copyright>
// -------------------------------------------------------------------------------------------------

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
namespace Ninject.Extensions.Factory
{
    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;

    /// <summary>
    /// Used to define that the target parameter of the factory interception is <c>null</c>.
    /// </summary>
    public class ProxyTargetParameter : Parameter, IConstructorArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyTargetParameter"/> class.
        /// </summary>
        public ProxyTargetParameter()
            : base("ProxyTargetParameter", (object)null, false)
        {
        }

        /// <summary>
        /// Determines if the parameter applies to the given target.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="target">The target.</param>
        /// <returns>
        /// True if the parameter applies in the specified context to the specified target.
        /// </returns>
        /// <remarks>
        /// Only one parameter may return <c>true</c>.
        /// </remarks>
        public bool AppliesToTarget(IContext context, ITarget target)
        {
            return target.Type == typeof(object);
        }
    }
}
#endif