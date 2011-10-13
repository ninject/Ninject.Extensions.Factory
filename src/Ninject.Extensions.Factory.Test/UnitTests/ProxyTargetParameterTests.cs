//-------------------------------------------------------------------------------
// <copyright file="ProxyTargetParameterTests.cs" company="Ninject Project Contributors">
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
    using FluentAssertions;

    using Moq;

    using Ninject.Activation;
    using Ninject.Planning.Targets;
    using Ninject.Syntax;

    using Xunit;

    public class ProxyTargetParameterTests
    {
        private readonly ProxyTargetParameter testee;

        public ProxyTargetParameterTests()
        {
            this.testee = new ProxyTargetParameter();
        } 

        [Fact]
        public void ParemeterIsNotInherited()
        {
            this.testee.ShouldInherit.Should().BeFalse();
        }

        [Fact]
        public void ParemeterValueIsNull()
        {
            var context = new Mock<IContext>().Object;
            var target = new Mock<ITarget>().Object;

            this.testee.GetValue(context, target).Should().BeNull();
        }

        [Fact]
        public void ParemeterAppliesToObjectTarget()
        {
            var targetMock = new Mock<ITarget>();
            targetMock.SetupGet(target => target.Type).Returns(typeof(object));

            var applies = this.testee.AppliesToTarget(null, targetMock.Object);

            applies.Should().BeTrue();
        }

        [Fact]
        public void ParemeterAppliesNotToIResolutionRootTarget()
        {
            var targetMock = new Mock<ITarget>();
            targetMock.SetupGet(target => target.Type).Returns(typeof(IResolutionRoot));

            var applies = this.testee.AppliesToTarget(null, targetMock.Object);

            applies.Should().BeFalse();
        }
    }
}