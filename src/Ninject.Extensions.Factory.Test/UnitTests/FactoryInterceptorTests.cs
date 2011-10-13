//-------------------------------------------------------------------------------
// <copyright file="FactoryInterceptorTests.cs" company="Ninject Project Contributors">
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

namespace Ninject.Extensions.Factory.UnitTests
{
    using Castle.DynamicProxy;

    using FluentAssertions;

    using Moq;

    using Ninject.Parameters;
    using Ninject.Syntax;

    using Xunit;

    public class FactoryInterceptorTests
    {
        private readonly Mock<IResolutionRoot> resolutionRootMock;

        private readonly FactoryInterceptor testee;

        public FactoryInterceptorTests()
        {
            this.resolutionRootMock = new Mock<IResolutionRoot>();
            this.testee = new FactoryInterceptor(this.resolutionRootMock.Object);
        }

        [Fact]
        public void Intercept()
        {
            var invocation = this.CreateInvocation("TestMethod", 1, "w");
            this.resolutionRootMock.SetupGet(4);

            this.testee.Intercept(invocation);

            invocation.ReturnValue.Should().Be(4);
            this.resolutionRootMock.VerifyParameters(
                new ConstructorArgument("arg1", 1),
                new ConstructorArgument("arg2", "w"));
        }

        public int TestMethod(int arg1, string arg2)
        {
            return 0;
        }

        private IInvocation CreateInvocation(string methodName, params object[] arguments)
        {
            var invacationMock = new Mock<IInvocation>();
            invacationMock.Setup(invocation => invocation.Method).Returns(this.GetType().GetMethod(methodName));
            invacationMock.SetupProperty(invocation => invocation.ReturnValue);
            invacationMock.Setup(invocation => invocation.Arguments).Returns(arguments);

            return invacationMock.Object;
        }
    }
}