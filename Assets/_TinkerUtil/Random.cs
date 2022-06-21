namespace TinkerUtil
{
    public static class Random
    {
        public static float WeightedRandom(float weightedTarget, int rolls)
        {
            weightedTarget = UnityEngine.Mathf.Clamp01(weightedTarget);

            float rf = UnityEngine.Random.Range(0f, 1f);
            float rt;

            for (int i = 0; i < rolls - 1; ++i)
            {
                rt = UnityEngine.Random.Range(0f, 1f);
                rf = (UnityEngine.Mathf.Abs(rf - weightedTarget) < UnityEngine.Mathf.Abs(rt - weightedTarget)) ? rf : rt;
            }

            return rf;
        }
    }
}