//-------------------------------------------------------------------------------
// <copyright file="FuncProviderTests.cs" company="Ninject Project Contributors">
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
    using System.Linq;

    using FluentAssertions;

    using Moq;

    using Ninject.Activation;
    using Ninject.Syntax;

    using Xunit;

    public class FuncProviderTests
    {
        private readonly Mock<IFunctionFactory> funcFactoryMock;

        private readonly FuncProvider testee;

        private readonly IResolutionRoot resolutionRoot;

        public FuncProviderTests()
        {
            this.funcFactoryMock = new Mock<IFunctionFactory>();
            this.resolutionRoot = new Mock<IResolutionRoot>().Object;
            this.testee = new FuncProvider(this.funcFactoryMock.Object, this.resolutionRoot);
        } 

        [Fact]
        public void Create()
        {
            var expectedResult = new Func<int, string>(i => string.Empty);
            var genericArguments = new[] { typeof(int), typeof(string) };
            var context = CreateContext(genericArguments);
            var methodInfo = typeof(IFunctionFactory).GetMethods().Single(mi => mi.GetGenericArguments().Length == 2);

            this.funcFactoryMock.Setup(funcFactory => funcFactory.GetMethodInfo(2)).Returns(methodInfo);
            this.funcFactoryMock.Setup(funcFactory => funcFactory.Create<int, string>(this.resolutionRoot)).Returns(expectedResult);

            var result = this.testee.Create(context);

            result.Should().Be(expectedResult);
        }

        private static IContext CreateContext(Type[] genericArguments)
        {
            var contextMock = new Mock<IContext>();
            contextMock.SetupGet(context => context.GenericArguments).Returns(genericArguments);
            return contextMock.Object;
        }
    }
}
#endif