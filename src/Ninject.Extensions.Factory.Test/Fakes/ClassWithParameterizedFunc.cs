namespace Ninject.Tests.Integration
{
    using System;

    public class ClassWithParameterizedFunc
    {
        private readonly Func<string, int, int, ICustomizableWeapon> weaponFactory1;
        private readonly Func<string, int, ICustomizableWeapon> weaponFactory2;

        public ClassWithParameterizedFunc(
            Func<string, int, int, ICustomizableWeapon> weaponFactory1,
            Func<string, int, ICustomizableWeapon> weaponFactory2)
        {
            this.weaponFactory1 = weaponFactory1;
            this.weaponFactory2 = weaponFactory2;
        }

        public ICustomizableWeapon CreateWeapon(string name, int width, int length)
        {
            return this.weaponFactory1(name, width, length);
        }

        public ICustomizableWeapon CreateWeapon(string name, int length)
        {
            return this.weaponFactory2(name, length);
        }
    }
}