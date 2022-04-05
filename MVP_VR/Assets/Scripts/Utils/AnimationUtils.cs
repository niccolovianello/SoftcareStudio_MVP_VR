using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class AnimationUtils
    {
        
        public static IEnumerator RandomScaler(Transform toBeAnimated, float minScale, float maxScale, float speedMultiplier)
        {
            
            while (true)
            {
                var waitTime = Random.Range(0.7f, 1.3f) / speedMultiplier;
                var elapsedTime = Time.deltaTime;
                
                var currentScale = toBeAnimated.localScale;
                
                var nextScaleValueX = currentScale.x * Random.Range(minScale, maxScale);
                var nextScaleValueY = currentScale.y * Random.Range(minScale, maxScale);
                var nextScaleValueZ = currentScale.z * Random.Range(minScale, maxScale);

                var nextScaleValue = new Vector3(nextScaleValueX, nextScaleValueY, nextScaleValueZ);

                while (elapsedTime < waitTime)
                {
                    toBeAnimated.localScale = Vector3.Slerp(currentScale, nextScaleValue, elapsedTime);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }

                yield return null;
            }
            
        }

        public static IEnumerator RandomLocalizer(Transform toBeAnimated, float minShift, float maxShift, float speedMultiplier)
        {
            while (true)
            {
                var waitTime = Random.Range(0.7f, 1.3f) / speedMultiplier;
                var elapsedTime = Time.deltaTime;
                
                var currentPosition = toBeAnimated.localPosition;
                
                var nextPositionValueX = currentPosition.x + Random.Range(minShift, maxShift);
                var nextPositionValueY = currentPosition.y + Random.Range(minShift, maxShift);
                var nextPositionValueZ = currentPosition.z + Random.Range(minShift, maxShift);

                var nextPositionValue = new Vector3(nextPositionValueX, nextPositionValueY, nextPositionValueZ);

                while (elapsedTime < waitTime)
                {
                    toBeAnimated.localPosition = Vector3.Slerp(currentPosition, nextPositionValue, elapsedTime);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }

                yield return null;
            }
        }
        
        public static IEnumerator RandomRotator(Transform toBeAnimated, float minRotation, float maxRotation, float speedMultiplier)
        {
            while (true)
            {
                var waitTime = Random.Range(0.7f, 1.3f) / speedMultiplier;
                var elapsedTime = Time.deltaTime;
                
                var currentRotation = toBeAnimated.localRotation;
                
                var nextRotationValueX = currentRotation.x + Random.Range(minRotation, maxRotation);
                var nextRotationValueY = currentRotation.y + Random.Range(minRotation, maxRotation);
                var nextRotationValueZ = currentRotation.z + Random.Range(minRotation, maxRotation);

                var nextRotationValue = new Vector3(nextRotationValueX, nextRotationValueY, nextRotationValueZ);

                var nextRotation = Quaternion.Euler(nextRotationValue);

                while (elapsedTime < waitTime)
                {
                    toBeAnimated.localRotation = Quaternion.Slerp(currentRotation, nextRotation, elapsedTime);

                    elapsedTime += Time.deltaTime;

                    yield return null;
                }

                yield return null;
            }
        }

    }
}