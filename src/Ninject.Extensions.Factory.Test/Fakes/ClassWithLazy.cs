namespace Ninject.Tests.Integration
{
    using System;

    using Ninject.Tests.Fakes;

    public class ClassWithLazy
    {
        private readonly Lazy<IWeapon> lazyWeapon;

        public ClassWithLazy(Lazy<IWeapon> lazyWeapon)
        {
            this.lazyWeapon = lazyWeapon;
        }

        public IWeapon GetWeapon()
        {
            return this.lazyWeapon.Value;
        }
    }
}