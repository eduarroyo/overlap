using overlap.lib.Behaviour;

namespace overlap.lib.Figures
{
    public class Sphere : IntersectsFigure<Sphere>, IntersectsFigure<AlignedCube>
    {
        public Point3D Center { get; private set; }
        public double Radius { get; set; }

        public Sphere(Point3D center, double radius)
        {
            ValidateRadius(radius);

            Center = center;
            Radius = radius;
        }

        private void ValidateRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must be a positive number.");
            }
        }

        public Sphere(double centerX, double centerY, double centerZ, double radius) : this(new Point3D(centerX, centerY, centerZ), radius)
        { }

        public bool Intersects(Sphere otherSphere)
        {
            double distanceBetweenCenters = this.Center.DistanceTo(otherSphere.Center);
            double radiusSum = this.Radius + otherSphere.Radius;

            return distanceBetweenCenters <= radiusSum;
        }

        public double IntersectedVolume(Sphere otherSphere)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(AlignedCube otherCube)
        {
            double distanceBetweenCenters = this.Center.DistanceTo(otherCube.Center);
            double radiusPlusHalvedEdge = this.Radius + otherCube.EdgeLength/2;

            return distanceBetweenCenters <= radiusPlusHalvedEdge;
        }

        public double IntersectedVolume(AlignedCube otherCube)
        {
            throw new NotImplementedException();
        }
    }
}