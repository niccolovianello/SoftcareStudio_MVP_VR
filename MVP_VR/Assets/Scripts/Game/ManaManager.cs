using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ManaManager : MonoBehaviour
    {
        [SerializeField] private int maxShots;

        [SerializeField] private float rechargeTime;

        [SerializeField] private Image shootCounter;

        private float _currentTime;

        private float _availableShots;
        

        private void Start()
        {
            _availableShots = maxShots;
            shootCounter.fillAmount = 1;
            _currentTime = 0;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= rechargeTime) RechargeShots();
        }

        public void DecreaseShots()
        {
            _availableShots -= 1;
            shootCounter.fillAmount = _availableShots / maxShots;
        }

        public bool CanShoot()
        {
            var canShoot = _availableShots != 0;

            return canShoot;
        }

        private void RechargeShots()
        {
            if (_availableShots < maxShots) _availableShots++;
            shootCounter.fillAmount = _availableShots / maxShots;
            _currentTime = 0;
        }
    }
}
