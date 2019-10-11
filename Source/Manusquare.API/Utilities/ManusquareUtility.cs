namespace Manusquare.API.Utilities
{
    public class ManusquareUtility
    {
        public static bool InRange(int value, int min, int max)
        {
            return (value >= min) && (value <= max);
        }
    }
}