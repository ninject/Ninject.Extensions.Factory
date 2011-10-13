//-------------------------------------------------------------------------------
// <copyright file="FactoryTests.cs" company="Ninject Project Contributors">
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

namespace Ninject.Extensions.Factory
{
    using System;
    using System.Drawing;

    using FluentAssertions;

    using Ninject.Extensions.Factory.Fakes;
    using Ninject.Tests.Fakes;
    using Ninject.Tests.Integration;

    using Xunit;

    public class FactoryTests : IDisposable
    {
        private readonly StandardKernel kernel;

        public FactoryTests()
        {
            this.kernel = new StandardKernel();
        }

        public void Dispose()
        {
            this.kernel.Dispose();
        }
        
        [Fact]
        public void BindToFactory()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            var weapon = this.kernel.Get<IWeaponFactory>().CreateWeapon();

            weapon.Should().BeOfType<Sword>();
        }

        [Fact]
        public void BindToFactoryWithArguments()
        {
            Color color = Color.BlueViolet;
            const int Width = 34;
            const int Length = 123;

            this.kernel.Bind<ICustomizableWeapon>().To<CustomizableSword>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            var weapon = this.kernel.Get<IWeaponFactory>().CreateCustomizableWeapon(Length, color, Width);

            weapon.Should().BeOfType<CustomizableSword>();
            weapon.Color.Should().Be(color);
            weapon.Length.Should().Be(Length);
            weapon.Width.Should().Be(Width);
        }
    }
}