using Art.UI;
using Game;
using Scriptable_Objects;
using Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using RenderSettings = UnityEngine.RenderSettings;

namespace Utilities
{
    public class SessionManager : MonoBehaviour
    {
        [SerializeField] private SessionList sessionList;

        private GameSession _currentSession;

        private UIManager _uiManager;

        public int CurrentSessionIndex { get; private set; }

        public SessionList SessionList => sessionList;

        private void Start()
        {
            _uiManager = FindObjectOfType<UIManager>();
            CurrentSessionIndex = 0;
            _currentSession = sessionList.sessions[CurrentSessionIndex];
            LoadSession();
        }

        public void NextSession()
        {
            SceneManager.UnloadSceneAsync(_currentSession.sceneName);
            CurrentSessionIndex++;
            _currentSession = sessionList.sessions[CurrentSessionIndex];
            LoadSession();
        }

        private void LoadSession()
        {
            EventManager.OnLoadSession();
            
            if (CurrentSessionIndex != 0)
            {
                StartCoroutine(UIUtils.SwitchUISection(FindObjectOfType<LeaderboardManager>().GetComponent<CanvasGroup>()));
            }
            
            _uiManager.InitUi(CurrentSessionIndex);

            SceneManager.LoadSceneAsync(_currentSession.sceneName, LoadSceneMode.Additive);

            FindObjectOfType<AudioManager>().SetSoundtrack(_currentSession.soundtrack);

            FindObjectOfType<Timer>().SetTimer(_currentSession.duration);
            
            //Lightmapping.lightingDataAsset = _currentSession.lightingDataAsset;
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
