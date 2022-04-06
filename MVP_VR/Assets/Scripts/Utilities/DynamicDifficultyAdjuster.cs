using System.Collections.Generic;

namespace Utilities
{
    public static class DynamicDifficultyAdjuster
    {
        public static float StrengthIndexCalculator(List<int> previousShots)
        {
            var strengthIndex = WeightedAverage(previousShots);
            return strengthIndex;
        }

        private static float WeightedAverage(List<int> previousShots)
        {
            var value = 0f;
            var index = 0;

            foreach (var i in previousShots)
            {
                value += i * index;
                index++;
            }
            
            var weightedAverage = value / (previousShots.Count * (previousShots.Count + 1) / 2f); 

            return weightedAverage;
        }
    }
}
