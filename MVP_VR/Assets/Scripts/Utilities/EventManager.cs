using System.Collections;
using UnityEngine;

namespace Utilities
{
    public class EventManager : MonoBehaviour
    {
        public delegate void Explode();
        public static event Explode ShotExplosion;

        public static event Explode GroundExplosion;

        public static void OnShotExplosion()
        {
            ShotExplosion?.Invoke();
        }

        public static void OnGroundExplosion()
        {
            GroundExplosion?.Invoke();
        }
    }
}
