//-------------------------------------------------------------------------------
// <copyright file="FuncConstructorArgumentTests.cs" company="Ninject Project Contributors">
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
    using FluentAssertions;
    using Moq;

    using Ninject.Activation;
    using Ninject.Planning.Targets;
    using Xunit;

    public class FuncConstructorArgumentTests
    {
        private readonly FuncConstructorArgument testee;

        private readonly Mock<IArgumentPositionCalculator> argumentPositionCalculatorMock;

        public FuncConstructorArgumentTests()
        {
            this.argumentPositionCalculatorMock = new Mock<IArgumentPositionCalculator>();
            this.testee = new FuncConstructorArgument(typeof(int), 4, this.argumentPositionCalculatorMock.Object);
        }
 
        [Fact]
        public void ArgumentType()
        {
            this.testee.ArgumentType.Should().Be(typeof(int));
        }
    
        [Fact]
        public void ShouldInherit()
        {
            this.testee.ShouldInherit.Should().BeFalse();
        }

        [Fact]
        public void GetValue()
        {
            this.testee.GetValue(null, null).Should().Be(4);
        }

        [Fact]
        public void AppliesToTargetWhenOtherTypeReturnsFalse()
        {
            var target = CreateTarget(typeof(string), string.Empty);

            var applies = this.testee.AppliesToTarget(null, target);

            applies.Should().BeFalse();
        }

        [Fact]
        public void AppliesToTargetWhenParameterDoesNotExistReturnsFalse()
        {
            var target = CreateTarget(typeof(int), string.Empty);
            var context = new Mock<IContext>().Object;
            this.SetupGetPositionForCurrentInstance(target, context, -1);

            var applies = this.testee.AppliesToTarget(context, target);

            applies.Should().BeFalse();
        }

        [Fact]
        public void AppliesToTargetWhenPositionDoesNotMatchReturnsFalse()
        {
            var target = CreateTarget(typeof(int), string.Empty);
            var context = new Mock<IContext>().Object;
            this.SetupGetPositionForCurrentInstance(target, context, 1);
            this.SetupGetTargetPosition(target, context, 2);

            var applies = this.testee.AppliesToTarget(context, target);

            applies.Should().BeFalse();
        }

        [Fact]
        public void AppliesToTargetWhenPositionMatchReturnsTrue()
        {
            var target = CreateTarget(typeof(int), string.Empty);
            var context = new Mock<IContext>().Object;
            this.SetupGetPositionForCurrentInstance(target, context, 2);
            this.SetupGetTargetPosition(target, context, 2);

            var applies = this.testee.AppliesToTarget(context, target);

            applies.Should().BeTrue();
        }
        
        private static ITarget CreateTarget(Type type, string name)
        {
            var targetMock = new Mock<ITarget>();
            targetMock.SetupGet(target => target.Type).Returns(type);
            targetMock.SetupGet(target => target.Name).Returns(name);
            return targetMock.Object;
        }

        private void SetupGetTargetPosition(ITarget target, IContext context, int position)
        {
            this.argumentPositionCalculatorMock
                .Setup(argumentPositionCalculator => argumentPositionCalculator.GetTargetPosition(context, target))
                .Returns(position);
        }
        
        private void SetupGetPositionForCurrentInstance(ITarget target, IContext context, int position)
        {
            this.argumentPositionCalculatorMock
                .Setup(argumentPositionCalculator => argumentPositionCalculator.GetPositionOfFuncConstructorAgument(this.testee, context, target))
                .Returns(position);
        }
    }
}
#endif