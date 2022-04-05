using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class AsteroidFactory : MonoBehaviour
    {
        [SerializeField] private Asteroid asteroid;

        [SerializeField] private float maxAzimuthAngle = 120f;
        
        [SerializeField] private float maxZenithAngle;

        [SerializeField] private float distance = 500f;

        [SerializeField] private float baseHeight = 200f;

        [SerializeField] private float timeBetweenAsteroids = 10f;

        private float _maxWidth;

        private float _maxHeight;

        private void Start()
        {
            var azimuthRad = maxAzimuthAngle * Mathf.Deg2Rad;
            _maxWidth = distance * Mathf.Tan(azimuthRad);

            var zenithRad = maxZenithAngle * Mathf.Deg2Rad;
            _maxHeight = distance * Mathf.Tan(zenithRad);
        }

        public void StartGeneration()
        {
            StartCoroutine(AsteroidGenerator());
        }

        private IEnumerator AsteroidGenerator()
        {
            while (true)
            {
                Instantiate(asteroid, GenerateSpawnPoint(), Quaternion.identity);
                yield return new WaitForSeconds(timeBetweenAsteroids);
            }

        }

        private Vector3 GenerateSpawnPoint()
        {
            var x = Random.Range(-_maxWidth, _maxWidth);
            var y = baseHeight + Random.Range(-_maxHeight, _maxHeight);
            var z = distance;
            
            var t = new Vector3(x, y, z);

            return t;
        }
    }
}
