using UnityEngine;
using Utilities;
using Utils;
using Random = UnityEngine.Random;

namespace Game
{
    public class Asteroid : MonoBehaviour
    {

        private Transform _target, _startPos;

        private float _widthFactor, _interpolator, _speedMultiplier = 0.002f;

        private void Start()
        {
            _target = GameObject.Find("GameLogic/AsteroidTarget").transform;
            _startPos = transform;
            _widthFactor = Random.Range(.2f, 1f);

        }

        private void Update()
        {
            _interpolator += Time.deltaTime;
            
            transform.position = MathUtils.Parabola(_startPos.position, _target.transform.position, _widthFactor, _interpolator * _speedMultiplier);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("AsteroidKiller"))
            {
                TerrainCollision();
            }
        }

        public void Die()
        {
            FindObjectOfType<AsteroidCounter>().AddStatistics(1);
            EventManager.OnExplosion();
            Destroy(gameObject);
            // VFX, SFX...
        }

        private void TerrainCollision()
        {
            FindObjectOfType<AsteroidCounter>().AddStatistics(0);
            Destroy(gameObject);
        }
    }
}