using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utilities
{
    public class HapticController : MonoBehaviour
    {
        public void SendHaptics(ActionBasedController controller, float amplitude = 0.3f, float duration = 0.5f)
        {
            controller.SendHapticImpulse(amplitude, duration);
        }
    }
}
