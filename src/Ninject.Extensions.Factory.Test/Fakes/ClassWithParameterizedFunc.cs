namespace Ninject.Tests.Integration
{
    using System;
    using System.Drawing;

    public class ClassWithParameterizedFunc
    {
        private readonly Func<Color, int, int, ICustomizableWeapon> weaponFactory1;
        private readonly Func<Color, int, ICustomizableWeapon> weaponFactory2;

        public ClassWithParameterizedFunc(
            Func<Color, int, int, ICustomizableWeapon> weaponFactory1,
            Func<Color, int, ICustomizableWeapon> weaponFactory2)
        {
            this.weaponFactory1 = weaponFactory1;
            this.weaponFactory2 = weaponFactory2;
        }

        public ICustomizableWeapon CreateWeapon(Color color, int width, int length)
        {
            return this.weaponFactory1(color, width, length);
        }

        public ICustomizableWeapon CreateWeapon(Color color, int length)
        {
            return this.weaponFactory2(color, length);
        }
    }
}