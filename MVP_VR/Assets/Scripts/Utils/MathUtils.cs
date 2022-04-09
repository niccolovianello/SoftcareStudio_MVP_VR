using UnityEngine;

namespace Utils
{
    public static class MathUtils
    {
        public static Vector3 Parabola(Vector3 start, Vector3 end, float widthFactor, float time)
        {
            float Func(float x) => -4 * widthFactor * x * x + 4 * widthFactor * x;

            var midPoint = Vector3.Lerp(start, end, time);

            return new Vector3(midPoint.x, Func(time) + Mathf.Lerp(start.y, end.y, time), midPoint.z);
        }
    }
}