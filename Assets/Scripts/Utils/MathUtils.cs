using UnityEngine;

namespace Utils
{
    public static class MathUtils
    {
        public static int RandomNumber(int min, int max)
        {
            return Random.Range(min, max);
        }
    }
}
