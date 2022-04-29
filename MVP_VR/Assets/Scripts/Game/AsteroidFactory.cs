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

        private bool _generate;

        private void OnEnable()
        {
            EventManager.StartGame += StartGeneration;
            EventManager.StopGame += StopGeneration;
            EventManager.StopGame += DestroyAllAsteroids;
        }
        
        private void OnDisable()
        {
            EventManager.StartGame -= StartGeneration;
            EventManager.StopGame -= StopGeneration;
            EventManager.StopGame -= DestroyAllAsteroids;
        }

        private void Start()
        {
            _generate = false;
            
            _spawnPosition = baseSpawnPoint.position;
            var distance = _spawnPosition.z;

            var azimuthRad = maxAzimuthAngle * Mathf.Deg2Rad;
            _maxWidth = distance * Mathf.Tan(azimuthRad);

            var zenithRad = maxZenithAngle * Mathf.Deg2Rad;
            _maxHeight = distance * Mathf.Tan(zenithRad);
        }

        private void StartGeneration()
        {
            _generate = true;
            StartCoroutine(AsteroidGenerator());
        }
        
        private void StopGeneration()
        {
            _generate = false;
        }

        private IEnumerator AsteroidGenerator()
        {
            while (_generate)
            {
                var time = 10f;
                
                if (_difficultyValue != 0)
                    time = timeBetweenAsteroids / _difficultyValue;

                var ast = Instantiate(asteroid, GenerateSpawnPoint(), Quaternion.identity);
                ast.SetSpeedMultiplier(0.001f * FindObjectOfType<LevelChecker>().GetCurrentLevel());
                
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

        private static void DestroyAllAsteroids()
        {
            foreach (var ast in FindObjectsOfType<Asteroid>())
            {
                Destroy(ast.gameObject);
            }
        }

        public void DifficultyValue(float d)
        {
            _difficultyValue = d / 2;
        }
    }
}
