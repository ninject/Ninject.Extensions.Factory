namespace Ninject.Tests.Integration
{
    using System.Drawing;

    public class CustomizableSword : ICustomizableWeapon
    {
        public CustomizableSword(Color color, int width, int length)
        {
            this.Color = color;
            this.Length = length;
            this.Width = width;
        }

        public string Name
        {
            get
            {
                return "CustomizableSword";
            }
        }

        public Color Color { get; private set; }

        public int Width { get; private set; }

        public int Length { get; private set; }
    }
}