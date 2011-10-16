namespace Ninject.Tests.Integration
{
    using Ninject.Tests.Fakes;

    public interface ICustomizableWeapon : IWeapon
    {
        int Width { get; }

        int Length { get; }            
    }
}