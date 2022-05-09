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

        public delegate void NewSession();

        public static event NewSession LoadSession;
        
        public delegate void Combo();

        public static event Combo SuperCombo;

        public delegate void Level();

        public static event Level LevelUp;

        public static event Level LevelDown;

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

        public static void OnLoadSession()
        {
            LoadSession?.Invoke();
        }

        public static void OnCombo()
        {
            SuperCombo?.Invoke();
        }

        public static void OnLevelUp()
        {
            LevelUp?.Invoke();
        }
        
        public static void OnLevelDown()
        {
            LevelDown?.Invoke();
        }
    }
}
