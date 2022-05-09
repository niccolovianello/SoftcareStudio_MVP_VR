using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Utils;

namespace Game
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text killedAsteroids, lostAsteroids, combos, maxLevel, score, finalText;

        [SerializeField] private Button nextLevelBtn;

        private void OnEnable()
        {
            EventManager.StartGame += DisableLeaderboard;
            
            var sessionManager = FindObjectOfType<SessionManager>();
            
            finalText.text = "Riuscirai a migliorare la performance nella prossima sessione? Colpisci il bottone sottostante per iniziare!";
            
            if (sessionManager.CurrentSessionIndex == sessionManager.SessionList.sessions.Count - 1)
            {
                DisableNextLevelButton();
                finalText.text = "Ottimo lavoro! Hai protetto egregiamente l'area dalla pioggia di meteoriti!";
            }

            ShowLeaderboard();
            ReadValues();
        }
        
        private void OnDisable()
        {
            EventManager.StartGame -= DisableLeaderboard;
        }

        private void ShowLeaderboard()
        {
            var cg = GetComponent<CanvasGroup>();

            if (!cg) return;

            StartCoroutine(UIUtils.SwitchUISection(null, cg));
        }

        private void ReadValues()
        {
            var asteroidCounter = FindObjectOfType<AsteroidCounter>();
            
            killedAsteroids.text = asteroidCounter.GetKilledAsteroids() + " (" + asteroidCounter.GetPercentage() + "%)";
            lostAsteroids.text = asteroidCounter.GetLostAsteroids().ToString();

            combos.text = FindObjectOfType<StatsManager>().GetTotalCombos().ToString();
            
            maxLevel.text = FindObjectOfType<LevelChecker>().GetMaxLevel().ToString();
            
            score.text = FindObjectOfType<ScoreUpdater>().GetScore().ToString();
        }

        public void LoadNextLevel()
        {
            FindObjectOfType<SessionManager>().NextSession();
        }

        private void DisableNextLevelButton()
        {
            nextLevelBtn.gameObject.SetActive(false);
        }

        private void DisableLeaderboard()
        {
            gameObject.SetActive(false);
        }
    }
}
