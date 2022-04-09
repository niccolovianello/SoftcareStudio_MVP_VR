using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;
using Utils;
using Random = UnityEngine.Random;

namespace Game
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier;

        [SerializeField] private GameObject terrainCollisionVFX, shotCollisionVFX;

        [SerializeField] private List<GameObject> trails;

        private Transform _target, _startPos;

        private float _widthFactor, _interpolator;

        private void Start()
        {
            _target = GameObject.Find("GameLogic/AsteroidTarget").transform;
            _startPos = transform;
            _widthFactor = Random.Range(.2f, 2f);

        }

        private void Update()
        {
            _interpolator += Time.deltaTime;
            
            transform.position = MathUtils.Parabola(_startPos.position, _target.transform.position, _widthFactor, _interpolator * speedMultiplier);
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
            var tran = transform;
            var pos = tran.position;

            if (shotCollisionVFX)
            {
                var vfx = Instantiate(shotCollisionVFX, pos, Quaternion.identity);
                Destroy(vfx, 5);
            }

            if (trails.Count > 0)
            {
                foreach (var trail in trails)
                {
                    trail.transform.parent = null;
                    var ps = trail.GetComponent<ParticleSystem>();

                    if (!ps) continue;
                    ps.Stop();
                    var main = ps.main;
                    Destroy(ps.gameObject, main.duration + main.startLifetime.constantMax);
                }
            }
            
            FindObjectOfType<AsteroidCounter>().AddStatistics(1);
            EventManager.OnShotExplosion();
            Destroy(gameObject);
            // VFX, SFX...
        }

        private void TerrainCollision()
        {
            var tran = transform;
            var pos = tran.position;

            if (terrainCollisionVFX)
            {
                var vfx = Instantiate(terrainCollisionVFX, pos, Quaternion.identity);
                Destroy(vfx, 5);
            }

            if (trails.Count > 0)
            {
                foreach (var trail in trails)
                {
                    trail.transform.parent = null;
                    var ps = trail.GetComponent<ParticleSystem>();

                    if (!ps) continue;
                    ps.Stop();
                    var main = ps.main;
                    Destroy(ps.gameObject, main.duration + main.startLifetime.constantMax);
                }
            }
            
            FindObjectOfType<AsteroidCounter>().AddStatistics(0);
            EventManager.OnGroundExplosion();
            Destroy(gameObject);
        }
    }
}