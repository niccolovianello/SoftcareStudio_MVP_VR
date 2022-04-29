using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform shootPoint;
        
        [SerializeField] private InputActionReference shootActionReference;

        [SerializeField] private Bullet bullet;

        [SerializeField] private BulletScriptableObject bulletSo;


        private void OnEnable()
        {
            shootActionReference.action.performed += OnShoot;
        }

        private void OnDisable()
        {
            shootActionReference.action.performed -= OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext obj)
        {
            Shoot();
        }

        private void Shoot()
        {
            var manaManager = FindObjectOfType<ManaManager>();

            if (!manaManager.CanShoot()) return;
            
            manaManager.DecreaseShots();
            var bul = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            bul.SetBullet(bulletSo);
            bul.Shoot(bulletSo.force);
        }
    }
}