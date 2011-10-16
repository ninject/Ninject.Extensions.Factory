namespace Ninject.Tests.Integration
{
    public class CustomizableSword : ICustomizableWeapon
    {
        public CustomizableSword(string name, int width, int length)
        {
            this.Name = name;
            this.Length = length;
            this.Width = width;
        }

        public string Name { get; set; }

        public int Width { get; private set; }

        public int Length { get; private set; }
    }
}