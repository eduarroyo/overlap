namespace overlap.lib
{
    public interface Strategy_IntersectsFigure<T>
    {
        bool intersects(T figure);
        double intersectedVolume(T figure);
    }
}