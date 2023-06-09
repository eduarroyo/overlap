namespace overlap.lib.Behaviour
{
    public interface Strategy_IntersectsFigure<T>
    {
        bool intersects(T figure);
        double intersectedVolume(T figure);
    }
}