using UnityEngine;
using Utils;

namespace Environment
{
    public class GiveLifeScale : MonoBehaviour
    {
        
        [SerializeField] private float minScale = 0.9f;
        
        [SerializeField] private float maxScale = 1.1f;
        
        [SerializeField] private float scalerSpeedMultiplier = 1f;

        
        // Random movements to give life to the environment
        private void Start()
        {
            foreach (Transform leaves in GetComponentInChildren<Transform>())
            {
                StartCoroutine(AnimationUtils.RandomScaler(leaves, minScale, maxScale, scalerSpeedMultiplier));
            }
            
        }

        
        
    }
}
