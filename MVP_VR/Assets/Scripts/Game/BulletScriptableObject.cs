using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New Bullet", menuName = "Bullets")]
    public class BulletScriptableObject : ScriptableObject
    {
        public float radius = 10f;
        
        public float lifetime = 10f;
        
        public float force = 100f;
    }
}
