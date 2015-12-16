using System;

namespace Imgix_Dotnet
{
    /// <summary>
    /// A rectangle represented by a Width and a Height
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// The width of the rectangle
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// The height of the rectangle
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Initializes a new Rectangle object with a set width and height
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// The ratio between this rectangle and a target rectangle
        /// </summary>
        /// <param name="target">The rectangle to compare to</param>
        /// <returns></returns>
        public double Ratio(Rectangle target)
        {
            var heightRatio = Convert.ToDouble(target.Height) / Height;
            var widthRatio = Convert.ToDouble(target.Width) / Width;
            return heightRatio <= widthRatio ? heightRatio : widthRatio;
        }

        /// <summary>
        /// Resizes this rectangle to fit inside a target rectangle
        /// </summary>
        /// <param name="target">The target rectangle</param>
        /// <returns>A new rectangle that fits within the target rectangle</returns>
        public Rectangle ResizeToFitWithin(Rectangle target)
        {
            if (target.CanHold(this))
            {
                return new Rectangle(Width, Height);
            }
            var ratio = Ratio(target);
            return Resize(ratio);
        }

        /// <summary>
        /// Resizes this rectangle by a ratio
        /// </summary>
        /// <param name="ratio">The ratio to resize the rectangle by</param>
        /// <returns>a new rectangle</returns>
        public Rectangle Resize(double ratio)
        {
            var newWidth = (int) (Width * ratio);
            var newHeight = (int) (Height * ratio);
            return new Rectangle(newWidth, newHeight);
        }

        /// <summary>
        /// Can this rectangle hold the subject rectangle
        /// </summary>
        /// <param name="subject">The rectangle to compare to</param>
        /// <returns></returns>
        public bool CanHold(Rectangle subject)
            => Width >= subject.Width && Height >= subject.Height;
    }
}