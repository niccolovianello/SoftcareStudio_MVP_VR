using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using Utils;

namespace Game
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text killedAsteroids, lostAsteroids, combos, maxLevel, score;

        private void Start()
        {
            ReadValues();
            ShowLeaderboard();
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
            killedAsteroids.text = asteroidCounter.GetKilledAsteroids().ToString();
            lostAsteroids.text = asteroidCounter.GetLostAsteroids().ToString();

            combos.text = FindObjectOfType<StatsManager>().GetTotalCombos().ToString();
            
            maxLevel.text = FindObjectOfType<LevelChecker>().GetMaxLevel().ToString();
            
            score.text = FindObjectOfType<ScoreUpdater>().GetScore().ToString();
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
