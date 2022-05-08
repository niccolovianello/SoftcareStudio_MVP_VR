using UnityEditor;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "NewSession", menuName = "Game Sessions/Session")]
    public class GameSession : ScriptableObject
    {
        public int duration;

        public Sound.Sound soundtrack;

        public string sceneName;

        public LightingDataAsset lightingDataAsset;

        public Material skybox;

        public bool fog;

        public float fogDensity;
        
        public Color fogColor;
    }
}
