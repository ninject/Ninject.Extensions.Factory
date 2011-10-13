namespace Ninject.Tests.Integration
{
    using System.Drawing;

    using Ninject.Tests.Fakes;

    public interface ICustomizableWeapon : IWeapon
    {
        Color Color { get; }

        int Width { get; }

        int Length { get; }            
    }
}