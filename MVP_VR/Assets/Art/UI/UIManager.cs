using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Utilities;
using Utils;

namespace Art.UI
{
    public class UIManager : MonoBehaviour
    {
        
        [SerializeField] private CanvasGroup background, startingMenu, mainMenu, optionsMenu, helpUI, gameStats;

        [SerializeField] private Image leftControllerSprite, rightControllerSprite;

        [SerializeField] private TMP_Text[] textsToDisable;

        private void OnEnable()
        {
            EventManager.StopGame += DisableGameStats;
        }
        
        private void OnDisable()
        {
            EventManager.StopGame -= DisableGameStats;
        }

        public void PlayGame()
        {
            CloseStartingMenu();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ChangeControllerSprite(bool left)
        {
            
            if (!left)
            {
                leftControllerSprite.color -= new Color(0, 0, 0, .8f);
                rightControllerSprite.color += new Color(0, 0, 0, .8f);
            }

            else
            {
                leftControllerSprite.color += new Color(0, 0, 0, .8f);
                rightControllerSprite.color -= new Color(0, 0, 0, .8f);
            }
        }
        
        public void OpenOptionsMenu()
        {
            StartCoroutine(UIUtils.SwitchUISection(mainMenu, optionsMenu));
        }

        public void BackToMainMenu()
        {
            StartCoroutine(UIUtils.SwitchUISection(optionsMenu, mainMenu));
        }

        public void StartTheGame()
        {
            CloseHelpUi();
            LetTheGamesBegin();
        }

        public void InitUi(int currentSessionIndex)
        {

            if (currentSessionIndex == 0)
            {
                StartCoroutine(UIUtils.SwitchUISection(null, background));
                StartCoroutine(UIUtils.SwitchUISection(null, startingMenu));
            }

            else
            {
                StartCoroutine(UIUtils.SwitchUISection(null, background));
                StartCoroutine(UIUtils.SwitchUISection(null, helpUI));

                foreach (var text in textsToDisable)
                {
                    text.gameObject.SetActive(false);
                }
            }
        }

        private void CloseStartingMenu()
        {
            StartCoroutine(UIUtils.SwitchUISection(startingMenu, helpUI));
        }

        private void CloseHelpUi()
        {
            StartCoroutine(UIUtils.SwitchUISection(helpUI));
            StartCoroutine(UIUtils.SwitchUISection(background));
        }

        private void LetTheGamesBegin()
        {
            StartCoroutine(UIUtils.SwitchUISection(null, gameStats));

            var controller = FindObjectOfType<ActionBasedController>();
            FindObjectOfType<GameManager>().StartTheGame(controller);
        }

        private void DisableGameStats()
        {
            gameStats.gameObject.SetActive(false);
        }

        
        

    }
}
