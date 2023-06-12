namespace overlap.lib.Behaviour
{
    public interface IntersectsFigure<T>
    {
        bool Intersects(T figure);
        double IntersectedVolume(T figure);
    }
}