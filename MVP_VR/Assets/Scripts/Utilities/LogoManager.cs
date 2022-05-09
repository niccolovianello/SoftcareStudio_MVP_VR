using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class LogoManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup logoCanvas;

        [Range(1f, 10f)]
        [SerializeField] private float logoDuration;

        private void Start()
        {
            StartCoroutine(FadeLogo());
        }

        private IEnumerator FadeLogo()
        {
            while (logoCanvas.alpha < 1f)
            {
                logoCanvas.alpha += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(logoDuration);
            
            while (logoCanvas.alpha > 0f)
            {
                logoCanvas.alpha -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
