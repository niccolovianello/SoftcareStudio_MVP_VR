using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

namespace UI
{
    public class UIManager : MonoBehaviour
    {

        [SerializeField] private CanvasGroup startingMenu;

        [SerializeField] private ActionBasedController leftController;

        [SerializeField] private ActionBasedController rightController;
        
        [SerializeField] private Image leftControllerSprite;

        [SerializeField] private Image rightControllerSprite;
        

        public void PlayGame()
        {
            CloseStartingMenu();
            
            //Opens up tutorial UI
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

        private void CloseStartingMenu()
        {
            StartCoroutine(FadeOut(startingMenu));
        }

        private IEnumerator FadeOut(CanvasGroup canvasGroup)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            
            canvasGroup.gameObject.SetActive(false);
        }

    }
}
