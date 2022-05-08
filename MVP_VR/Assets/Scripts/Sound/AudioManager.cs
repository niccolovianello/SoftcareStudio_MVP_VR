using System;
using UnityEngine;
using Utilities;

namespace Sound
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] environmentSounds;

        public Sound soundtrack;

        private void OnEnable()
        {
            EventManager.StartGame += PlaySoundtrack;
        }

        private void OnDisable()
        {
            EventManager.StartGame -= PlaySoundtrack;
        }
        
        private void Awake()
        {
            foreach (var s in environmentSounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.loop = s.loop;
            }
        }

        private void Start()
        {
            PlaySound("Ambient");
        }

        public void SetSoundtrack(Sound s)
        {
            soundtrack.source = gameObject.AddComponent<AudioSource>();
            soundtrack.source.clip = s.clip;

            soundtrack.source.volume = s.volume;
            soundtrack.source.loop = s.loop;
        }
        
        private void PlaySoundtrack()
        {
            soundtrack.source.Play();
        }
        
        public void StopSoundtrack()
        {
            soundtrack.source.Stop();
        }

        public void PlaySound(string trackName)
        {
            var s = Array.Find(environmentSounds, sound => sound.name == trackName);
            if (s == null)
            {
                Debug.LogWarning("Sound named '" + trackName + "' not found!" );
                return;
            }
            s.source.Play();
        }

        public void StopSound(string trackName)
        {
            var s = Array.Find(environmentSounds, sound => sound.name == trackName);
            if (s == null)
            {
                Debug.LogWarning("Sound named '" + trackName + "' not found!" );
                return;
            }
            s.source.Stop();
        }
    }
}
