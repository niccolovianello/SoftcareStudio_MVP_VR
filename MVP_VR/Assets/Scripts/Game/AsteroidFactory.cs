using System.Collections;
using UnityEngine;
using Utilities;

namespace Game
{
    public class AsteroidFactory : MonoBehaviour
    {
        [SerializeField] private Asteroid asteroid;

        [SerializeField] private float maxAzimuthAngle = 120f, timeBetweenAsteroids = 10f, maxZenithAngle;

        [SerializeField] private Transform baseSpawnPoint;

        private float _maxWidth, _maxHeight, _difficultyValue;

        private Vector3 _spawnPosition;

        private void OnEnable()
        {
            EventManager.StartGame += StartGeneration;
        }
        
        private void OnDisable()
        {
            EventManager.StartGame -= StartGeneration;
        }

        private void Start()
        {
            _spawnPosition = baseSpawnPoint.position;
            var distance = _spawnPosition.z;

            var azimuthRad = maxAzimuthAngle * Mathf.Deg2Rad;
            _maxWidth = distance * Mathf.Tan(azimuthRad);

            var zenithRad = maxZenithAngle * Mathf.Deg2Rad;
            _maxHeight = distance * Mathf.Tan(zenithRad);
        }

        private void StartGeneration()
        {
            StartCoroutine(AsteroidGenerator());
        }

        private IEnumerator AsteroidGenerator()
        {
            while (true)
            {
                var time = 10f;
                
                if (_difficultyValue != 0)
                    time = timeBetweenAsteroids / _difficultyValue;

                Instantiate(asteroid, GenerateSpawnPoint(), Quaternion.identity);
                yield return new WaitForSeconds(time);
            }

        }

        private Vector3 GenerateSpawnPoint()
        {
            var x = Random.Range(-_maxWidth, _maxWidth);
            var y = _spawnPosition.y + Random.Range(-_maxHeight, _maxHeight);
            var z = _spawnPosition.z;
            
            var t = new Vector3(x, y, z);

            return t;
        }

        public void DifficultyValue(float d)
        {
            _difficultyValue = d;
        }
    }
}
