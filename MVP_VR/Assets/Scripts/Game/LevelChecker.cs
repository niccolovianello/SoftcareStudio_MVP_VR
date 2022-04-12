using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Game
{
    public class LevelChecker : MonoBehaviour
    {
        [SerializeField] private Image comboLoader;
            
        private int _successCounter, _missCounter, _level;

        private void OnEnable()
        {
            EventManager.LevelUp += IncreaseLevel;
            EventManager.LevelDown += DecreaseLevel;
        }
        
        private void OnDisable()
        {
            EventManager.LevelUp -= IncreaseLevel;
            EventManager.LevelDown -= DecreaseLevel;
        }

        private void Start()
        {
            _level = 1;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
            
            _successCounter = 0;
            _missCounter = 0;
        }
        
        public void IncreaseSuccessCounter()
        {
            _successCounter++;
            comboLoader.fillAmount += .1f;
            
            if (!IsCombo()) return;
            
            EventManager.OnCombo();
            ResetSuccessCounter();
        }

        public void IncreaseMissCounter()
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
            _level--;
            FindObjectOfType<StatsManager>().UpdateLevel(_level);
        }
        
        private void ResetSuccessCounter()
        {
            _successCounter = 0;
            comboLoader.fillAmount = 0;
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
