//-------------------------------------------------------------------------------
// <copyright file="IResolutionRootMockExtensions.cs" company="Ninject Project Contributors">
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

#if !NO_MOQ
namespace Ninject.Extensions.Factory.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Bindings;
    using Ninject.Syntax;

    public static class IResolutionRootMockExtensions
    {
        public static void SetupGet<T>(this Mock<IResolutionRoot> resolutionRootMock, T result)
        {
            SetupGet(resolutionRootMock, null, result);
        }

        public static void SetupGetThrowing<T>(this Mock<IResolutionRoot> resolutionRootMock, Func<IBindingMetadata, bool> constraint)
        {
            var request = new Mock<IRequest>().Object;
            resolutionRootMock
                .Setup(resolutionRoot => resolutionRoot.CreateRequest(typeof(T), constraint, It.IsAny<IEnumerable<IParameter>>(), false, true))
                .Returns(request);
            resolutionRootMock.Setup(resolutionRoot => resolutionRoot.Resolve(request)).Throws<ActivationException>();
        }
        
        public static void SetupGet<T>(this Mock<IResolutionRoot> resolutionRootMock, Func<IBindingMetadata, bool> constraint, T result)
        {
            var request = new Mock<IRequest>().Object;
            resolutionRootMock
                .Setup(resolutionRoot => resolutionRoot.CreateRequest(typeof(T), constraint, It.IsAny<IEnumerable<IParameter>>(), false, true))
                .Returns(request);
            resolutionRootMock.Setup(resolutionRoot => resolutionRoot.Resolve(request)).Returns(new[] { (object)result });
        }

        public static void SetupTryGet<T>(this Mock<IResolutionRoot> resolutionRootMock, Func<IBindingMetadata, bool> constraint, T result)
        {
            var request = new Mock<IRequest>().Object;
            resolutionRootMock
                .Setup(resolutionRoot => resolutionRoot.CreateRequest(typeof(T), constraint, It.IsAny<IEnumerable<IParameter>>(), true, true))
                .Returns(request);
            resolutionRootMock.Setup(resolutionRoot => resolutionRoot.Resolve(request)).Returns(new[] { (object)result });
        }

        public static void SetupGetAll<T>(this Mock<IResolutionRoot> resolutionRootMock, IEnumerable<T> result)
        {
            SetupGetAll(resolutionRootMock, null, result);
        }

        public static void SetupGetAllThrowing<T>(this Mock<IResolutionRoot> resolutionRootMock, Func<IBindingMetadata, bool> constraint)
        {
            var request = new Mock<IRequest>().Object;
            resolutionRootMock
                .Setup(resolutionRoot => resolutionRoot.CreateRequest(typeof(T), constraint, It.IsAny<IEnumerable<IParameter>>(), true, false))
                .Returns(request);
            resolutionRootMock.Setup(resolutionRoot => resolutionRoot.Resolve(request)).Throws<ActivationException>();
        }

        public static void SetupGetAll<T>(this Mock<IResolutionRoot> resolutionRootMock, Func<IBindingMetadata, bool> constraint, IEnumerable<T> result)
        {
            var request = new Mock<IRequest>().Object;
            resolutionRootMock
                .Setup(resolutionRoot => resolutionRoot.CreateRequest(typeof(T), constraint, It.IsAny<IEnumerable<IParameter>>(), true, false))
                .Returns(request);
            resolutionRootMock.Setup(resolutionRoot => resolutionRoot.Resolve(request)).Returns(result.Cast<object>());
        }

        public static void VerifyParameters(this Mock<IResolutionRoot> resolutionRootMock, params ConstructorArgument[] arguments)
        {
            resolutionRootMock.Verify(
                resolutionRoot => resolutionRoot.CreateRequest(It.IsAny<Type>(), null, arguments, false, true));
        }
        
        public static void VerifyParameters(this Mock<IResolutionRoot> resolutionRootMock, params object[] parameters)
        {
            var funcConstructorArguments = parameters.Select(p => new FuncConstructorArgument(p.GetType(), p, null));
            resolutionRootMock.Verify(
                resolutionRoot => resolutionRoot.CreateRequest(It.IsAny<Type>(), null, It.Is<IEnumerable<IParameter>>(v => AreEqual(funcConstructorArguments, v)), false, true));
        }

        private static bool AreEqual(IEnumerable<FuncConstructorArgument> expectedFuncConstructorArguments, IEnumerable<IParameter> parameters)
        {
            var parametersEnumerator = parameters.GetEnumerator();
            var funcConstructorArgumentsEnumerator = expectedFuncConstructorArguments.GetEnumerator();

            while (parametersEnumerator.MoveNext())
            {
                var currentParameter = parametersEnumerator.Current as FuncConstructorArgument;
                if (currentParameter == null ||
                    !funcConstructorArgumentsEnumerator.MoveNext() ||
                    currentParameter.ArgumentType != funcConstructorArgumentsEnumerator.Current.ArgumentType ||
                    !currentParameter.GetValue(null, null).Equals(funcConstructorArgumentsEnumerator.Current.GetValue(null, null)))
                {
                    return false;
                }
            }

            return !funcConstructorArgumentsEnumerator.MoveNext();
        }
    }
}
#endif