namespace overlap.lib
{
    public class AlignedCube : Strategy_IntersectsFigure<AlignedCube>
    {
        public Point3D Center { get; private set; }
        public double EdgeLength { get; set; }

        public AlignedCube(Point3D center, double edgeLength)
        {
            if(edgeLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Edge's length must be a possitive number.");
            }

            this.Center = center;
            this.EdgeLength = edgeLength;
        }

        public AlignedCube(double centerX, double centerY, double centerZ, double edgeLength): this(new Point3D(centerX, centerY, centerZ), edgeLength)
        {

        }

        public bool intersects(AlignedCube figure)
        {
            double distanceBetweenCenters = EuclideanDistance(this.Center, figure.Center);
            double edgesSumHalved = (this.EdgeLength + figure.EdgeLength) / 2;

            return distanceBetweenCenters <= edgesSumHalved;
        }

        double EuclideanDistance(Point3D pointA, Point3D pointB)=> Math.Sqrt(
                                    Math.Pow(pointA.X - pointB.X, 2)
                                    + Math.Pow(pointA.Y - pointB.Y, 2)
                                    + Math.Pow(pointA.Z - pointB.Z, 2));

        public double intersectedVolume(AlignedCube figure)
        {
            throw new NotImplementedException();
        }

    }
}