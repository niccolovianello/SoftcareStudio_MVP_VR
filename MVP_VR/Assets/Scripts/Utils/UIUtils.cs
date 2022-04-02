using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class UIUtils
    {
        public static IEnumerator SwitchUISection(CanvasGroup canvasGroupToClose, CanvasGroup canvasGroupToOpen = null)
        {
            while (canvasGroupToClose.alpha > 0)
            {
                canvasGroupToClose.alpha -= 0.02f;
                yield return new WaitForSeconds(0.01f);
            }
            
            canvasGroupToClose.gameObject.SetActive(false);

            if (!canvasGroupToOpen) yield break;
            canvasGroupToOpen.gameObject.SetActive(true);
            
            while (canvasGroupToOpen.alpha < 1)
            {
                canvasGroupToOpen.alpha += 0.02f;
                yield return new WaitForSeconds(0.01f);
            }

        }
    }
}
