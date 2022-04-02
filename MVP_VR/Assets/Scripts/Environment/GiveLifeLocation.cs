using System;
using UnityEngine;
using Utils;

namespace Environment
{
    public class GiveLifeLocation : MonoBehaviour
    {
        [SerializeField] private float minShift = 0.9f;
        
        [SerializeField] private float maxShift = 1.1f;
        
        [SerializeField] private float localizerSpeedMultiplier = 1f;


        private void Start()
        {
            foreach (Transform leaves in GetComponentInChildren<Transform>())
            {
                StartCoroutine(AnimationUtils.RandomLocalizer(leaves, minShift, maxShift, localizerSpeedMultiplier));
            }
            
        }
    }
}