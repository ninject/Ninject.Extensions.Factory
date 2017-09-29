//-------------------------------------------------------------------------------
// <copyright file="StandardInstanceProviderTests.cs" company="Ninject Project Contributors">
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
    using System.Reflection;

    using FluentAssertions;

    using Moq;

    using Ninject.Extensions.Factory.Factory;
    using Ninject.Extensions.Factory.Fakes;
    using Ninject.Parameters;

    using Xunit;
    using Xunit.Extensions;

    public class StandardInstanceProviderTests
    {
        private readonly Func<Planning.Bindings.IBindingMetadata, bool> constraint;
        private readonly string name;
        private readonly IConstructorArgument[] constructorArguments;
        private readonly object[] arguments;

        private readonly TestableStandardInstanceProvider testee;

        private readonly MethodInfo methodInfo;

        public StandardInstanceProviderTests()
        {
            this.name = "SomeName";
            this.constructorArguments = new ConstructorArgument[0];
            this.constraint = m => false;
            this.arguments = new object[0];
            this.methodInfo = typeof(IWeaponFactory).GetMethod("CreateWeapon");
            this.testee = new TestableStandardInstanceProvider(this.constraint, this.name, this.constructorArguments, this.arguments)
                {
                    ExpectedMethodInfo = this.methodInfo
                };
        }

        [Fact]
        public void NormalClass()
        {
            var instanceResolverMock = new Mock<IInstanceResolver>();
            var expectedInstance = new object();
            var type = typeof(int);

            this.testee.ReturnedType = type;
            instanceResolverMock
                .Setup(r => r.Get(type, this.name, this.constraint, this.constructorArguments, false))
                .Returns(expectedInstance);

            var instance = this.testee.GetInstance(instanceResolverMock.Object, this.methodInfo, this.arguments);

            instance.Should().BeSameAs(expectedInstance);
        }

        [Theory]
        [InlineData(typeof(IEnumerable<int>), typeof(int))]
        [InlineData(typeof(IList<int>), typeof(int))]
        [InlineData(typeof(List<int>), typeof(int))]
        [InlineData(typeof(ICollection<int>), typeof(int))]
        public void Enumerable(Type type, Type requestedType)
        {
            var instanceResolverMock = new Mock<IInstanceResolver>();
            var expectedInstance = new object();

            this.testee.ReturnedType = type;
            instanceResolverMock
                .Setup(r => r.GetAllAsList(requestedType, this.name, this.constraint, this.constructorArguments, false))
                .Returns(expectedInstance);

            var instance = this.testee.GetInstance(instanceResolverMock.Object, this.methodInfo, this.arguments);

            instance.Should().BeSameAs(expectedInstance);
        }

        [Fact]
        public void Array()
        {
            var instanceResolverMock = new Mock<IInstanceResolver>();
            var expectedInstance = new object();

            this.testee.ReturnedType = typeof(int[]);
            instanceResolverMock
                .Setup(r => r.GetAllAsArray(typeof(int), this.name, this.constraint, this.constructorArguments, false))
                .Returns(expectedInstance);

            var instance = this.testee.GetInstance(instanceResolverMock.Object, this.methodInfo, this.arguments);

            instance.Should().BeSameAs(expectedInstance);
        }
        
        private class TestableStandardInstanceProvider : StandardInstanceProvider
        {
            private readonly Func<Planning.Bindings.IBindingMetadata, bool> constraint;
            private readonly string name;
            private readonly IConstructorArgument[] constructorArguments;
            private readonly object[] expectedArguments;

            public TestableStandardInstanceProvider(
                Func<Planning.Bindings.IBindingMetadata, bool> constraint,
                string name,
                IConstructorArgument[] constructorArguments,
                object[] expectedArguments)
            {
                this.constraint = constraint;
                this.name = name;
                this.constructorArguments = constructorArguments;
                this.expectedArguments = expectedArguments;
            }

            public MethodInfo ExpectedMethodInfo { get; set; }

            public Type ReturnedType { get; set; }

            protected override Func<Planning.Bindings.IBindingMetadata, bool> GetConstraint(
                MethodInfo methodInfo, 
                object[] arguments)
            {
                methodInfo.Should().BeSameAs(this.ExpectedMethodInfo);
                arguments.Should().BeSameAs(this.expectedArguments);
                return this.constraint;
            }

            protected override string GetName(MethodInfo methodInfo, object[] arguments)
            {
                methodInfo.Should().BeSameAs(this.ExpectedMethodInfo);
                arguments.Should().BeSameAs(this.expectedArguments);
                return this.name;
            }

            protected override Type GetType(MethodInfo methodInfo, object[] arguments)
            {
                methodInfo.Should().BeSameAs(this.ExpectedMethodInfo);
                arguments.Should().BeSameAs(this.expectedArguments);
                return this.ReturnedType;
            }

            protected override IConstructorArgument[] GetConstructorArguments(MethodInfo methodInfo, object[] arguments)
            {
                methodInfo.Should().BeSameAs(this.ExpectedMethodInfo);
                arguments.Should().BeSameAs(this.expectedArguments);
                return this.constructorArguments;
            }
        }
    }
}
#endif