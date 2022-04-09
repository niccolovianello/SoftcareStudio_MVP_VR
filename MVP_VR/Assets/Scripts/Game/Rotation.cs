using UnityEngine;

namespace Game
{
    public class Rotation : MonoBehaviour
    {

        [SerializeField] private float rotationSpeed;

        // Update is called once per frame
        private void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
