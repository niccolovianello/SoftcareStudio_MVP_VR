using UnityEngine;
using Utils;

namespace Environment
{
    public class GiveLife : MonoBehaviour
    {
        [Header("Local scale parameters")]
        
        [SerializeField] private float minScale = 0.9f;
        
        [SerializeField] private float maxScale = 1.1f;
        
        [SerializeField] private float scalerSpeedMultiplier = 1f;
        
        
        [Header("Local position parameters")]
        
        [SerializeField] private float minShift = 0.9f;
        
        [SerializeField] private float maxShift = 1.1f;
        
        [SerializeField] private float localizerSpeedMultiplier = 1f;


        [Header("Local rotation parameters")]
        
        [SerializeField] private float minRotation = -10f;
        
        [SerializeField] private float maxRotation = 10f;
        
        [SerializeField] private float rotatorSpeedMultiplier = 1f;
        
        
        [Header("Fill with the Transforms you want to animate.")]
        [SerializeField] private Transform[] transforms;

        
        // Random movements to give life to the environment
        private void Start()
        {
            foreach (var t in transforms)
            {
                StartCoroutine(AnimationUtils.RandomScaler(t, minScale, maxScale, scalerSpeedMultiplier));
                StartCoroutine(AnimationUtils.RandomLocalizer(t, minShift, maxShift, localizerSpeedMultiplier));
                StartCoroutine(AnimationUtils.RandomRotator(t, minRotation, maxRotation, rotatorSpeedMultiplier));
            }
            
        }

        
        
    }
}
