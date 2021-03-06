using System.Collections.Generic;
using Art.UI;
using Sound;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Utilities;
using Utils;
using Random = UnityEngine.Random;

namespace Game
{
    public class Asteroid : MonoBehaviour
    {

        [SerializeField] private GameObject terrainCollisionVFX, shotCollisionVFX, successText, missText;

        [SerializeField] private List<GameObject> trails;

        private Transform _target, _startPos;

        private float _widthFactor, _interpolator, _speedMultiplier;

        private void Start()
        {
            _target = GameObject.Find("GameLogic/Asteroid Target").transform;
            _startPos = transform;
            _widthFactor = Random.Range(.2f, 2f);
        }

        private void FixedUpdate()
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
            var tran = transform;
            var pos = tran.position;

            if (shotCollisionVFX)
            {
                var vfx = Instantiate(shotCollisionVFX, pos, Quaternion.identity);
                Destroy(vfx, 5);

                foreach (var notification in FindObjectsOfType<InGameNotification>())
                {
                    Destroy(notification.gameObject);
                }

                var text = Instantiate(successText, pos, quaternion.identity);
                
                var random = Random.Range(1, 5);
                text.GetComponentInChildren<TMP_Text>().text = random switch
                {
                    1 => "GRANDE!",
                    2 => "DAJE!",
                    3 => "SUPER!",
                    4 => "FORZA!",
                    5 => "TOP!",
                    _ => text.GetComponentInChildren<TMP_Text>().text
                };
                
                Destroy(text, 2);
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
            
            var asteroidCounter = FindObjectOfType<AsteroidCounter>();
            asteroidCounter.AddStatistics(1);
            asteroidCounter.IncreaseKilledAsteroids();
            
            EventManager.OnShotExplosion();
            Destroy(gameObject);
            
            FindObjectOfType<AudioManager>().PlaySound("SuccessShot");
        }

        private void TerrainCollision()
        {
            var tran = transform;
            var pos = tran.position;

            if (terrainCollisionVFX)
            {
                var vfx = Instantiate(terrainCollisionVFX, pos, Quaternion.identity);
                Destroy(vfx, 5);
                
                foreach (var notification in FindObjectsOfType<InGameNotification>())
                {
                    Destroy(notification.gameObject);
                }
                
                var text = Instantiate(missText, pos + new Vector3(0, 5, 0), quaternion.identity);
                
                var random = Random.Range(1, 5);
                text.GetComponentInChildren<TMP_Text>().text = random switch
                {
                    1 => "PECCATO...",
                    2 => "MANCATO!",
                    3 => "CONCENTRATI!",
                    4 => "OH NO!",
                    5 => "AZZ...",
                    _ => text.GetComponentInChildren<TMP_Text>().text
                };
                
                Destroy(text, 2);
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

            var asteroidCounter = FindObjectOfType<AsteroidCounter>();
            asteroidCounter.AddStatistics(0);
            asteroidCounter.IncreaseLostAsteroids();
            
            EventManager.OnGroundExplosion();
            Destroy(gameObject);
        }

        public void SetSpeedMultiplier(float sm)
        {
            _speedMultiplier = sm;
        }
    }
}