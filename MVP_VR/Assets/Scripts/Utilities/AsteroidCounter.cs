using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

namespace Utilities
{
    public class AsteroidCounter : MonoBehaviour
    {
        [SerializeField] private int shotsToIncludeInPrediction;

        private int[] _previousShots;

        private int _missedShots;
        
        private List<int> _previousShotsList;

        private void Start()
        {
            _previousShots = new int[shotsToIncludeInPrediction];
            _previousShotsList = _previousShots.ToList();
        }

        public void AddStatistics(int i)
        {
            if (i == 0)
            {
                _missedShots++;
                if (_missedShots == 10)
                {
                    _missedShots = 0;
                    EventManager.OnLevelDown();
                }
            }
            
            _previousShotsList.RemoveAt(0);

            _previousShotsList.Add(i);
            
            var newStrengthIndex = DynamicDifficultyAdjuster.StrengthIndexCalculator(_previousShotsList);
            FindObjectOfType<AsteroidFactory>().DifficultyValue(newStrengthIndex);
        }
        
    }
}
