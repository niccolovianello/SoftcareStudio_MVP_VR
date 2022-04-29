using UnityEngine;
using Utilities;

namespace Game
{
    public class LevelChecker : MonoBehaviour
    {
        private int _successCounter, _missCounter, _level, _maxLevel;

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
            _maxLevel = _level;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
            
            _successCounter = 0;
            _missCounter = 0;
        }

        public int GetCurrentLevel()
        {
            return _level;
        }

        public int GetMaxLevel()
        {
            return _maxLevel;
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
            FindObjectOfType<StatsManager>().UpdateMissCounter(true);

            if (!IsLevelDown()) return;
            
            if (_level <= 1) return;
            
            EventManager.OnLevelDown();
        }

        private void IncreaseLevel()
        {
            _level++;

            if (_level > _maxLevel) _maxLevel = _level;
            
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
            
            ResetMissCounter();
        }

        private void DecreaseLevel()
        {
            if(_level > 1) _level--;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
            
            ResetMissCounter();
        }
        
        private void ResetSuccessCounter()
        {
            _successCounter = 0;
            FindObjectOfType<StatsManager>().UpdateComboLoader(false);
        }
        
        private void ResetMissCounter()
        {
            _missCounter = 0;
            FindObjectOfType<StatsManager>().UpdateMissCounter(false);
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
