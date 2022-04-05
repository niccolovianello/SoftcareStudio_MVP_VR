using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Game
{
    public class Asteroid : MonoBehaviour
    {

        private Transform _target;

        private Transform _startPos;

        private float _widthFactor;

        private float _interpolator;
        
        private void Start()
        {
            _target = GameObject.Find("GameLogic/AsteroidTarget").transform;
            _startPos = transform;
            _widthFactor = Random.Range(.2f, 1f);
        }

        private void Update()
        {
            _interpolator += Time.deltaTime;
            
            transform.position = MathUtils.Parabola(_startPos.position, _target.transform.position, _widthFactor, _interpolator/100);
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
            Destroy(gameObject);
            // VFX, SFX...
        }

        private void TerrainCollision()
        {
            Destroy(gameObject);
        }
    }
}