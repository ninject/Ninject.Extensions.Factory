//-------------------------------------------------------------------------------
// <copyright file="StandardInstanceProviderDefaultImplementationTests.cs" company="Ninject Project Contributors">
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
    using System.Reflection;

    using FluentAssertions;

    using Moq;

    using Ninject.Activation;
    using Ninject.Extensions.Factory.Fakes;
    using Ninject.Parameters;
    using Ninject.Planning.Bindings;
    using Ninject.Planning.Targets;

    using Xunit;

    public class StandardInstanceProviderDefaultImplementationTests
    {
        private readonly TestableStandardInstanceProvider testee;

        public StandardInstanceProviderDefaultImplementationTests()
        {
            this.testee = new TestableStandardInstanceProvider();
        }

        [Fact]
        public void GetTypeShouldBeMethodReturnType()
        {
            var type = this.testee.CallGetType(GetMethod("CreateWeapon"), new object[0]);

            type.Should().Be(typeof(IWeapon));
        }
        
        [Fact]
        public void GetNameForNoneGetMethodShouldBeNull()
        {
            var name = this.testee.CallGetName(GetMethod("CreateWeapon"), new object[0]);

            name.Should().BeNull();
        }

        [Fact]
        public void GetNameForGetMethodShouldMethodName()
        {
            var name = this.testee.CallGetName(GetMethod("GetSword"), new object[0]);

            name.Should().Be("Sword");
        }

        [Fact]
        public void GetConstructorArgumentsShouldReturnEmptyArrayIsMethodHasNoParameters()
        {
            var type = this.testee.CallGetConstructorArguments(GetMethod("CreateWeapon"), new object[0]);

            type.Should().HaveCount(0);
        }

        [Fact]
        public void GetConstructorArgumentsReturnsConstructorArgumentForeachMethodArgument()
        {
            var context = new Mock<IContext>().Object;
            var target = new Mock<ITarget>().Object;
            var values = new object[] { 1, "a", 4 };
            var method = typeof(IWeaponFactory).GetMethods().First(m => m.GetParameters().Length == 3);
            var type = this.testee.CallGetConstructorArguments(method, values);

            type.Should().HaveCount(3);
            type[0].Name.Should().Be("length");
            type[1].Name.Should().Be("name");
            type[2].Name.Should().Be("width");

            type[0].GetValue(context, target).Should().Be(values[0]);
            type[1].GetValue(context, target).Should().Be(values[1]);
            type[2].GetValue(context, target).Should().Be(values[2]);
        }
        
        [Fact]
        public void GetConstraintShouldBeNull()
        {
            var constraint = this.testee.CallGetConstraint(GetMethod("CreateWeapon"), new object[0]);

            constraint.Should().BeNull();
        }

        private static MethodInfo GetMethod(string methodName)
        {
            return typeof(IWeaponFactory).GetMethod(methodName);
        }

        public class TestableStandardInstanceProvider : StandardInstanceProvider
        {
            public Func<IBindingMetadata, bool> CallGetConstraint(MethodInfo methodInfo, object[] arguments)
            {
                return this.GetConstraint(methodInfo, arguments);
            }

            public string CallGetName(MethodInfo methodInfo, object[] arguments)
            {
                return this.GetName(methodInfo, arguments);
            }

            public Type CallGetType(MethodInfo methodInfo, object[] arguments)
            {
                return this.GetType(methodInfo, arguments);
            }

            public ConstructorArgument[] CallGetConstructorArguments(MethodInfo methodInfo, object[] arguments)
            {
                return this.GetConstructorArguments(methodInfo, arguments);
            }
        }
    }
}
#endif