using System;
using UnityEngine;

namespace Sound
{
    [Serializable]
    public class Sound
    {

        public string name;
        
        public AudioClip clip;
        
        [Range(0f, 1f)]
        public float volume;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}
