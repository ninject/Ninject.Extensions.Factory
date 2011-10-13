namespace Ninject.Tests.Integration
{
    using System;

    using Ninject.Tests.Fakes;

    public class ClassWithFunc
    {
        private readonly Func<IWeapon> weaponFactory;

        public ClassWithFunc(Func<IWeapon> weaponFactory)
        {
            this.weaponFactory = weaponFactory;
        }

        public IWeapon CreateWeapon()
        {
            return this.weaponFactory();
        }
    }
}