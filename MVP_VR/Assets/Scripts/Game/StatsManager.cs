using TMPro;
using UnityEngine;
using Utilities;
using UnityEngine.UI;

namespace Game
{
    public class StatsManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText, comboText, levelText;

        [SerializeField] private Image comboLoader, missCounter;

        private int _combo, _remainingCombos;

        private void OnEnable()
        {
            EventManager.SuperCombo += NewCombo;
            EventManager.LevelDown += DecreaseNeededCombos;
        }
        
        private void OnDisable()
        {
            EventManager.SuperCombo -= NewCombo;
            EventManager.LevelDown -= DecreaseNeededCombos;
        }

        private void Start()
        {
            _combo = 1;

            _remainingCombos = _combo;
            comboText.text = _remainingCombos.ToString();
        }

        public void UpdateLevel(int level)
        {
            levelText.text = "LIVELLO " + level;
        }

        public void UpdateScore(int score)
        {
            scoreText.text = $"{score,0:D7}";
        }

        public void UpdateComboLoader(bool increase)
        {
            if (increase) comboLoader.fillAmount += .1f;
            else comboLoader.fillAmount = 0;
        }

        public void UpdateMissCounter(bool increase)
        {
            if (increase) missCounter.fillAmount += .1f;
            else missCounter.fillAmount = 0;
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

        private void DecreaseNeededCombos()
        {
            _combo--;
            _remainingCombos = _combo;
            comboText.text = _remainingCombos.ToString();
        }
    }
}
