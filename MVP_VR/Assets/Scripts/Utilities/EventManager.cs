using System.Collections;
using UnityEngine;

namespace Utilities
{
    public class EventManager : MonoBehaviour
    {
        public delegate void Explode();
        public static event Explode Explosion;

        public static void OnExplosion()
        {
            Explosion?.Invoke();
        }
    }
}
