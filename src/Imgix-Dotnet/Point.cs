using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Imgix_Dotnet
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point SetX(int x)
            => new Point(x, Y);

        public Point SetY(int y)
            => new Point(X, y);
    }
}