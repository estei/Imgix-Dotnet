using System;

namespace Imgix_Dotnet
{
    public struct Rectangle
    {
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public double Ratio(Rectangle target)
        {
            var heightRatio = Convert.ToDouble(target.Height) / Height;
            var widthRatio = Convert.ToDouble(target.Width) / Width;
            return heightRatio <= widthRatio ? heightRatio : widthRatio;
        }

        public Rectangle ResizeToFitWithin(Rectangle target)
        {
            if (target.CanHold(this))
            {
                return new Rectangle(Width, Height);
            }
            var ratio = Ratio(target);
            return Resize(ratio);
        }

        public Rectangle Resize(double ratio)
        {
            var newWidth = (int) (Width * ratio);
            var newHeight = (int) (Height * ratio);
            return new Rectangle(newWidth, newHeight);
        }

        public bool CanHold(Rectangle subject)
            => Width >= subject.Width && Height >= subject.Height;
    }
}