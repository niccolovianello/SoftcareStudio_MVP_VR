using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ViewFinder : MonoBehaviour
    {
        [SerializeField] private Image viewFinder;

        [Range(20f, 150f)]
        [SerializeField] private float viewFinderDistance;

        private void Update()
        {
            UpdateViewFinderPosition();
        }

        private void UpdateViewFinderPosition()
        {
            var trans = transform;

            var endPos = trans.position + trans.forward * viewFinderDistance;

            viewFinder.transform.position = endPos;
            viewFinder.transform.rotation = Quaternion.LookRotation(-FindObjectOfType<Camera>().transform.forward);
        }
    }
}
