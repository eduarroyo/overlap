using overlap.lib.Behaviour;

namespace overlap.lib.Figures
{
    public class AlignedCube : IntersectsFigure<AlignedCube>, IntersectsFigure<Sphere>
    {
        public Point3D Center { get; private set; }
        public double EdgeLength { get; set; }

        public AlignedEdge EdgeX { get; set; }
        public AlignedEdge EdgeY { get; set; }
        public AlignedEdge EdgeZ { get; set; }


        public AlignedCube(Point3D center, double edgeLength)
        {
            ValidateEdgeLength(edgeLength);

            Center = center;
            EdgeLength = edgeLength;

            double halfEdge = this.EdgeLength / 2D;
            EdgeX = new AlignedEdge(this.Center.X - halfEdge, this.Center.X + halfEdge);
            EdgeY = new AlignedEdge(this.Center.Y - halfEdge, this.Center.Y + halfEdge);
            EdgeZ = new AlignedEdge(this.Center.Z - halfEdge, this.Center.Z + halfEdge);
        }

        private void ValidateEdgeLength(double edgeLength)
        {
            if (edgeLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Edge length must be a positive number.");
            }
        }

        public AlignedCube(double centerX, double centerY, double centerZ, double edgeLength) : this(new Point3D(centerX, centerY, centerZ), edgeLength)
        { }

        public bool Intersects(AlignedCube otherCube)
        {
            double distanceBetweenCenters = this.Center.DistanceTo(otherCube.Center);
            double edgesSumHalved = (EdgeLength + otherCube.EdgeLength) / 2;

            return distanceBetweenCenters <= edgesSumHalved;
        }

        public double IntersectedVolume(AlignedCube otherCube)
        {
            double intersectedX = this.EdgeX.OverlappedLength(otherCube.EdgeX);
            double intersectedY = this.EdgeY.OverlappedLength(otherCube.EdgeY);
            double intersectedZ = this.EdgeZ.OverlappedLength(otherCube.EdgeZ);
            double intersectedVolume = intersectedX * intersectedY * intersectedZ;
            return intersectedVolume;
        }

        public bool Intersects(Sphere otherSphere)
        {
            return otherSphere.Intersects(this);
        }

        public double IntersectedVolume(Sphere otherSphere)
        {
            return otherSphere.IntersectedVolume(this);
        }
    }
}