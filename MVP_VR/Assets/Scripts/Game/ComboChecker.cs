using UnityEngine;
using Utilities;

namespace Game
{
    public class ComboChecker : MonoBehaviour
    {
        private int _comboCounter;

        private void Start()
        {
            _comboCounter = 0;
        }

        private bool IsCombo()
        {
            var isCombo = _comboCounter == 10;
            return isCombo;
        }

        public void IncreaseCounter()
        {
            _comboCounter++;
            
            if (!IsCombo()) return;
            
            EventManager.OnCombo();
            ResetCounter();
        }

        public void ResetCounter()
        {
            _comboCounter = 0;
        }
    }
}
