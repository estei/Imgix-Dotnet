namespace Imgix_Dotnet
{
    /// <summary>
    /// Represents a point in a coordinat system
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// The x position
        /// </summary>
        public int X { get; }
        /// <summary>
        /// The y position
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new point with an x and y position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a new point with the same Y position and the supplied X position
        /// </summary>
        /// <param name="x">The X of the new point</param>
        /// <returns>A new point object at new x,Y</returns>
        public Point SetX(int x)
            => new Point(x, Y);

        /// <summary>
        /// Creates a new point with the same X position and the supplied y position
        /// </summary>
        /// <param name="y">The Y of the new point</param>
        /// <returns>A new point object at X,new Y</returns>
        public Point SetY(int y)
            => new Point(X, y);
    }
}