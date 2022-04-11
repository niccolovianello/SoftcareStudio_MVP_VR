using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class UIUtils
    {
        public static IEnumerator SwitchUISection(CanvasGroup canvasGroupToClose = null,
            CanvasGroup canvasGroupToOpen = null)
        {
            if (canvasGroupToClose)
            {
                while (canvasGroupToClose.alpha > 0)
                {
                    canvasGroupToClose.alpha -= 0.02f;
                    yield return new WaitForSeconds(0.005f);
                }

                canvasGroupToClose.gameObject.SetActive(false);

            }

            if (!canvasGroupToOpen) yield break;
            canvasGroupToOpen.gameObject.SetActive(true);

            while (canvasGroupToOpen.alpha < 1)
            {
                canvasGroupToOpen.alpha += 0.02f;
                yield return new WaitForSeconds(0.005f);

            }
        }
    }
}
