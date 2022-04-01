using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using Utils;

namespace UI
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private CanvasGroup startingMenu;
        
        [SerializeField] private CanvasGroup mainMenu;
        
        [SerializeField] private CanvasGroup optionsMenu;

        [SerializeField] private CanvasGroup helpUI;

        [SerializeField] private ActionBasedController leftController;

        [SerializeField] private ActionBasedController rightController;
        
        [SerializeField] private Image leftControllerSprite;

        [SerializeField] private Image rightControllerSprite;
        
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
            StartCoroutine(UICoroutines.SwitchUISection(mainMenu, optionsMenu));
        }

        public void BackToMainMenu()
        {
            StartCoroutine(UICoroutines.SwitchUISection(optionsMenu, mainMenu));
        }

        private void CloseStartingMenu()
        {
            StartCoroutine(UICoroutines.SwitchUISection(startingMenu, helpUI));
        }

        

    }
}
