namespace Ninject.Extensions.Factory.Fakes
{
    using Ninject.Tests.Fakes;

    public class Dagger : IWeapon
    {
        public string Name
        {
            get
            {
                return "Dagger";
            }
        }
    }
}