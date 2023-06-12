namespace overlap.lib.Figures
{
    public class Point3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double DistanceTo(Point3D point) => Math.Sqrt(
                                        Math.Pow(this.X - point.X, 2)
                                        + Math.Pow(this.Y - point.Y, 2)
                                        + Math.Pow(this.Z - point.Z, 2));
    }
}