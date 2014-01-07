//-------------------------------------------------------------------------------
// <copyright file="TypeMatchingArgumentInheritanceInstanceProvider.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2013 Ninject Project Contributors
//   Authors: Ivan Appert (iappert@gmail.com)
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
