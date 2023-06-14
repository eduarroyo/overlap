using overlap.lib.Behaviour;

namespace overlap.lib.Figures
{
    public class OrientedCuboid : IntersectsFigure<OrientedCuboid>
    {
        public Point3D Center { get; private set; }

        public ProjectionOnEdge EdgeXProjection { get; }
        public ProjectionOnEdge EdgeYProjection { get; }
        public ProjectionOnEdge EdgeZProjection { get; }


        public OrientedCuboid(Point3D center, double edgeXLength, double edgeYLength, double edgeZLength)
        {
            ValidateEdgeLength(edgeXLength);
            ValidateEdgeLength(edgeYLength);
            ValidateEdgeLength(edgeZLength);

            this.Center = center;

            this.EdgeXProjection = new ProjectionOnEdge(this.Center.X - edgeXLength / 2, this.Center.X + edgeXLength / 2);
            this.EdgeYProjection = new ProjectionOnEdge(this.Center.Y - edgeYLength / 2, this.Center.Y + edgeYLength / 2);
            this.EdgeZProjection = new ProjectionOnEdge(this.Center.Z - edgeZLength / 2, this.Center.Z + edgeZLength / 2);
        }

        public OrientedCuboid(double centerX, double centerY, double centerZ, double edgeXLength, double edgeYLength, double edgeZLength)
            : this(new Point3D(centerX, centerY, centerZ), edgeXLength, edgeYLength, edgeZLength)
        { }

        private void ValidateEdgeLength(double edgeLength)
        {
            if (edgeLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Edge length must be a positive number.");
            }
        }

        public bool Intersects(OrientedCuboid otherCube)
        {
            return this.EdgeXProjection.Overlaps(otherCube.EdgeXProjection)
                && this.EdgeYProjection.Overlaps(otherCube.EdgeYProjection)
                && this.EdgeZProjection.Overlaps(otherCube.EdgeZProjection);
        }

        public double IntersectedVolume(OrientedCuboid otherCube)
        {
            double intersectedX = this.EdgeXProjection.OverlappedLength(otherCube.EdgeXProjection);
            double intersectedY = this.EdgeYProjection.OverlappedLength(otherCube.EdgeYProjection);
            double intersectedZ = this.EdgeZProjection.OverlappedLength(otherCube.EdgeZProjection);
            double intersectedVolume = intersectedX * intersectedY * intersectedZ;
            return intersectedVolume;
        }
    }
}