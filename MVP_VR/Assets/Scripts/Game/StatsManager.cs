using TMPro;
using UnityEngine;
using Utilities;
using UnityEngine.UI;

namespace Game
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText, comboText, levelText;

        [SerializeField] private Image comboLoader;

        private int _score, _combo, _remainingCombos;

        private void OnEnable()
        {
            EventManager.SuperCombo += NewCombo;
            EventManager.ShotExplosion += IncreaseScore;
        }
        
        private void OnDisable()
        {
            EventManager.SuperCombo -= NewCombo;
            EventManager.ShotExplosion -= IncreaseScore;
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

        private void IncreaseScore()
        {
            _score += 100;
            scoreText.text = $"{_score,0:D7}";
        }

        public void UpdateComboLoader(bool increase)
        {
            if (increase) comboLoader.fillAmount += .1f;
            else comboLoader.fillAmount = 0;
        }

        private void NewCombo()
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
