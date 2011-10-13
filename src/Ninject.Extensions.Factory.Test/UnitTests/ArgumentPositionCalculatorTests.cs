//-------------------------------------------------------------------------------
// <copyright file="ArgumentPositionCalculatorTests.cs" company="Ninject Project Contributors">
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
    using System;

    using FluentAssertions;

    using Moq;

    using Ninject.Activation;
    using Ninject.Parameters;
    using Ninject.Planning.Targets;

    using Xunit;
    using Xunit.Extensions;

    public class ArgumentPositionCalculatorTests
    {
        private readonly ArgumentPositionCalculator testee;

        public ArgumentPositionCalculatorTests()
        {
            this.testee = new ArgumentPositionCalculator();
        }

        [Fact]
        public void GetPositionOfFuncConstructorAgumentReturnsMinusOneIfNotFound()
        {
            var funcConstructorArgument = new FuncConstructorArgument(typeof(int), 2, null);
            var context = CreateContext();
            var target = CreateTarget(typeof(int), "x");

            var value = this.testee.GetPositionOfFuncConstructorAgument(funcConstructorArgument, context, target);

            value.Should().Be(-1);
        }

        [Fact]
        public void GetPositionOfFuncConstructorAgumentReturnsZeroIfTheOnlyArgument()
        {
            var funcConstructorArgument = new FuncConstructorArgument(typeof(int), 2, null);
            var context = CreateContext(funcConstructorArgument);
            var target = CreateTarget(typeof(int), "x");

            var value = this.testee.GetPositionOfFuncConstructorAgument(funcConstructorArgument, context, target);

            value.Should().Be(0);
        }

        [Fact]
        public void GetPositionOfFuncConstructorAgumentReturnsPositionOfTheGivenInstanceWithinAllFuncConstructorArgumentsOfTheSameType()
        {
            var funcConstructorArgument = new FuncConstructorArgument(typeof(int), 2, null);
            var context = CreateContext(
                new FuncConstructorArgument(typeof(int), 2, null),
                new FuncConstructorArgument(typeof(int), 2, null),
                new FuncConstructorArgument(typeof(string), "e", null),
                new FuncConstructorArgument(typeof(double), 2, null),
                new FuncConstructorArgument(typeof(int), 2, null),
                funcConstructorArgument,
                new FuncConstructorArgument(typeof(int), 2, null),
                new FuncConstructorArgument(typeof(string), "w", null),
                new FuncConstructorArgument(typeof(int), 2, null));
            var target = CreateTarget(typeof(int), "x");

            var value = this.testee.GetPositionOfFuncConstructorAgument(funcConstructorArgument, context, target);

            value.Should().Be(3);
        }

        [Fact]
        public void GetPositionOfFuncConstructorAgumentIfNoneFuncConstructorArgumentAppliesToTargetMinusOneIsReturned()
        {
            var funcConstructorArgument = new FuncConstructorArgument(typeof(int), 2, null);
            var constsuctorArgumentMock = new Mock<IConstructorArgument>();
            var context = CreateContext(
                funcConstructorArgument,
                constsuctorArgumentMock.Object);
            var target = CreateTarget(typeof(int), "x");
            constsuctorArgumentMock.Setup(constsuctorArgument => constsuctorArgument.AppliesToTarget(context, target)).Returns(true);

            var value = this.testee.GetPositionOfFuncConstructorAgument(funcConstructorArgument, context, target);

            value.Should().Be(-1);
        }

        [Fact]
        public void GetPositionOfFuncConstructorAgumentNotAppliyingNoneFuncConstructorArgumentsAreIgnored()
        {
            var funcConstructorArgument = new FuncConstructorArgument(typeof(int), 2, null);
            var constsuctorArgumentMock = new Mock<IConstructorArgument>();
            var context = CreateContext(
                funcConstructorArgument,
                constsuctorArgumentMock.Object);
            var target = CreateTarget(typeof(int), "x");
            constsuctorArgumentMock.Setup(constsuctorArgument => constsuctorArgument.AppliesToTarget(context, target)).Returns(false);

            var value = this.testee.GetPositionOfFuncConstructorAgument(funcConstructorArgument, context, target);

            value.Should().Be(0);
        }

        [Theory]
        [InlineData("a", -1)]
        [InlineData("s", -1)]
        [InlineData("x", 0)]
        [InlineData("y", 1)]
        [InlineData("z", 2)]
        public void GetTargetPosition(string parameterName, int expectedPosition)
        {
            var context = CreateContext();
            var target = CreateTarget(typeof(int), parameterName);

            var position = this.testee.GetTargetPosition(context, target);

            position.Should().Be(expectedPosition);
        }

        [Fact]
        public void GetTargetPositionWhenOtherConstructorArgumentAppliesToSameParameterReturnsMinusOne()
        {
            var constructorArgumentMock = new Mock<IConstructorArgument>();
            var context = CreateContext(constructorArgumentMock.Object);
            var target = CreateTarget(typeof(int), "y");
            SetupAppliesToTarget(constructorArgumentMock, context, "y");

            var position = this.testee.GetTargetPosition(context, target);

            position.Should().Be(-1);
        }

        [Fact]
        public void GetTargetPositionWhenOtherConstructorArgumentAppliesToOtherParameterThenItIsIgnored()
        {
            var constructorArgumentMock = new Mock<IConstructorArgument>();
            var context = CreateContext(constructorArgumentMock.Object);
            var target = CreateTarget(typeof(int), "y");
            SetupAppliesToTarget(constructorArgumentMock, context, "x");

            var position = this.testee.GetTargetPosition(context, target);

            position.Should().Be(0);
        }
        
        private static void SetupAppliesToTarget(Mock<IConstructorArgument> constructorArgumentMock, IContext context, string parameterName)
        {
            constructorArgumentMock
                .Setup(constructorArgument => constructorArgument.AppliesToTarget(
                    context, 
                    It.Is<ITarget>(t => t.Name == parameterName)))
                .Returns(true);
        }

        private static IContext CreateContext(params IParameter[] parameters)
        {
            var contextMock = new Mock<IContext>();
            contextMock.SetupGet(context => context.Parameters).Returns(parameters);
            return contextMock.Object;
        }

        private static ITarget CreateTarget(Type type, string name)
        {
            var targetMock = new Mock<ITarget>();
            targetMock.SetupGet(target => target.Type).Returns(type);
            targetMock.SetupGet(target => target.Name).Returns(name);
            targetMock.SetupGet(target => target.Member).Returns(typeof(TestClass).GetConstructors()[0]);
            return targetMock.Object;
        }

        public class TestClass
        {
            public TestClass(string s, int x, string t, string u, int y, int z)
            {
            }
        }
    }
}