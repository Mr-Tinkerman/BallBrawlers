namespace TinkerLib
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

        public static int WeightedRandom(int range, int weightedTarget, int rolls)
        {
            weightedTarget = UnityEngine.Mathf.Clamp(weightedTarget, 0, range);

            int rf = UnityEngine.Random.Range(0, range + 1);
            int rt;

            for (int i = 0; i < rolls - 1; ++i)
            {
                rt = UnityEngine.Random.Range(0, range + 1);
                rf = (UnityEngine.Mathf.Abs(rf - weightedTarget) < UnityEngine.Mathf.Abs(rt - weightedTarget)) ? rf : rt;
            }

            return rf;
        }

        public static float WeightedRandomEX(float weightTarget, float weight)
        {
            weightTarget = UnityEngine.Mathf.Clamp01(weightTarget);
            weight = weight / 2f + 0.5f;

            float rand = UnityEngine.Random.Range(0f, 1f);
            rand = (rand < weightTarget) ?
                Maths.Qwerp(0, Maths.Lerp(0, weightTarget, weight), weightTarget, rand) :
                Maths.Qwerp(weightTarget, Maths.Lerp(1, weightTarget, weight), 1, rand);

            return rand;
        }
    }
}