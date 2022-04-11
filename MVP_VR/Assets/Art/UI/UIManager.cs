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

        [SerializeField] private ActionBasedController leftController, rightController;

        [SerializeField] private Image leftControllerSprite, rightControllerSprite;

        public void PlayGame()
        {
            CloseStartingMenu();
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ChangeController()
        {
            
            if (leftController.gameObject.activeSelf)
            {
                leftController.gameObject.SetActive(false);
                rightController.gameObject.SetActive(true);

                leftControllerSprite.color -= new Color(0, 0, 0, .8f);
                rightControllerSprite.color += new Color(0, 0, 0, .8f);
            }

            else
            {
                rightController.gameObject.SetActive(false);
                leftController.gameObject.SetActive(true);
                
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
            FindObjectOfType<GameManager>().StartTheGame();
        }

        

    }
}
