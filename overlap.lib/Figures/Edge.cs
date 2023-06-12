namespace overlap.lib.Figures
{
    public class AlignedEdge
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public AlignedEdge(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public double Length => this.Max - this.Min;

        public bool Overlaps(AlignedEdge other)
        {
            return this.Min < other.Max && this.Max > other.Min;
        }

        public double OverlappedLength(AlignedEdge other)
        {
            if(!this.Overlaps(other))
            {
                return 0;
            }

            return Math.Abs(Math.Max(this.Min, other.Min) - Math.Min(this.Max, other.Max));
        }
    }
}