using Scriptable_Objects;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lightmapping = UnityEditor.Lightmapping;
using RenderSettings = UnityEngine.RenderSettings;

namespace Utilities
{
    public class SessionManager : MonoBehaviour
    {
        [SerializeField] private SessionList sessionList;

        private GameSession _currentSession;

        public int CurrentSessionIndex { get; private set; }

        public SessionList SessionList => sessionList;

        private void Start()
        {
            CurrentSessionIndex = 0;
            _currentSession = sessionList.sessions[CurrentSessionIndex];
            LoadSession();
        }

        public void NextSession()
        {
            CurrentSessionIndex++;
            _currentSession = sessionList.sessions[CurrentSessionIndex];
            LoadSession();
        }

        private void LoadSession()
        {
            SceneManager.LoadSceneAsync(_currentSession.sceneName, LoadSceneMode.Additive);

            FindObjectOfType<AudioManager>().SetSoundtrack(_currentSession.soundtrack);

            FindObjectOfType<Timer>().SetTimer(_currentSession.duration);
            
            Lightmapping.lightingDataAsset = _currentSession.lightingDataAsset;
            RenderSettings.skybox = _currentSession.skybox;
            
            var foggy = _currentSession.fog;
            RenderSettings.fog = foggy;
            
            if (!foggy) return;
            
            RenderSettings.fogDensity = _currentSession.fogDensity;
            RenderSettings.fogColor = _currentSession.fogColor;
            RenderSettings.fogMode = FogMode.ExponentialSquared;

        }

        
    }
}
