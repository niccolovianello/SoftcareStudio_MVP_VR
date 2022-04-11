using UnityEngine;

namespace Utilities
{
    public class EventManager : MonoBehaviour
    {
        public delegate void Explosion();
        
        public static event Explosion ShotExplosion;

        public static event Explosion GroundExplosion;
        
        public delegate void StartStopGame();

        public static event StartStopGame StartGame;
        
        public static event StartStopGame StopGame;
        
        public delegate void Combo();

        public static event Combo SuperCombo;

        // SCORE UPDATES
        public static void OnShotExplosion()
        {
            ShotExplosion?.Invoke();
        }

        public static void OnGroundExplosion()
        {
            GroundExplosion?.Invoke();
        }

        public static void OnStartGame()
        {
            StartGame?.Invoke();
        }
        
        public static void OnStopGame()
        {
            StopGame?.Invoke();
        }

        public static void OnCombo()
        {
            SuperCombo?.Invoke();
        }
    }
}
