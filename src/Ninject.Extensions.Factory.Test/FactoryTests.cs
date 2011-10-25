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

#if !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35 && !MONO
namespace Ninject.Extensions.Factory
{
    using System;
    using System.Linq;

    using FluentAssertions;

    using Ninject.Extensions.Factory.Fakes;

    using Xunit;

    public class FactoryTests : IDisposable
    {
        private readonly StandardKernel kernel;

        public FactoryTests()
        {
            this.kernel = new StandardKernel();
#if NO_ASSEMBLY_SCANNING
            this.kernel.Load(new FuncModule());
#endif        
        }

        public void Dispose()
        {
            this.kernel.Dispose();
        }
 
        [Fact]
        public void SingleBinding()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            
            var weapon = this.kernel.Get<IWeaponFactory>().CreateWeapon();

            weapon.Should().BeOfType<Sword>();
        }

        /*
        [Fact]
        public void NamedBinding()
        {
            this.kernel.Bind<IWeapon>().To<Sword>().Named("Sword");
            this.kernel.Bind<IWeapon>().To<Dagger>().Named("Dagger");
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            
            var weapon = this.kernel.Get<IWeaponFactory>().GetSword();

            weapon.Should().BeOfType<Sword>();
        }*/

        [Fact]
        public void GetEnumerable()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeapon>().To<Dagger>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            
            var weapons = this.kernel.Get<IWeaponFactory>().CreateAllWeaponsEnumerable();

            weapons.Should().HaveCount(2);
            weapons.OfType<Sword>().Should().HaveCount(1);
            weapons.OfType<Dagger>().Should().HaveCount(1);
        }

        [Fact]
        public void GetCollection()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeapon>().To<Dagger>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();

            var weapons = this.kernel.Get<IWeaponFactory>().CreateAllWeaponsCollection();

            weapons.Should().HaveCount(2);
            weapons.OfType<Sword>().Should().HaveCount(1);
            weapons.OfType<Dagger>().Should().HaveCount(1);
        }

        [Fact]
        public void GetIList()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeapon>().To<Dagger>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();

            var weapons = this.kernel.Get<IWeaponFactory>().CreateAllWeaponsIList();

            weapons.Should().HaveCount(2);
            weapons.OfType<Sword>().Should().HaveCount(1);
            weapons.OfType<Dagger>().Should().HaveCount(1);
        }

        [Fact]
        public void GetList()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeapon>().To<Dagger>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();

            var weapons = this.kernel.Get<IWeaponFactory>().CreateAllWeaponsList();

            weapons.Should().HaveCount(2);
            weapons.OfType<Sword>().Should().HaveCount(1);
            weapons.OfType<Dagger>().Should().HaveCount(1);
        }

        [Fact]
        public void GetArray()
        {
            this.kernel.Bind<IWeapon>().To<Sword>();
            this.kernel.Bind<IWeapon>().To<Dagger>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();

            var weapons = this.kernel.Get<IWeaponFactory>().CreateAllWeaponsArray();

            weapons.Should().HaveCount(2);
            weapons.OfType<Sword>().Should().HaveCount(1);
            weapons.OfType<Dagger>().Should().HaveCount(1);
        }
        
        [Fact]
        public void BindToFactoryWithArguments()
        {
            const string Name = "Excalibur";
            const int Width = 34;
            const int Length = 123;

            this.kernel.Bind<ICustomizableWeapon>().To<CustomizableSword>();
            this.kernel.Bind<IWeaponFactory>().ToFactory();
            var weapon = this.kernel.Get<IWeaponFactory>().CreateCustomizableWeapon(Length, Name, Width);

            weapon.Should().BeOfType<CustomizableSword>();
            weapon.Name.Should().Be(Name);
            weapon.Length.Should().Be(Length);
            weapon.Width.Should().Be(Width);
        }
    }
}
#endif