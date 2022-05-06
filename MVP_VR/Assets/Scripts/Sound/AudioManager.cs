using System;
using UnityEngine;
using Utilities;

namespace Sound
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Sound[] sounds;

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
            foreach (var s in sounds)
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

        // Only looping sounds start at the beginning (soundrack and environment SFX)
        private void PlaySoundtrack()
        {
            PlaySound("Soundtrack");
        }

        public void PlaySound(string trackName)
        {
            var s = Array.Find(sounds, sound => sound.name == trackName);
            if (s == null)
            {
                Debug.LogWarning("Sound named '" + trackName + "' not found!" );
                return;
            }
            s.source.Play();
        }

        public void StopSound(string trackName)
        {
            var s = Array.Find(sounds, sound => sound.name == trackName);
            if (s == null)
            {
                Debug.LogWarning("Sound named '" + trackName + "' not found!" );
                return;
            }
            s.source.Stop();
        }
    }
}
