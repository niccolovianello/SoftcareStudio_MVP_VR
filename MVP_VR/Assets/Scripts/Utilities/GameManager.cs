using Art.UI;
using Game;
using Sound;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utilities
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ActionBasedController rightController, leftController;

        [SerializeField] private CanvasGroup leaderboard;
        
        private Shooter _gunRight, _gunLeft;

        private AudioManager _audioManager;

        private void OnEnable()
        {
            EventManager.StopGame += EnableLeaderboard;
            EventManager.StopGame += DisableGun;
            EventManager.StopGame += PlayFinalSound;
        }

        private void OnDisable()
        {
            EventManager.StopGame -= EnableLeaderboard;
            EventManager.StopGame -= DisableGun;
            EventManager.StopGame -= PlayFinalSound;
        }

        private void Start()
        {
            _audioManager = FindObjectOfType<AudioManager>();
            
            _gunRight = rightController.GetComponentInChildren<Shooter>();
            _gunLeft = leftController.GetComponentInChildren<Shooter>();
            
            DisableGun();
        }

        private void DisableGun()
        {
            _gunRight.gameObject.SetActive(false);
            _gunLeft.gameObject.SetActive(false);
        }

        private void EnableLeaderboard()
        {
            leaderboard.gameObject.SetActive(true);
        }

        private void PlayFinalSound()
        {
            _audioManager.StopSoundtrack();
            _audioManager.PlaySound("StopGame");
        }

        public void ChangeController()
        {
            var uiManager = FindObjectOfType<UIManager>();
            
            if (leftController.gameObject.activeSelf)
            {
                leftController.gameObject.SetActive(false);
                rightController.gameObject.SetActive(true);

                uiManager.ChangeControllerSprite(false);
            }

            else
            {
                rightController.gameObject.SetActive(false);
                leftController.gameObject.SetActive(true);
                
                uiManager.ChangeControllerSprite(true);
            }
        }

        public void StartTheGame(ActionBasedController controller)
        {
            if (controller.name == "RightHand Controller") _gunRight.gameObject.SetActive(true);
            else _gunLeft.gameObject.SetActive(true);
            
            HapticController.SendHaptics(controller, .75f, .75f);
            _audioManager.PlaySound("GunAppear");
            
            EventManager.OnStartGame();
        }
    }
}
