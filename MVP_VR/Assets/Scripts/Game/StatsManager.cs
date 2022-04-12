using TMPro;
using UnityEngine;
using Utilities;

namespace Game
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText, comboText, levelText;

        private int _score, _combo, _remainingCombos;

        private void OnEnable()
        {
            EventManager.SuperCombo += UpdateCombo;
        }
        
        private void OnDisable()
        {
            EventManager.SuperCombo -= UpdateCombo;
        }

        private void Start()
        {
            _combo = 1;

            _remainingCombos = _combo;
            comboText.text = _remainingCombos.ToString();

            _score = 0;
            scoreText.text = $"{_score,0:D7}";
        }

        public void UpdateLevel(int level)
        {
            levelText.text = "LIVELLO " + level;
        }

        public void IncreaseScore()
        {
            _score += 100;
            scoreText.text = $"{_score,0:D7}";
        }

        private void UpdateCombo()
        {
            _remainingCombos--;

            if (_remainingCombos != 0)
            {
                comboText.text = _remainingCombos.ToString();
                return;
            }
            
            EventManager.OnLevelUp();
            _combo++;
            _remainingCombos = _combo;
            comboText.text = _remainingCombos.ToString();
        }
    }
}
