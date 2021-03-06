using UnityEngine;

namespace Game
{ 
    public class Bullet : MonoBehaviour
    {
        
        private BulletScriptableObject _bullet;

        private SphereCollider _collider;
        
        private Rigidbody _rigidbody;
        
        public void SetBullet(BulletScriptableObject bulletSo) => _bullet = bulletSo;

        private void Start()
        {
            Destroy(gameObject, _bullet.lifetime);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Asteroid"))
            {
                other.GetComponent<Asteroid>().Die();
            }
            
            Destroy(gameObject);
        
        }
        
        public void Shoot(float force)
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;
            _collider.radius = _bullet.radius;
        
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.useGravity = false;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            _rigidbody.AddForce(transform.forward * force);
        }
    }
}