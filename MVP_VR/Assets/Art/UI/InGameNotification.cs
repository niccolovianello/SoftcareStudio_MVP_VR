using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Utils;

namespace Art.UI
{
    public class InGameNotification : MonoBehaviour
    {
        [SerializeField] private Vector3 targetScale;

        [Range(0f, 1f)]
        [SerializeField] private float animationSpeedMultiplier;

        [SerializeField] private List<TMP_ColorGradient> colorGradients;
        private void Start()
        {
            var index = Random.Range(0, colorGradients.Count - 1);
            GetComponentInChildren<TMP_Text>().colorGradientPreset = colorGradients.ElementAt(index);
            
            StartCoroutine(AnimationUtils.SpawnUIElement(gameObject, targetScale, animationSpeedMultiplier));
        }
        
    }
}
