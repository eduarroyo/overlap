namespace overlap.lib.Figures
{
    public class OrientedCube: OrientedCuboid
    {
        public OrientedCube(Point3D center, double edgeLength) 
            : base(center, edgeLength, edgeLength, edgeLength) 
        { }

        public OrientedCube(double centerX, double centerY, double centerZ, double edgeLength)
            : base(centerX, centerY, centerZ, edgeLength, edgeLength, edgeLength)
        { }
    }
}