using UnityEngine;
using Utilities;

namespace Game
{
    public class ScoreUpdater : MonoBehaviour
    {
        private int _score;

        private StatsManager _statsManager;

        private void OnEnable()
        {
            EventManager.ShotExplosion += IncreaseScore;
            EventManager.LoadSession += InitScore;
        }
        
        private void OnDisable()
        {
            EventManager.ShotExplosion -= IncreaseScore;
            EventManager.LoadSession -= InitScore;
        }

        private void Start()
        {
            _score = 0;
            
            _statsManager = FindObjectOfType<StatsManager>();
            _statsManager.UpdateScore(_score);

        }

        private void IncreaseScore()
        {
            _score += 100;
            _statsManager.UpdateScore(_score);
        }

        public int GetScore()
        {
            return _score;
        }

        private void InitScore()
        {
            Start();
        }

    }
}
