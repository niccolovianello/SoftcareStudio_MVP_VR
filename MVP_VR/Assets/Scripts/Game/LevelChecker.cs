using UnityEngine;
using Utilities;

namespace Game
{
    public class LevelChecker : MonoBehaviour
    {
        
        private int _successCounter, _missCounter, _level;

        private void OnEnable()
        {
            EventManager.LevelUp += IncreaseLevel;
            EventManager.LevelDown += DecreaseLevel;
            EventManager.ShotExplosion += IncreaseSuccessCounter;
            EventManager.GroundExplosion += IncreaseMissCounter;
            
        }
        
        private void OnDisable()
        {
            EventManager.LevelUp -= IncreaseLevel;
            EventManager.LevelDown -= DecreaseLevel;
            EventManager.ShotExplosion -= IncreaseSuccessCounter;
            EventManager.GroundExplosion -= IncreaseMissCounter;
        }

        private void Start()
        {
            _level = 1;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
            
            _successCounter = 0;
            _missCounter = 0;
        }

        private void IncreaseSuccessCounter()
        {
            _successCounter++;
            FindObjectOfType<StatsManager>().UpdateComboLoader(true);

            if (!IsCombo()) return;
            
            EventManager.OnCombo();
            ResetSuccessCounter();
        }

        private void IncreaseMissCounter()
        {
            if(_successCounter > 0) ResetSuccessCounter();
            
            _missCounter++;

            if (!IsLevelDown()) return;
            
            EventManager.OnLevelDown();
            ResetMissCounter();
        }

        private void IncreaseLevel()
        {
            _level++;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
        }

        private void DecreaseLevel()
        {
            if (_level <= 1) return;
            _level--;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);

        }
        
        private void ResetSuccessCounter()
        {
            _successCounter = 0;
            FindObjectOfType<StatsManager>().UpdateComboLoader(false);
        }
        
        private void ResetMissCounter()
        {
            _missCounter = 0;
        }
        
        private bool IsCombo()
        {
            var isCombo = _successCounter == 10;
            return isCombo;
        }

        private bool IsLevelDown()
        {
            var isLevelDown = _missCounter == 10;
            return isLevelDown;
        }
    }
}
