//-------------------------------------------------------------------------------
// <copyright file="InstanceResolverTests.cs" company="Ninject Project Contributors">
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

    using FluentAssertions;

    using Moq;

    using Ninject.Extensions.Factory.Factory;
    using Ninject.Parameters;
    using Ninject.Planning.Bindings;
    using Ninject.Syntax;

    using Xunit;

    public class InstanceResolverTests
    {
        private readonly Mock<IResolutionRoot> resolutionRootMock;

        private readonly InstanceResolver testee;

        private readonly Type type;

        private readonly Func<IBindingMetadata, bool> constraint;

        private readonly ConstructorArgument[] constructorArguments;

        public InstanceResolverTests()
        {
            this.resolutionRootMock = new Mock<IResolutionRoot>();
            this.testee = new InstanceResolver(this.resolutionRootMock.Object);

            this.type = typeof(object);
            this.constraint = metadata => false;
            this.constructorArguments = new ConstructorArgument[0];
        } 

        [Fact]
        public void GetWithNoConstraintAndName()
        {
            var expectedInstance = new object();
            this.resolutionRootMock.SetupGet(expectedInstance);

            var instance = this.testee.Get(this.type, null, null, this.constructorArguments, false);

            instance.Should().BeSameAs(expectedInstance);
        }

        [Fact]
        public void GetWithConstraint()
        {
            var expectedInstance = new object();
            this.resolutionRootMock.SetupGet(this.constraint, expectedInstance);

            var instance = this.testee.Get(this.type, null, this.constraint, this.constructorArguments, false);

            instance.Should().BeSameAs(expectedInstance);
        }
    
        [Fact]
        public void GetWithConstraintWhenFallbackIsTrueThenFallsBackToUnconstraintForNull()
        {
            var expectedInstance = new object();
            this.resolutionRootMock.SetupTryGet(this.constraint, (object)null);
            this.resolutionRootMock.SetupGet(expectedInstance);

            var instance = this.testee.Get(this.type, null, this.constraint, this.constructorArguments, true);

            instance.Should().BeSameAs(expectedInstance);
        }

        [Fact]
        public void GetWithConstraintWhenFallbackIsFalseThenExceptionIsThrown()
        {
            this.resolutionRootMock.SetupGetThrowing<object>(this.constraint);

            Action action = () => this.testee.Get(this.type, null, this.constraint, this.constructorArguments, false);

            action.ShouldThrow<ActivationException>();
        }

        [Fact]
        public void GetAllAsListWithNoConstraintAndName()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(expectedInstance);

            var instance = (List<object>)this.testee.GetAllAsList(this.type, null, null, this.constructorArguments, false);

            instance.Should().ContainInOrder(expectedInstance);
        }

        [Fact]
        public void GetAllAsListWithConstraint()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(this.constraint, expectedInstance);

            var instance = (List<object>)this.testee.GetAllAsList(this.type, null, this.constraint, this.constructorArguments, false);

            instance.Should().ContainInOrder(expectedInstance);
        }

        [Fact]
        public void GetAllAsListWithConstraintWhenFallbackIsTrueThenFallsBackToUnconstraintForNull()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(expectedInstance);
            this.resolutionRootMock.SetupGetAll(this.constraint, Enumerable.Empty<object>());

            var instance = (List<object>)this.testee.GetAllAsList(this.type, null, this.constraint, this.constructorArguments, true);

            instance.Should().ContainInOrder(expectedInstance);
        }

        [Fact]
        public void GetAllAsArrayWithNoConstraintAndName()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(expectedInstance);

            var instance = (object[])this.testee.GetAllAsArray(this.type, null, null, this.constructorArguments, false);

            instance.Should().ContainInOrder(expectedInstance);
        }

        [Fact]
        public void GetAllAsArrayWithConstraint()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(this.constraint, expectedInstance);

            var instance = (object[])this.testee.GetAllAsArray(this.type, null, this.constraint, this.constructorArguments, false);

            instance.Should().ContainInOrder(expectedInstance);
        }

        [Fact]
        public void GetAllAsArrayWithConstraintWhenFallbackIsTrueThenFallsBackToUnconstraintForNull()
        {
            var expectedInstance = new List<object> { new object() };
            this.resolutionRootMock.SetupGetAll(expectedInstance);
            this.resolutionRootMock.SetupGetAll(this.constraint, Enumerable.Empty<object>());

            var instance = (object[])this.testee.GetAllAsArray(this.type, null, this.constraint, this.constructorArguments, true);

            instance.Should().ContainInOrder(expectedInstance);
        }
    }
}
#endif