namespace TinkerLib
{
    public static class Maths
    {
        #region Interpolation

        public static float Lerp(float a, float b, float t)
        {
            return a + t * (b - a);
        }

        public static float Qwerp(float a, float b, float c, float t)
        {
            return a + t * (2 * (b - a) + t * (c - 2 * b + a));
        }

        #endregion
    }
}
