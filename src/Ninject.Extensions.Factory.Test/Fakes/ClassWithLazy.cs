#if !NET_35 && !SILVERLIGHT_30 && !SILVERLIGHT_20 && !WINDOWS_PHONE && !NETCF_35
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
#endif