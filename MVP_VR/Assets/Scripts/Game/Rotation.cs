using UnityEngine;

namespace Game
{
    public class Rotation : MonoBehaviour
    {

        private float _rotationSpeed;

        private void Start()
        {
            _rotationSpeed = Random.Range(150, 300);

            var rand = Random.Range(0, 1);
            switch (rand)
            {
                case 0:
                    _rotationSpeed *= -1;
                    break;
                case 1:
                    break;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            transform.Rotate(_rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
